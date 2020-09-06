using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.UI;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Core
{
    public class BuildView
    {
        private static TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();


        /// <summary>
        /// GenerateView method use to create View from Data Driven View Engine.
        /// GenerateView method take parameter to generate View.
        /// </summary>
        /// <param name="DHead">TfatDesignHeader class object</param>
        /// <param name="TableNM">Optional Parameter Table NM asper Entity Framework</param>
        /// <param name="recordkey">Optional Parameter recordkey to fatch record from Table By defualt recordkey is "0"</param>
        /// <param name="viewType">Optional Parameter viewType to generate view using viewType parameter. By default viewType="ADD"</param>
        /// <returns>Return HTML string to render view</returns>
        internal static string GenerateView(TfatDesignHeader DHead, string TableNM = "", int recordkey = 0, string viewType = "ADD")
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            int distCount = 0;
            IEnumerable<byte?> Section;
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                if (!string.IsNullOrEmpty(DHead.AddSubmitUrl) && viewType == "ADD")
                {
                    htw.AddAttribute("action", DHead.AddSubmitUrl);
                }
                else if (!string.IsNullOrEmpty(DHead.EditSubmitUrl) && viewType == "EDIT")
                {
                    htw.AddAttribute("action", DHead.EditSubmitUrl);
                }
                else if (!string.IsNullOrEmpty(DHead.DeleteSubmitUrl) && viewType == "DELETE")
                {
                    htw.AddAttribute("action", DHead.DeleteSubmitUrl);
                }

                htw.AddAttribute("method", "post");
                htw.RenderBeginTag(HtmlTextWriterTag.Form);
                //
                htw.RenderBeginTag(HtmlTextWriterTag.Div);
                object Data = null;
                if (viewType == "EDIT" || viewType == "DELETE")
                {
                    string[] IDs = DHead.IDKey.Split(new char[] { '^' });
                    DbSet TableData = CoreCommon.GetTableData(TableNM);
                    string Query = "SELECT * FROM [" + TableNM + "] WHERE " + IDs.FirstOrDefault() + " = @p0";
                    var TempData = TableData.SqlQuery(Query, recordkey).ToListAsync().Result.ToList();
                    Data = TempData.Last();
                }
                Section = DHead.TfatDesignForms.OrderBy(s => Math.Abs(Convert.ToByte(s.Section))).Select(s => s.Section).Distinct();
                distCount = Section.Count();

                //Header Control
                if (Section.First() == 1)
                {
                    TfatCreateStructure(htw, Data, DHead, viewType, 1);
                }
                //Grid Control
                else if (Section.First() == 2)
                {
                    TfatGridStructure(htw);
                }
                //Footer Control
                else if (Section.First() == 3)
                {
                    TfatCreateStructure(htw, Data, DHead, viewType, 3);
                }
                //Grid Control
                if (distCount > 1)
                {
                    if (Section.Skip(1).First() == 2)
                    {
                        TfatGridStructure(htw);
                    }
                }
                //Footer Control
                if (distCount > 2)
                {
                    if (Section.Last() == 3)
                    {
                        TfatCreateStructure(htw, Data, DHead, viewType, 3);
                    }
                }
                //ADD, EDIT & DELETE Control
                if (Section.First() != 2)
                {
                    Tfat_CRUD_PanelStructure(htw, DHead, viewType);
                }
                htw.WriteEndTag("div");
            }
            string designContent = string.Empty;
            if (distCount > 1)
            {
                designContent = ctx.TfatDesigns.ToList().Last().TfatDesignContent.Replace("@DataHeader", DHead.OptionName).Replace("@DataFields", sb.ToString());
            }
            else
            {
                if (distCount == 1 && Section.First() == 2)
                {
                    designContent = ctx.TfatDesigns.ToList().Last().TfatDesignContent.Replace("@DataHeader", DHead.OptionName).Replace("@DataFields", sb.ToString());
                }
                else
                {
                    designContent = ctx.TfatDesigns.ToList().First().TfatDesignContent.Replace("@DataHeader", DHead.OptionName).Replace("@DataFields", sb.ToString());
                }
            }
            return designContent;
        }

        /// <summary>
        /// Create View using TfatCreateStructure
        /// </summary>
        /// <param name="htw">Using HtmlTextWriter collect all html script which is usefull for View</param>
        /// <param name="Data">Data is use for Edit & Delete view to set value to appropriate control</param>
        /// <param name="DHead">TfatDesignHeader class object</param>
        /// <param name="viewType">viewType use to generate View</param>
        /// <param name="section">section has 3 Type in number 
        /// 1. Hedaer (Which Control populate in Header)
        /// 2. Grid (Which Data & Control populate in Grid)
        /// 3. Footer (Which Control populate in Footer)</param>
        ///                   
        private static void TfatCreateStructure(HtmlTextWriter htw, object Data, TfatDesignHeader DHead, string viewType, byte section = 1)
        {
            //Begin Tab(Div)
            htw.AddAttribute("id", "section" + section);
            htw.RenderBeginTag(HtmlTextWriterTag.Div);
            htw.RenderBeginTag(HtmlTextWriterTag.Ul);
            int _tab = 1;
            foreach (var tab in DHead.TfatDesignForms.Where(t => t.Section == section).Select(t => t.TabName).Distinct())
            {
                htw.RenderBeginTag(HtmlTextWriterTag.Li);
                htw.AddAttribute("href", "#section" + section + "-" + _tab.ToString());
                htw.RenderBeginTag(HtmlTextWriterTag.A);
                htw.WriteEncodedText(string.IsNullOrEmpty(tab) ? "Default" : tab.Trim().ToString());
                htw.RenderEndTag();
                htw.RenderEndTag();
                _tab++;
            }
            htw.WriteEndTag("ul");
            short? ColMaxCount = DHead.TfatDesignForms.Max(f => f.Columns);
            int? ColCount = ColMaxCount * 2;
            int? TRPercent = 100 / ColCount;
            _tab = 1;
            foreach (var tab in DHead.TfatDesignForms.Where(t => t.Section == section).Select(t => t.TabName).Distinct())
            {
                //Begin Sub Div (Tab)
                htw.AddAttribute("id", "section" + section + "-" + _tab.ToString());
                htw.RenderBeginTag(HtmlTextWriterTag.Div);
                foreach (var group in DHead.TfatDesignForms.Where(g => g.TabName == tab && g.Section == section).Select(g => g.NewGroup).Distinct())
                {
                    // if condiftion for => group of control
                    if (!string.IsNullOrEmpty(group))
                    {
                        htw.WriteBeginTag("section>");
                        htw.RenderBeginTag(HtmlTextWriterTag.B);
                        htw.WriteEncodedText(group.Trim().ToString());
                        htw.RenderEndTag();
                        htw.WriteEndTag("section");
                        htw.RenderBeginTag(HtmlTextWriterTag.Hr);
                        htw.RenderBeginTag(HtmlTextWriterTag.Colgroup);
                        htw.AddStyleAttribute("width", "620px");
                        htw.AddStyleAttribute("Font-Size", "12px");
                        htw.AddStyleAttribute("font-family", "Tahoma");
                       // htw.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "Red");                                             
                    }
                    //Begin Table (Control)
                    htw.RenderBeginTag(HtmlTextWriterTag.Table);
                    foreach (var form in DHead.TfatDesignForms.Where(f => f.TabName == tab && f.Section == section && f.NewGroup == group).OrderBy(f => Math.Abs(Convert.ToDecimal(f.DisplayOrder))))
                    {
                        //Begin Tr
                        if (form.Columns == 1)
                            htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                        //LabelCaption TD
                        htw.AddAttribute("style", "width:" + Convert.ToString(TRPercent) + "%;");
                        if (form.Visible == false)
                        {
                            htw.AddAttribute("style", "display:none;");
                        }
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.WriteEncodedText(form.LabelCaption.ToString());                       
                        htw.RenderEndTag();
                        //Control TD
                        htw.AddAttribute("style", "width:" + Convert.ToString(TRPercent) + "%;");
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.AddAttribute(HtmlTextWriterAttribute.Id, form.Fld);
                        htw.AddAttribute(HtmlTextWriterAttribute.Name, form.Fld);
                        if (form.Visible == false)
                        {
                            htw.AddAttribute("style", "display:none;");
                        }
                        if (DHead.IDKey.Equals(form.Fld) && viewType.Equals("EDIT" ?? "ADD"))
                            htw.AddAttribute("readonly", "readonly");
                        //Create Input Control
                        RenderControl(form, Data, htw, viewType);
                        htw.WriteEndTag("td");
                    }
                    //End Tr
                    htw.WriteEndTag("tr");
                    //End Table (Control)
                    htw.WriteEndTag("table");
                    htw.RenderBeginTag(HtmlTextWriterTag.Br);
                }
                //End Sub Div (Tab)
                htw.WriteEndTag("div");
                _tab++;
            }
            //End Tab(Div)
            htw.WriteEndTag("div");
        }

        /// <summary>
        /// Using Tfat_CRUD_PanelStructure we can set Add,Edit & Delete function button as per viewType
        /// </summary>
        /// <param name="htw">Using HtmlTextWriter collect CRUD html script which is usefull for View</param>
        /// <param name="DHead">TfatDesignHeader class object</param>
        /// <param name="viewType">viewType use to generate View</param>
        /// 
        //Created by Vivek
        private static void AddNew(HtmlTextWriter htw, TfatDesignHeader DHead, string viewType)
        {        
            htw.AddAttribute("width", "70%");
            htw.RenderBeginTag(HtmlTextWriterTag.Table);
            short? max = DHead.TfatDesignForms.Max(f => f.Columns);
            int maxcol = Convert.ToInt32(max) * 2;
            htw.RenderBeginTag(HtmlTextWriterTag.Tr);
            htw.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
            htw.AddStyleAttribute(HtmlTextWriterStyle.FontSize, "10px");
            htw.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "Bold");
            htw.AddStyleAttribute(HtmlTextWriterStyle.VerticalAlign, "middle");
            htw.AddAttribute("colspan", maxcol.ToString());
            htw.RenderBeginTag(HtmlTextWriterTag.Td);
            htw.AddAttribute("type", "Submit");
            if (DHead.xAdd == true && "ADD".Equals(viewType) == true)
            {
                htw.AddAttribute("value", DHead.AddName);
            }
            else if (DHead.xEdit == true && "EDIT".Equals(viewType) == true)
            {
                htw.AddAttribute("value", DHead.EditName);
            }
            else if (DHead.xDelete == true && "DELETE".Equals(viewType) == true)
            {
                htw.AddAttribute("value", DHead.DeleteName);
            }
            htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.RenderEndTag();
            htw.AddAttribute("type", "reset");
            htw.AddAttribute("value", "Cancel");
            htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.RenderEndTag();
            htw.AddAttribute("type", "button");
            htw.AddAttribute("value", "Back");
            htw.AddAttribute("onclick", "parent.history.back(); return false;");
            //htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.RenderEndTag();
            htw.WriteEndTag("td");
            //End Table (CRUD Panel)
            htw.WriteEndTag("tr");
            htw.WriteEndTag("table");
            htw.WriteEndTag("div");
        }

       

        private static void Tfat_CRUD_PanelStructure(HtmlTextWriter htw, TfatDesignHeader DHead, string viewType)
        {
            htw.RenderBeginTag(HtmlTextWriterTag.Div);
           // htw.AddStyleAttribute(HtmlTextWriterStyle.MarginLeft, "350px");
            //Begin Table (CRUD Panel)
           
            htw.AddAttribute("width", "100%");
          //  htw.AddAttribute(HtmlTextWriterAttribute.Width, "180px");
            htw.RenderBeginTag(HtmlTextWriterTag.Table);
            short? max = DHead.TfatDesignForms.Max(f => f.Columns);
            int maxcol = Convert.ToInt32(max) * 2;

            htw.RenderBeginTag(HtmlTextWriterTag.Tr);

            htw.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
            htw.AddStyleAttribute(HtmlTextWriterStyle.FontSize, "10px");
            htw.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "Bold");
            htw.AddStyleAttribute(HtmlTextWriterStyle.VerticalAlign, "middle");
            htw.AddAttribute("colspan", maxcol.ToString());
            htw.RenderBeginTag(HtmlTextWriterTag.Td);
            htw.AddAttribute("type", "Submit");
            if (DHead.xAdd == true && "ADD".Equals(viewType) == true)
            {
                htw.AddAttribute("value", DHead.AddName);
                
            }
            else if (DHead.xEdit == true && "EDIT".Equals(viewType) == true)
            {
                htw.AddAttribute("value", DHead.EditName);
            }
            else if (DHead.xDelete == true && "DELETE".Equals(viewType) == true)
            {
                htw.AddAttribute("value", DHead.DeleteName);
            }
            htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.RenderEndTag();

            htw.AddAttribute("type", "reset");
            htw.AddAttribute("value", "Cancel");
            htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.RenderEndTag();
            htw.AddAttribute("type", "button");
            htw.AddAttribute("value", "Back");
            htw.AddAttribute("onclick", "parent.history.back(); return false;");
            htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.RenderEndTag();
            htw.WriteEndTag("td");

            //End Table (CRUD Panel);
            htw.WriteEndTag("tr");
            htw.WriteEndTag("table");
            htw.WriteEndTag("div");
        }

        /// <summary>
        /// RenderControl using Control Type which is set in TfatDesignForm
        /// </summary>
        /// <param name="form">TfatDesignForm object for generate HTML control script</param>
        /// <param name="Data">Data is use for Edit & Delete view to set value to appropriate control</param>
        /// <param name="htw">Using HtmlTextWriter collect HTML Control script which is usefull for View</param>
        /// <param name="VType">VTYpe use to generate HTML Control & Set data to control</param>
        private static void RenderControl(TfatDesignForm form, object Data, HtmlTextWriter htw, string VType)
        {
            switch ((string.IsNullOrEmpty(form.fType) ? form.ControlType : form.fType))
            {
                case "T": //Textbox
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE" || form.TfatDesignHeader.IDKey.Equals(form.Fld))
                        htw.AddAttribute("readonly", "readonly");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                case "C": //Calender
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE" || form.TfatDesignHeader.IDKey.Equals(form.Fld))
                        htw.AddAttribute("readonly", "readonly");
                    htw.AddAttribute("type", "date");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                case "P": //Telephone
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE" || form.TfatDesignHeader.IDKey.Equals(form.Fld))
                        htw.AddAttribute("readonly", "readonly");
                    htw.AddAttribute("type", "tel");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                case "N": //Number
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE" || form.TfatDesignHeader.IDKey.Equals(form.Fld))
                        //htw.AddAttribute("readonly", "readonly"); //comented by dipti
                    htw.AddAttribute("type", "number");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                case "M": //Month
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE" || form.TfatDesignHeader.IDKey.Equals(form.Fld))
                        htw.AddAttribute("readonly", "readonly");
                    htw.AddAttribute("type", "month");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                case "E": //Email
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE" || form.TfatDesignHeader.IDKey.Equals(form.Fld))
                        htw.AddAttribute("readonly", "readonly");
                    htw.AddAttribute("type", "email");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                case "U": //URL
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE" || form.TfatDesignHeader.IDKey.Equals(form.Fld))
                        htw.AddAttribute("readonly", "readonly");
                    htw.AddAttribute("type", "url");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                case "A": //TextArea
                    if (VType == "DELETE")
                        htw.AddAttribute("readonly", "readonly");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Textarea);
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.WriteEncodedText(Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    htw.WriteEndTag("textarea");
                    break;
                case "D": //Dropdown
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
          
                    htw.RenderBeginTag(HtmlTextWriterTag.Select);
                 
                    if (!string.IsNullOrEmpty(form.FldValues.Trim()))
                    {
                        if (form.FldValues.IndexOf("#") > 0)
                        {

                            string[] FldValues = form.FldValues.Split(new char[] { '#' });

                            DbSet TableData = CoreCommon.GetTableData(FldValues.First());
                            var SelectData = TableData.AsQueryable().ToListAsync().Result.ToList();
                            //
                            htw.AddAttribute("value", "0");
                            if (VType == "ADD")
                                htw.AddAttribute("selected", "0");
                            if (VType == "DELETE")
                                htw.AddAttribute("disabled", "ture");
                            htw.RenderBeginTag(HtmlTextWriterTag.Option);
                            htw.WriteEncodedText("");
                            htw.RenderEndTag();
                          
                            foreach (var SData in SelectData)
                            {
                                htw.AddAttribute("value", SData.GetType().GetProperty(FldValues.Last().Split(new char[] { ',' }).First()).GetValue(SData).ToString());
                                if ((VType == "EDIT" || VType == "DELETE") && SData.GetType().GetProperty(FldValues.Last().Split(new char[] { ',' }).First()).GetValue(SData).ToString() == Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)))
                                    htw.AddAttribute("selected", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                                if (VType == "DELETE")
                                    htw.AddAttribute("disabled", "ture");
                                htw.AddStyleAttribute("width", "200px"); //set width for dropdown
                                htw.RenderBeginTag(HtmlTextWriterTag.Option);
                                htw.WriteEncodedText(Convert.ToString(SData.GetType().GetProperty(FldValues.Last().Split(new char[] { ',' }).Last()).GetValue(SData)));
                                htw.RenderEndTag();
                            }
                        }
                        else {

                            string[] FldValues1 = form.FldValues.Split(new char[] { '^' });
                            htw.RenderBeginTag(HtmlTextWriterTag.Option);
                            htw.WriteEncodedText("");
                            htw.RenderEndTag();
                           
                            foreach (var SData in FldValues1)
                            {
                                htw.AddAttribute("value", SData);
                                if ((VType == "EDIT" || VType == "DELETE") && SData.ToString() == Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)))
                                    htw.AddAttribute("selected", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                                if (VType == "DELETE")
                                    htw.AddAttribute("disabled", "ture");
                                htw.AddStyleAttribute("width", "200px"); //set width for dropdown
                                htw.RenderBeginTag(HtmlTextWriterTag.Option);
                                htw.WriteEncodedText(Convert.ToString(SData));
                                htw.RenderEndTag();
                            }
                        
                        
                        }
                    }
        
                    htw.RenderEndTag();
                    break;
                case "L": //Checkbox
                    if (VType == "EDIT" || VType == "DELETE")
                        htw.AddAttribute("value", Convert.ToString(Data.GetType().GetProperty(form.Fld).GetValue(Data)));
                    if (VType == "DELETE")
                        htw.AddAttribute("readonly", "readonly");
                    htw.AddAttribute("type", "checkbox");
                    if (form.AllowBlank == true)
                        htw.AddAttribute("required", "true");
                    htw.RenderBeginTag(HtmlTextWriterTag.Input);
                    break;
                default:
                    htw.RenderBeginTag(HtmlTextWriterTag.Unknown);
                    break;
            }
        }

        /// <summary>
        /// Generate Detail View of selected ViewName & OptionId
        /// </summary>
        /// <param name="DHead">TfatDesignHeader class object</param>
        /// <returns></returns>
        internal static string DetailView(TfatDesignHeader DHead)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                htw.AddAttribute("href", DHead.AddUrl);
                htw.RenderBeginTag(HtmlTextWriterTag.A);
                htw.WriteEncodedText("Create New");
                htw.RenderEndTag();

                htw.RenderBeginTag(HtmlTextWriterTag.Br);

                //Begin Table
                htw.RenderBeginTag(HtmlTextWriterTag.Table);
                int i = 0;

                string col = "TOUCHVALUE EnteredBy LastUpdateDate AUTHORISE AUTHIDS HWSERIAL HWSERIAL2";
                string[] Tables = DHead.TableName.Split(new char[] { '^' });
                foreach (var DtTr in CoreCommon.GetTableData(Tables.FirstOrDefault()))
                {
                    htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                    if (i == 0)
                    {
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.WriteEncodedText("Edit Action");
                        htw.RenderEndTag();
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.WriteEncodedText("Delete Action");
                        htw.RenderEndTag();

                        foreach (var prop in DtTr.GetType().GetProperties())
                        {
                            if (!prop.PropertyType.IsGenericType && !prop.PropertyType.IsInterface && !col.ToUpper().Contains(prop.Name.ToUpper()))
                            {
                                htw.RenderBeginTag(HtmlTextWriterTag.Td);
                                htw.WriteEncodedText(prop.Name.ToString());
                                htw.RenderEndTag();
                            }
                        }
                        htw.RenderEndTag();
                        htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                        i = 1;
                    }
                    string[] IDs = DHead.IDKey.Split(new char[] { '^' });
                    if (DHead.xEdit)
                    {
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.AddAttribute("href", DHead.EditUrl + DtTr.GetType().GetProperty(IDs.FirstOrDefault()).GetValue(DtTr));
                        htw.RenderBeginTag(HtmlTextWriterTag.A);
                        htw.WriteEncodedText("Edit");
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                    }

                    if (DHead.xDelete)
                    {
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.AddAttribute("href", DHead.DeleteUrl + DtTr.GetType().GetProperty(IDs.FirstOrDefault()).GetValue(DtTr));
                        htw.RenderBeginTag(HtmlTextWriterTag.A);
                        htw.WriteEncodedText("Delete");
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                    }

                    foreach (var prop in DtTr.GetType().GetProperties())
                    {
                        if (!prop.PropertyType.IsGenericType && !prop.PropertyType.IsInterface && !col.ToUpper().Contains(prop.Name.ToUpper()))
                        {
                            htw.RenderBeginTag(HtmlTextWriterTag.Td);
                            htw.WriteEncodedText(Convert.ToString(prop.GetValue(DtTr)));
                            htw.RenderEndTag();
                        }
                    }
                    htw.RenderEndTag();
                }

                //End Table
                htw.RenderEndTag();
            }

            return ctx.TfatDesigns.ToList().First().TfatDesignContent.Replace("@DataHeader", DHead.OptionName).Replace("@DataFields", sb.ToString());
        }

        /// <summary>
        /// TfatGridStructure use for to generate JQGrid script with CRUD functionality.
        /// </summary>
        /// <param name="htw">Using HtmlTextWriter collect HTML Control script which is usefull for View</param>
        private static void TfatGridStructure(HtmlTextWriter htw)
        {
            htw.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
            htw.AddAttribute(HtmlTextWriterAttribute.Id, "hdn");
            htw.AddAttribute(HtmlTextWriterAttribute.Name, "hdn");
            htw.RenderBeginTag(HtmlTextWriterTag.Input);
            htw.AddAttribute("class", "jqGrid");
            htw.RenderBeginTag(HtmlTextWriterTag.Div);
            htw.AddAttribute(HtmlTextWriterAttribute.Class, "scroll");
            htw.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
            htw.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
            htw.AddAttribute(HtmlTextWriterAttribute.Id, "list");
            htw.RenderBeginTag(HtmlTextWriterTag.Table);
            htw.RenderEndTag();
            htw.AddAttribute(HtmlTextWriterAttribute.Class, "scroll");
            htw.AddAttribute(HtmlTextWriterAttribute.Style, "text-align: center;");
            htw.AddAttribute(HtmlTextWriterAttribute.Id, "pager");
            htw.RenderBeginTag(HtmlTextWriterTag.Div);
            htw.RenderEndTag();
            htw.WriteEndTag("div");
        }

        /// <summary>
        /// GridView method usefull for to generate direct CRUD functionality on View
        /// </summary>
        /// <param name="DHeader">TfatDesignHeader class object</param>
        /// <returns>Send HTML Scirpt string to render View</returns>
        internal static string GridView(TfatDesignHeader DHeader)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Class, "scroll");
                htw.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                htw.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                htw.AddAttribute(HtmlTextWriterAttribute.Id, "list");
                htw.RenderBeginTag(HtmlTextWriterTag.Table);
                htw.RenderEndTag();
                htw.AddAttribute(HtmlTextWriterAttribute.Class, "scroll");
                htw.AddAttribute(HtmlTextWriterAttribute.Style, "text-align: center;");
                htw.AddAttribute(HtmlTextWriterAttribute.Id, "pager");
                htw.RenderBeginTag(HtmlTextWriterTag.Div);
                htw.RenderEndTag();
            }
            return ctx.TfatDesigns.ToList().Last().TfatDesignContent.Replace("@DataHeader", DHeader.OptionName).Replace("@DataFields", sb.ToString());
        }
    }
}
