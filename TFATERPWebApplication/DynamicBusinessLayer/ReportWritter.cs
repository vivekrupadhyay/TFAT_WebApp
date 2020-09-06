using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.Models;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Core.Repositary;

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class ReportWritter : IReportWritter
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        private IBusinessCommon mIBusi = new BusinessCommon();
        private IListViewGridOperation mIlst = new ListViewGridOperation();
        private IDynamicModel DynModel = new DynamicModel();

        public JsonResult GetReportWritterStruct(string id)
        {
            var mUserQury = mIBusi.SelectSingleReportHeader(id).ToList();
            if (string.IsNullOrWhiteSpace(mUserQury.FirstOrDefault().UserQuery.ToString()) == true)
            {
                return mIlst.getGridDataColumns(mUserQury.FirstOrDefault().SubCodeOf.ToString(), "R");
            }
            else
            {
                return XGetReportColumn(id);
            }
        }

        public object GetReportData(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            string Code = HttpContext.Current.Request.UrlReferrer.LocalPath.Split('/').Last();
            var mUserQury = mIBusi.SelectSingleReportHeader(Code).ToList();
            if (string.IsNullOrWhiteSpace(mUserQury.FirstOrDefault().UserQuery.ToString()) == true)
            {
                return mIlst.Get(sidx, sord, page, rows, _search, searchField, searchOper, searchString, "R");
            }
            else
            {
                return XGetReportData(sidx, sord, page, rows, Code);
            }
        }

        public JsonResult XGetReportColumn(string mOptionName)
        {
            var mTblName = mIBusi.SelectSingleReportHeader(mOptionName).Select(h => h.Tables).ToList();
            string[] TableArr = mTblName.FirstOrDefault().ToString().Trim().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var mData = ctx.Set(Core.CoreCommon.GetTableType(TableArr.FirstOrDefault().ToString())) as IEnumerable<object>;

            List<string> colname = new List<string>();
            List<GridColumn> colModal = new List<GridColumn>();
            List<object> result = new List<object>();

            foreach (var Dt in mData)
            {
                foreach (var property in Dt.GetType().GetProperties())
                {
                    colname.Add(property.Name);

                    GridColumn gc = new GridColumn();
                    gc.name = property.Name;
                    gc.index = property.Name;
                    colModal.Add(gc);
                }
                break;
            }

            result.Add(Core.CoreCommon.GetString(colname.ToArray()));
            result.Add(colModal);

            JsonResult JR = new JsonResult();
            JR.Data = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return JR;
        }

        public object XGetReportData(string sidx, string sord, int page, int rows, string Code)
        {
            var mTblName = mIBusi.SelectSingleReportHeader(Code).Select(h => h.Tables).ToList();
            string[] TableArr = mTblName.FirstOrDefault().ToString().Trim().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var mData = ctx.Set(Core.CoreCommon.GetTableType(TableArr[0].ToString())) as IEnumerable<object>;

            int count = mData.Count();
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = count;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var Data = mData.AsEnumerable().Skip(pageIndex * pageSize).Take(pageSize);

            var result = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (from d in Data
                        select new
                        {
                            i = d.GetType().GetProperty("RecordKey").GetValue(d),
                            cell = GetCellFields(Convert.ToInt32(d.GetType().GetProperty("RecordKey").GetValue(d)), Data)
                        }).ToArray()
            };
            return result;
        }

        private string[] GetCellFields(int Code, IEnumerable<object> Data)
        {
            var resultDB = from d in Data
                           where d.GetType().GetProperty("RecordKey").GetValue(d).ToString().Equals(Code.ToString())
                           select d;

            int frmcount = resultDB.Count();
            int i = 0;
            string[] col = new string[frmcount];
            foreach (var colfrm in resultDB)
            {

                foreach (var property in colfrm.GetType().GetProperties())
                {
                    col[i] = Convert.ToString(colfrm.GetType().GetProperty(property.Name).GetValue(colfrm));
                    i++;
                }
            }
            return col;
        }

        public JsonResult GetQueryStructResult(string Qry)
        {
            Qry = Qry.Replace("\r\n", " ").ToUpper();

            string[] Fields = GetColumns(Qry);

            List<string> ColName = new List<string>();
            List<GridColumn> colModal = new List<GridColumn>();
            List<object> result = new List<object>();

            foreach (string Field in Fields)
            {
                string Column = Field.Split(
                                new string[] { " AS " }, StringSplitOptions.RemoveEmptyEntries
                                )
                                .LastOrDefault().ToUpper().Trim();
                ColName.Add(Column);
                GridColumn gc = new GridColumn();
                gc.name = Column;
                gc.index = Column;
                colModal.Add(gc);
            }

            result.Add(Core.CoreCommon.GetString(ColName.ToArray()));
            result.Add(colModal);

            JsonResult JR = new JsonResult();
            JR.Data = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return JR;
        }

        public object GetQueryDataResult(string Qry, string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            Qry = Qry.Replace("\r\n", " ").ToUpper();

            string TableName = GetTableName(Qry).First();
            string[] Fields = GetColumns(Qry);

            var resultCol = ctx.Database.SqlQuery<Columns>("select Column_Name,Data_Type from information_schema.columns where table_name = @tblName", new System.Data.SqlClient.SqlParameter("tblName", TableName)).ToList();

            TypeBuilder builder = DynModel.CreateTypeBuilder("TFATERPWebApplicationDynamic", "TfatDynamicModel", "DynamicType");

            string ColName = string.Empty;
            foreach (string Field in Fields)
            {
                string FldName = Field.Split(new string[] { " AS " }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault().ToUpper().Trim();
                var Col = from r in resultCol
                          where r.COLUMN_NAME.ToUpper() == FldName
                          select r;
                DynModel.CreateAutoImplementedProperty(builder, FldName, Type.GetType("System." + DynModel.TypeConvert(Col.First().DATA_TYPE)));
                if (ColName == string.Empty)
                {
                    ColName = FldName;
                }
            }

            var resultQuery = ctx.Database.SqlQuery(builder.CreateType(), Qry).ToListAsync().Result;

            int totalRecords = resultQuery.Count();

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var Data = resultQuery.AsEnumerable().Skip(pageIndex * pageSize).Take(pageSize);

            var result = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (from d in Data
                        select new
                        {
                            i = d.GetType().GetProperty(ColName).GetValue(d),
                            cell = GetQueryCellFieldsResult(Convert.ToString(d.GetType().GetProperty(ColName).GetValue(d)), Data, ColName)
                        }).ToArray()
            };
            return result;
        }

        public string ExecuteQuery(string Qry)
        {
            Qry = Qry.Replace("\r\n", " ").ToUpper();
            string TableName = GetTableName(Qry).First();
            string[] Fields = GetColumns(Qry);

            var resultCol = ctx.Database.SqlQuery<Columns>("select Column_Name,Data_Type from information_schema.columns where table_name = @tblName", new System.Data.SqlClient.SqlParameter("tblName", TableName)).ToList();

            TypeBuilder builder = DynModel.CreateTypeBuilder("TFATERPWebApplicationDynamic", "TfatDynamicModel", "DynamicType");

            foreach (string Field in Fields)
            {
                string FldName = Field.Split(new string[] { " AS " }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault().ToUpper().Trim();
                var Col = from r in resultCol
                          where r.COLUMN_NAME.ToUpper() == FldName
                          select r;
                DynModel.CreateAutoImplementedProperty(builder, FldName, Type.GetType("System." + DynModel.TypeConvert(Col.First().DATA_TYPE)));
            }

            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            return jsSerializer.Serialize(ctx.Database.SqlQuery(builder.CreateType(), Qry).ToListAsync().Result);
        }

        private string[] GetColumns(string Qry)
        {
            int FromIndex = Qry.IndexOf("FROM");
            string FldQuery = Qry.Substring(7, FromIndex - 7).Trim();
            return FldQuery.Split(',');
        }

        private List<string> GetTableName(string Qry)
        {
            const string REGEX_MATCH_TABLE_NAME = @"(?<=(?:FROM|JOIN)[\s(]+)(?>\w+)(?=[\s)]*(?:\s+(?:AS\s+)?\w+)?(?:$|\s+(?:WHERE|ON|(?:LEFT|RIGHT)?\s+(?:(?:OUTER|INNER)\s+)?JOIN)))";
            string resultString = Regex.Replace(Qry, REGEX_MATCH_TABLE_NAME, "dbo.$0", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] Query = resultString.Split(' ');

            List<string> TblName = new List<string>();
            foreach (var QryStr in Query)
            {
                string tblname = QryStr.StartsWith("dbo.") ? QryStr.Split('.').Last() : "";
                if (string.IsNullOrEmpty(tblname) == false)
                {
                    TblName.Add(tblname);
                }
            }
            return TblName;
        }

        private string[] GetQueryCellFieldsResult(string Code, IEnumerable<object> Data, string ColName)
        {
            var resultDB = from d in Data
                           where d.GetType().GetProperty(ColName).GetValue(d).ToString().Equals(Code)
                           select d;

            string[] col = new string[] { };

            foreach (var colfrm in resultDB)
            {
                col = new string[colfrm.GetType().GetProperties().Count()];
                int i = 0;
                foreach (var property in colfrm.GetType().GetProperties())
                {
                    col[i] = Convert.ToString(colfrm.GetType().GetProperty(property.Name).GetValue(colfrm));
                    i++;
                }
            }
            return col;
        }

        public string GetQueryHtmlResult(string cType, string Qry, string Para)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                switch (cType)
                {
                    case "D":
                        Qry = Qry.ToUpper();
                        string TableName = GetTableName(Qry).FirstOrDefault();
                        string[] FldNames = GetColumns(Qry);

                        var resultCol = ctx.Database.SqlQuery<Columns>("select Column_Name,Data_Type from information_schema.columns where table_name = @tblName", new System.Data.SqlClient.SqlParameter("tblName", TableName)).ToList();

                        TypeBuilder builder = DynModel.CreateTypeBuilder("TFATERPWebApplicationDynamic", "TfatDynamicModel", "DynamicType");

                        foreach (string Field in FldNames)
                        {
                            string FldName = Field.Split(new string[] { " AS " }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault().ToUpper();
                            var Col = from r in resultCol
                                      where r.COLUMN_NAME.ToUpper() == FldName
                                      select r;
                            DynModel.CreateAutoImplementedProperty(builder, FldName, Type.GetType("System." + DynModel.TypeConvert(Col.First().DATA_TYPE)));
                        }

                        var resultQuery = ctx.Database.SqlQuery(builder.CreateType(), Qry).ToListAsync().Result;
                        htw.RenderBeginTag(HtmlTextWriterTag.Table);
                        htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.AddAttribute("type", "checkbox");
                        htw.AddAttribute("id", "input" + Para);
                        htw.AddAttribute("OnClick", "OnCheckClick('" + Para + "');");
                        htw.RenderBeginTag(HtmlTextWriterTag.Input);
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.WriteEncodedText(Para);
                        htw.RenderEndTag();
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.AddAttribute("id", Para);
                        htw.AddAttribute("disabled", "disabled");
                        htw.RenderBeginTag(HtmlTextWriterTag.Select);
                        htw.AddAttribute("value", "");
                        htw.RenderBeginTag(HtmlTextWriterTag.Option);
                        htw.WriteEncodedText("SELECT");
                        htw.RenderEndTag();
                        foreach (var colfrm in resultQuery)
                        {
                            htw.AddAttribute("value", Convert.ToString(colfrm.GetType().GetProperty(colfrm.GetType().GetProperties()[0].Name).GetValue(colfrm)));
                            htw.RenderBeginTag(HtmlTextWriterTag.Option);
                            htw.WriteEncodedText(Convert.ToString(colfrm.GetType().GetProperty(colfrm.GetType().GetProperties()[1].Name).GetValue(colfrm)));
                            htw.RenderEndTag();
                        }

                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        break;
                }
            }
            return sb.ToString();
        }
    }
}