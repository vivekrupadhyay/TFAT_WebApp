using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;

namespace TFATERPWebApplication.Controllers
{
    public class ViewListController : BaseController
    {
        //
        // GET: /ViewList/
        Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        IListViewGridOperation mIlst = new ListViewGridOperation();
        IBusinessCommon mIBuss = new BusinessCommon();

        public ActionResult Index(string id,string msg="")
        {
            var NewFromDetail = mIBuss.SelectSingleTfatDeignHeader(id);
            ViewBag.AddUrl = NewFromDetail.Single().AddUrl;
            ViewBag.FormName = NewFromDetail.Single().OptionName;
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            ViewBag.ErrorMsg = msg;
            return View();
        }

        [HttpPost]
        public JsonResult GetGridStructureRecords(string id)
        {
            return mIlst.getGridDataColumns(id);
        }

        [HttpPost]
        public JsonResult GetRecords(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            object result = mIlst.Get(sidx, sord, page, rows, _search, searchField, searchOper, searchString);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        ////
        //// GET: /ViewList/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /ViewList/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /ViewList/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /ViewList/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /ViewList/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /ViewList/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /ViewList/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
