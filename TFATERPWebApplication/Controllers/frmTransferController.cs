using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFATERPWebApplication.Controllers
{
    public class frmTransferController : Controller
    {
        //
        // GET: /frmTransfer/
        Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        public ActionResult Index()
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View();
        }

    }
}
