using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFATERPWebApplication.Dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.DynamicBusinessLayer;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Entity;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using System.Web.UI;

namespace TFATERPWebApplication.Controllers
{
    /// <summary>
    /// Use for generate Data Driven View.
    /// </summary>
    public class DynamicController : BaseController
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();
        private IDynamicAdd DynAdd = new DynamicAdd();
        private IDynamicEdit DynEdit = new DynamicEdit();
        private IDynamicDelete DynDel = new DynamicDelete();
        //
        // GET: /Dynamic/Master/[id]/[ViewName]/[ViewType]
        [HttpGet]
        public ViewResult Master(string id, string viewname, string viewtype)
        {
            return View(id);
        }
        //
        // POST: /Dynamic/Master/[id]_[ViewName]_[ViewType]
        [HttpPost]
        public ActionResult Master(string id, FormCollection collection)
        {
            string[] DynamicMaster = id.Split('_');
            //int DHeaderID = int.Parse(DynamicMaster.First());
            string DHeaderID = DynamicMaster.First();
            string VType = DynamicMaster.Last();
            List<FormCollection> frmcollecttion = new List<FormCollection>();

            //TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.OptionCode == DHeaderID);
            object hdnData;
            try
            {
                if (collection.AllKeys.AsEnumerable().Single(k => k.Equals("hdn")).Equals("hdn"))
                {
                    hdnData = JsonConvert.DeserializeObject(collection["hdn"].ToString());
                    JArray a = JArray.Parse(hdnData.ToString());
                    collection.Remove("hdn");
                    foreach (JObject fld in a.Children<JObject>())
                    {
                        FormCollection fc = new FormCollection();
                        foreach (JProperty p in fld.Properties())
                        {
                            string n = DHead.TfatDesignForms.Where(f => f.LabelCaption == p.Name).Select(f => f.Fld).ToList()[0].ToString();
                            string v = (p.Value as JValue).Value.ToString();
                            fc.Add(n, v);
                        }
                        fc.Add(DHead.IDKey.Split('^').FirstOrDefault(), collection[DHead.IDKey.Split('^').FirstOrDefault()]);
                        frmcollecttion.Add(fc);
                    }
                }
            }
            catch { }
            string message = string.Empty;
            switch (VType.ToUpper())
            {
                case "ADD":
                    foreach (string TableName in DHead.TableName.Split('^'))
                    {
                        var discTab = DHead.TfatDesignForms.Where(f => f.Fle == TableName).Select(f => f.TabName).Distinct();

                        if (discTab.ToList().SequenceEqual(new string[] { "Grid" }))
                        {
                            foreach (FormCollection fc in frmcollecttion)
                            {
                                DynAdd.DynamicAddMaster(fc, TableName, DHead.IDKey.Split('^').LastOrDefault());
                            }
                        }
                        else
                        {
                            message = DynAdd.DynamicAddMaster(collection, TableName, DHead.IDKey.Split('^').FirstOrDefault());

                        }
                    }
                    break;
                case "EDIT":
                    foreach (string TableName in DHead.TableName.Split('^'))
                    {
                        var discTab = DHead.TfatDesignForms.Where(f => f.Fle == TableName).Select(f => f.TabName).Distinct();

                        if (discTab.ToList().SequenceEqual(new string[] { "Grid" }))
                        {
                            DbSet Table = CoreCommon.GetTableData(TableName);
                            string RemoveID = DHead.IDKey.Split('^').LastOrDefault();
                            string IDKey = DHead.IDKey.ToString();
                            string Where = IDKey.ToString().Replace("^", "=@p1").Replace(RemoveID, "");
                            var QryResult = Table.SqlQuery("SELECT * FROM [" + TableName + "] WHERE " + Where, new object[] { new SqlParameter("@p1", collection[DHead.IDKey.Split('^').FirstOrDefault()]) }).ToListAsync().Result;
                            string[] ExistedCode = new string[QryResult.Count];
                            int i = 0;
                            foreach (var CodeResult in QryResult)
                            {
                                dynamic IDValue = CodeResult.GetType().GetProperty(DHead.IDKey.Split('^').LastOrDefault().ToString()).GetValue(CodeResult);
                                ExistedCode[i] = IDValue.ToString();
                                i++;
                            }
                            string[] AddedCode = new string[frmcollecttion.Count];
                            i = 0;
                            foreach (FormCollection fc in frmcollecttion)
                            {
                                Where = DHead.IDKey.ToString().Replace("^", "=@p1 AND ") + "=@p2;";
                                var QryResult1 = Table.SqlQuery("SELECT * FROM [" + TableName + "] WHERE " + Where, new object[] { new SqlParameter("@p1", collection[DHead.IDKey.Split('^').FirstOrDefault()]), new SqlParameter("@p2", fc[DHead.IDKey.Split('^').LastOrDefault().ToString()]) }).ToListAsync().Result;
                                if (QryResult1.Count == 0)
                                {
                                    DynAdd.DynamicAddMaster(fc, TableName, DHead.IDKey.Split('^').LastOrDefault());
                                }
                                else
                                {
                                    DynEdit.DynamicEditMaster(fc, TableName);
                                    AddedCode[i] = fc[DHead.IDKey.Split('^').LastOrDefault().ToString()].ToString();
                                    i++;
                                }
                            }
                            var DeleteCode = ExistedCode.Except(AddedCode);
                            foreach (var DeleteingCode in DeleteCode)
                            {
                                FormCollection fc = new FormCollection();
                                fc.Add(DHead.IDKey.Split('^').LastOrDefault().ToString(), DeleteingCode.ToString());
                                DynDel.DynamicDeleteMaster(TableName, DHead.IDKey.Split('^').LastOrDefault().ToString(), fc);
                            }
                        }
                        else
                        {
                            DynEdit.DynamicEditMaster(collection, TableName);
                        }
                    }
                    //DynamicEdit.DynamicEditMaster(DHeaderID, collection);
                    break;
                case "DELETE":
                    foreach (string TableName in DHead.TableName.Split('^').Reverse())
                    {
                        //DynamicDelete.DynamicDeleteMaster(DHeaderID, collection);
                        DynDel.DynamicDeleteMaster(TableName, DHead.IDKey.Split('^').FirstOrDefault().ToString(), collection);
                    }
                    break;
            }
            //ViewList/Index/City
            return Redirect("/ViewList/Index/" + DHeaderID + "?msg="+ message);//+ "/" + DynamicMaster[1] + "/List");

        }
    }
}

