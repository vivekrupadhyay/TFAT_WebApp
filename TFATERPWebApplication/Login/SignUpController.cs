using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.EntityModel;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using TFATERPWebApplication.Dal;


namespace TFATERPWebApplication.Login
{
    public class SignUpController : Controller
    {
        private Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();

        //
        // GET: /SignUp/

        public ActionResult Index()
        {
            return View();
        }


        // GET: /Login/SignUp
        
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
          
        }

        // POST: /Login/SignUp=
        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(TFATERPWebApplication.Models.TfatPassModel u)
        {
            ViewBag.pass = u.PassWords;
            ViewBag.conpass = u.ConfirmPassword;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                string realCaptcha = Session["captcha"].ToString();
                if (u.Captcha == realCaptcha)
                {
                    if (u.Insert())
                    {
                        return RedirectToAction("Newdatalist", "Company");
                    } 
                    else
                    {
                        ModelState.AddModelError("exist", "Email Id Already Exist.");
                    }
                }
                else

                    ModelState.AddModelError("myerrorsummary", "Verification Code is Incorrect");
            }


            if (!u.TermsAccepted)
            {
                ModelState.AddModelError("TermsAccepted", "You must accept the terms");
            }

                return View(u);
        }


        public TFATERPWebApplication.Models.CaptchImageAction Image()
        {
            string randomText = SelectRandomWord(6);
            Session["captcha"] = randomText;
            HttpContext.Session["RandomText"] = randomText;
            return new TFATERPWebApplication.Models.CaptchImageAction()
            {
                BackgroundColor = Color.LightGray, 
                RandomTextColor = Color.Black, RandomText = randomText };
        }

        private string SelectRandomWord(int numberOfChars)
        {
            if (numberOfChars > 36)
            {
                throw new InvalidOperationException("Random Word Characters cannot be greater than 36");
            }
            char[] columns = new char[36];
            for (int charPos = 65; charPos < 65 + 26; charPos++)
                columns[charPos - 65] = (char)charPos;
            for (int intPos = 48; intPos <= 57; intPos++)
                columns[26 + (intPos - 48)] = (char)intPos;
            StringBuilder randomBuilder = new StringBuilder();
            Random randomSeed = new Random();
            for (int incr = 0; incr < numberOfChars; incr++)
            {
                randomBuilder.Append(columns[randomSeed.Next(36)].ToString());
            }
            return randomBuilder.ToString();
        }

    }
}
