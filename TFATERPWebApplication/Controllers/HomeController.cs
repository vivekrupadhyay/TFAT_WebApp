using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.OleDb;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Core;

namespace TFATERPWebApplication.Controllers
{
    public class HomeController : BaseController
    {
       Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        private IBusinessCommon mIBusi = new BusinessCommon();
        private IGridOperations GrdOper = new GridOperations();
        private IDynamicAdd DynAdd = new DynamicAdd();
        private IDynamicEdit DynEdit = new DynamicEdit();
        private IDynamicDelete DynDel = new DynamicDelete();

        public ActionResult Index()
        {
            Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetGridStructure(int id)
        {
            return GrdOper.GetGridColStructure(id);
        }

        public JsonResult GetGridData(string sidx, string sord, int page, int rows)
        {
            DataTable Dt = null;
            int id = 0;
            if (Session.Count != 0)
            {
                Dt = Session["data"] as DataTable;
            }
            object result = GrdOper.Get(sidx, sord, page, rows, ref Dt);

            TempData["id"] = id;
            TempData["data"] = Dt;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveGridData(object id, FormCollection collection)
        {
            string sidx = TempData["id"] as string;
            DataTable Dt = TempData["data"] as DataTable;

            int DHeaderID = Convert.ToInt32(HttpContext.Request.Url.Segments.Last());
            string vType = HttpContext.Request.UrlReferrer.Segments.Last();

            Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
            Dal.TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);

            string[] IDs = DHead.IDKey.Split(new char[] { '^' });
            string IDkeys = IDs.Count() > 1 ? IDs.Last() : IDs.First();
            object result;
            if (vType.ToUpper().ToString() == "GRID")
            {
                switch (collection["oper"].ToUpper())
                {
                    case "ADD":
                        collection.Remove("oper");
                        collection.Remove("id");
                        FormCollection fcoll1 = mIBusi.GetDBFormCollection(DHead, collection);
                        fcoll1.Set(IDkeys, "");
                        DynAdd.DynamicAddMaster(DHeaderID, fcoll1);
                        break;
                    case "EDIT":
                        collection.Remove("oper");
                        FormCollection fcoll2 = mIBusi.GetDBFormCollection(DHead, collection);
                        fcoll2.Set(IDkeys, collection["id"]);
                        //collection.Remove("id");
                        DynEdit.DynamicEditMaster(DHeaderID, fcoll2);
                        break;
                    case "DEL":
                        collection.Remove("oper");
                        FormCollection fcoll3 = mIBusi.GetDBFormCollection(DHead, collection);
                        fcoll3.Set(IDkeys, collection["id"]);
                        //collection.Remove("id");
                        DynDel.DynamicDeleteMaster(DHeaderID, fcoll3);
                        break;
                }
                result = GrdOper.Get(IDkeys, "asc", 1, 100);
            }
            else
            {
                switch (collection["oper"].ToUpper())
                {
                    case "ADD":
                        collection.Remove("oper");
                        collection.Remove("id");
                        DynAdd.DynamicGirdAddMaster(DHeaderID, collection, Dt);
                        break;
                    case "EDIT":
                        collection.Remove("oper");
                        collection.Set(IDkeys, collection["id"]);
                        collection.Remove("id");
                        DynEdit.DynamicGirdEditMaster(DHeaderID, collection, Dt);
                        break;
                    case "DEL":
                        collection.Remove("oper");
                        collection.Set(IDkeys, collection["id"]);
                        collection.Remove("id");
                        DynDel.DynamicGirdDeleteMaster(DHeaderID, collection, Dt);
                        break;
                }
                //int mid = collection[IDkeys].ToString() == string.Empty ? 0 : int.Parse(collection[IDkeys].ToString());
                result = GrdOper.Get(IDkeys, "asc", 1, 100, ref Dt);
                Session["data"] = Dt;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTfatMenuJSON(string mProjectCode)
        {
            return Json(DynamicMenu.XGetMenu(mProjectCode), JsonRequestBehavior.AllowGet);
        }


    }
}
