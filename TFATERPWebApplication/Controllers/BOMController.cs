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
//using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
//using TFATERPWebApplication.Core;
using TFATERPWebApplication.Data_Access_Layer;
using System.Text;

using TFATERPWebApplication.Models;
using System.IO;



namespace TFATERPWebApplication.Controllers
{
    //[Authorize ]
    public class BOMController : Controller
    {

   
      //  string connection = System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString;
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();
        //
        // GET: /BOM/
        
        
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult BOM()
        //{
        //    return View();
        //}
        //[HttpPost ]
       //[AllowAnonymous]
        public ActionResult BOM()
        {
            //this.ctx = bm;
            //TFATERPWebApplication.Models.ItemBOMHeaderDetailModel itm = new ItemBOMHeaderDetailModel();



           // var query = ctx.ItemBOMHeaders.Join
           //(
           //ctx.ItemBOMs, r => r.BOMSrl, p => p.Code, (r, p) => new
           //{
           //    r.BOMSrl,
           //    r.BOMName,

           //    p.Code
           //}
           //)
           //.Join(ctx.ItemBOMRoutes, a => a.BOMName, b => b.BOMSrl, (a, b) => new
           //{
           //    a.BOMName,

           //    a.Code,
           //    b.BOMSrl
           //})

           //.ToList();

           // //var result = from o in ctx.ItemBOMHeaders
           // //             join od in ctx.ItemBOMRoutes on o.BOMSrl equals od.BOMSrl
           // //             join odd in ctx.ItemBOMs on o.Code equals odd.Code
           // //             join cc in ctx.ItemMasters on o.Code equals cc.Code
           // //             join css in ctx.AddOn_B on o.Code equals css.Code
           // //             select new ItemBOMHeaderDetailModel { Item = od.BOMSrl, ItemBom = odd.Code, ItemRoute = od.BOMSrl, AddOn = css.Code };
           // if (ctx == null)
           // {
           //     return HttpNotFound();
           // }

            return View();
           
        }
        
    }
}
