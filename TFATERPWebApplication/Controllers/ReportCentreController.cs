using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Controllers
{
    public class ReportCentreController : BaseController
    {
        //
        // GET: /ReportCentre/
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();
        private IGridOperations GrdOper = new GridOperations();
        private IReportCenterOperation RptCenterOper = new ReportCenterOperation();

        public ActionResult Index()
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View();
        }

        public ActionResult GetReportCenterMenu()
        {
            return Json(RptCenterOper.XGetReportCntMenuStructure(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRecords(string id, string sidx, string sord, int page, int rows)
        {
            object result = GrdOper.GetReportCntrData(id, sidx, sord, page, rows);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
