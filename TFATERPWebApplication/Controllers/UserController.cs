using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
//using System.Data.OleDb;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Models;
using System.Data.SqlClient;




namespace TFATERPWebApplication.Controllers
{

    public class UserController : Controller
    {

        private Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        //
        // GET: /User/

        public ActionResult Index()
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View();
        }


        public JsonResult AutocompleteName(string name)
        {

            //IEnumerable<PartialModel> modelList = new List<PartialModel>();
            Dal.TFAT_WEBERPEntities context = new Dal.TFAT_WEBERPEntities();

            return Json(context.TfatComps.Where(x => x.Name.Contains(name)).Select(s => s.Name).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteCode(string code)
        {
    
            Dal.TFAT_WEBERPEntities context = new Dal.TFAT_WEBERPEntities();

            return Json(context.TfatComps.Where(x => x.Code.Contains(code)).Select(s => s.Code).ToArray(), JsonRequestBehavior.AllowGet);
           
        }
              
        public JsonResult GetCodeName(string codeName, string mPara)
        {
            string UserName = "";
            if (mPara == "C")
            {
                var query = (from u in ctx.TfatComps
                             where u.Code.ToLower() == codeName.ToLower()
                             select u.Name).SingleOrDefault();
                if (query != null)
                {
                    UserName = query;
                }
            }
            else
            {
                var query = (from u in ctx.TfatComps
                             where u.Name.ToLower() == codeName.ToLower()
                             select u.Code).SingleOrDefault();
                if (query != null)
                {
                    UserName = query;
                }
            }
            return Json(UserName, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserC()
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View();
        }


      
    }
}



