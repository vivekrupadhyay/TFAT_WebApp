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
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Data_Access_Layer;
using System.Text;



namespace TFATERPWebApplication.Controllers
{
    public class NewBranchController : Controller
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString;
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();
        List<SelectListItem> acountry = new List<SelectListItem>();
        List<SelectListItem> astate = new List<SelectListItem>();
        List<SelectListItem> acity = new List<SelectListItem>();
        List<SelectListItem> compcode = new List<SelectListItem>();

        //
        // GET: /NewBranch/

        [HttpGet]
        public ActionResult NewBranch()
        {

            TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();


            foreach (TfatPass item in ctx.TfatPasses)
            {
                SelectListItem selectlist = new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.RecordKey.ToString(),
                    Selected = item.IsSelected
                };

                listSelectListItems.Add(selectlist);
            }

            TFatBranch u = new TFatBranch()
            {
                Users11 = listSelectListItems
            };
            
            //country,state,city
            ViewBag.aCountry = GetOptions();
            ViewBag.aState = astate;
            ViewBag.aCity = acity;
            ViewBag.CompCode = GetOptions1();

            //Bussiness type
            var Business = new SelectList(new[]
            {
                 new{ID="1",Name="Traders"},
                 new{ID="2",Name="Manufacturer"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Business"] = Business;


            return View(u);
        }

        [HttpPost]
        public ActionResult NewBranch(TFATERPWebApplication.Dal.TFatBranch u, IEnumerable<string> SelectedUsers1)
        {
               List<SelectListItem> listSelectListItems = new List<SelectListItem>();
                                     
                foreach (TfatPass item in ctx.TfatPasses)
                {
                    SelectListItem selectlist = new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.RecordKey.ToString(),
                        Selected = item.IsSelected
                    };

                    listSelectListItems.Add(selectlist);
                }

                u.Users11 = listSelectListItems;
                           
            //country,state,city
            ViewBag.aCountry = GetOptions();
            ViewBag.aState = astate;
            ViewBag.aCity = acity;
            ViewBag.CompCode = GetOptions1();
            
            //Bussiness type
            var Business = new SelectList(new[]
            {
                 new{ID="1",Name="Traders"},
                 new{ID="2",Name="Manufacturer"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Business"] = Business;
                    
            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            SqlConnection con = null;
            string result1 = "";
            //save userdata
            if (SelectedUsers1!=null)
            { 
                foreach (var item in SelectedUsers1)
                {
                    con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ToString());
                    SqlCommand cmd = new SqlCommand("Tfat_Insert_UserCompBranch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId  ", item.ToString());
                    cmd.Parameters.AddWithValue("@CompCode  ", u.CompCode);
                    cmd.Parameters.AddWithValue("@BranchCode ", u.Code);
                    cmd.Parameters.AddWithValue("@Status  ", true);
                    con.Open();
                    result1 = cmd.ExecuteNonQuery().ToString();
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - " + string.Join(",", SelectedUsers1));
            }
            if (ModelState.IsValid)
            {
                TFatBranch mmd = new TFatBranch();
                //mmd.Code = u.Code;
                Branch objDB = new Branch();
                string result = objDB.InsertData(u); // passing Value to DBClass from model
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
            }
            return View(u);
        }

        private SelectList GetOptions1()
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

                        compcode.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["Code"].ToString() });
                   
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

                return new SelectList(compcode, "Value", "Text", "code");

            }
        }
       
        public SelectList GetOptions()
        {
            
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("select Name,Code from tfatcountry", conn);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                         acountry.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["Code"].ToString() });
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

                return new SelectList(acountry, "Value", "Text", "code");

            }
        }

        public JsonResult State(string code)
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select Name,Country,code from TfatState where Country='" + code + "'", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {

                    astate.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["code"].ToString() });
                }
            }
            return Json(astate, JsonRequestBehavior.AllowGet);

        }

        public JsonResult City(string code)
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select Name,code,State from tfatcity  where State='" + code + "'", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                   acity.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["Code"].ToString() });
                }
            }

            return Json(acity, JsonRequestBehavior.AllowGet);

        }

    }


}
