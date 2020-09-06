using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.OleDb;

namespace TFATERPWebApplication.Login
{
    public class LoginController : Controller
    {
        private Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        //
        // GET: /Login/

        public ActionResult Index()
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TFATERPWebApplication.Models.TfatPassModel u)
        {
            // this action is for handle post (login)
            //if (ModelState.IsValid) // this is check validity
            //{
            using (Dal.TFAT_WEBERPEntities dc = new Dal.TFAT_WEBERPEntities())
                {
                    var v = dc.TfatPasses.Where(a => a.IDs.Equals(u.IDs) && a.PassWords.Equals(u.PassWords)).FirstOrDefault();

                    if (v != null)
                    {
                        Session["UserName"] = v.IDs.ToString();
                        return RedirectToAction("Newdatalist", "Company");
                    }
                    else
                    {
                        ModelState.AddModelError("errormsg", "Login details are wrong.");
                    }
                }
            //}
            return View(u);
        }
   
        }
}