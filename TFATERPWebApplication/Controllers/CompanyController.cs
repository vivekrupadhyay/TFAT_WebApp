using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class CompanyController : Controller
    {
        //private Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString;
        
        List<SelectListItem> branch = new List<SelectListItem>();
        List<SelectListItem> perd = new List<SelectListItem>();
        List<SelectListItem> company = new List<SelectListItem>();

        //
        // GET: /Company/

        public ActionResult Newdatalist()
        {
            //ViewBag.TfatComps = ctx.TfatComps.ToList();
            //ViewBag.TfatBranch = ctx.TFatBranches.ToList();

            ViewBag.var1 = GetOptions();
            ViewBag.var2 = branch;
            ViewBag.var3 = perd;
            return View();
        }


        private SelectList GetOptions()
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("select Name,Code from TfatComp", conn);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {

                        company.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["Code"].ToString() });
                    }


                }
                catch (Exception e)
                {
                    string msg = e.Message;
                }
                finally
                {

                    conn.Close();
                }

                return new SelectList(company, "Value", "Text", "code");

            }
        }

        public JsonResult Branch(string code)
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select Name,Code from TFatBranch where Compcode='" + code + "'", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {

                    branch.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["Code"].ToString() });
                }
            }
            return Json(branch, JsonRequestBehavior.AllowGet);

        }


        public JsonResult Perd(string code)
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select PerdCode,Code,format(startdate,'Y')+' to '+format(lastdate,'Y')as FinancialYear from TFatPerd  where Code='" + code + "'", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {

                    perd.Add(new SelectListItem { Text = myReader["FinancialYear"].ToString(), Value = myReader["Code"].ToString() });
                }
            }
            return Json(perd, JsonRequestBehavior.AllowGet);

        }

       

    }

}
