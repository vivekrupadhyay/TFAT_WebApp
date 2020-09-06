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
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Models;
using TFATERPWebApplication.DataAccessLayer;
using System.Text;
using System.Configuration;


namespace TFATERPWebApplication.Controllers
{

    public class NewCompanyController : Controller
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ConnectionString;

        List<SelectListItem> country = new List<SelectListItem>();
        List<SelectListItem> state = new List<SelectListItem>();
        List<SelectListItem> city = new List<SelectListItem>();

        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        //
        // GET: /NewCompany/
        [HttpGet]
        public ActionResult NewCompany()
        {

            //list of user
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

            TfatComp u = new TfatComp()
            {
                Users1 = listSelectListItems
            };


            //country,state,city

            ViewBag.Country = GetOptions();
            ViewBag.State = state;
            ViewBag.City = city;

            //Bussiness type
            var Business = new SelectList(new[]
            {
                 new{ID="1",Name="Traders"},
                 new{ID="2",Name="Manufacturer"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Business"] = Business;

            //constitution
            var Const = new SelectList(new[]
            {
                 new{ID="1",Name="Private Limited"},
                 new{ID="2",Name="Govt"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Const"] = Const;

            //Company Type
            var CompanyType = new SelectList(new[]
            {
                 new {ID="1",Name="02-HUF"},
                 new{ID="2",Name="05-HUF"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["CompanyType"] = CompanyType;

            //Deductor Type
            var DeductorType = new SelectList(new[]
            {
                 new {ID="1",Name="J-Artificial juridical Person"},
                 new{ID="2",Name="05-HUF"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["DeductorType"] = DeductorType;

            //Deductor Type
            var Ministry = new SelectList(new[]
            {
                 new {ID="1",Name="Agriculture"},
                 new{ID="2",Name="05-HUF"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Ministry"] = Ministry;

            return View(u);
        }

        [HttpPost]
        public ActionResult NewCompany(TFATERPWebApplication.Dal.TfatComp u, IEnumerable<string> SelectedUsers)
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
            
            u.Users1 = listSelectListItems;
                   
            SqlConnection con = null;
            string result1 = "";
            //save userdata

            if (SelectedUsers != null)
            {
                foreach (var item in SelectedUsers)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["TFAT_WEBERPEntitiesResource"].ToString());
                    SqlCommand cmd = new SqlCommand("Tfat_Insert_UserCompBranch", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId  ", item.ToString());
                    cmd.Parameters.AddWithValue("@CompCode  ", u.Code);
                    cmd.Parameters.AddWithValue("@BranchCode ", 0);
                    cmd.Parameters.AddWithValue("@Status  ", true);
                    con.Open();
                    result1 = cmd.ExecuteNonQuery().ToString();
                }
            }
            ViewBag.Country = GetOptions();
            ViewBag.State = state;
            ViewBag.City = city;

            //Bussiness type
            var Business = new SelectList(new[]
            {
                 new{ID="1",Name="Traders"},
                 new{ID="2",Name="Manufacturer"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Business"] = Business;

            //constitution
            var Const = new SelectList(new[]
            {
                 new{ID="1",Name="Private Limited"},
                 new{ID="2",Name="Govt"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Const"] = Const;

            //Company Type
            var CompanyType = new SelectList(new[]
            {
                 new {ID="1",Name="02-HUF"},
                 new{ID="2",Name="05-HUF"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["CompanyType"] = CompanyType;

            //Deductor Type
            var DeductorType = new SelectList(new[]
            {
                 new {ID="1",Name="J-Artificial juridical Person"},
                 new{ID="2",Name="05-HUF"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["DeductorType"] = DeductorType;

            //Deductor Type
            var Ministry = new SelectList(new[]
            {
                 new {ID="1",Name="Agriculture"},
                 new{ID="2",Name="05-HUF"},
                 new{ID="3",Name="name3"},
            },
                 "ID", "Name", 1);
            ViewData["Ministry"] = Ministry;


            //save company data
            if (ModelState.IsValid)
            {
                //TfatComp mmd = new TfatComp();                   
                Company objDB = new Company();
                string result = objDB.InsertData(u); // passing Value to DBClass from model
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
            }

            return View(u);
          }

        private SelectList GetOptions()
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

                        country.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["Code"].ToString() });
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

                return new SelectList(country, "Value", "Text", "code");

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

                    state.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["code"].ToString() });
                }
            }
            return Json(state, JsonRequestBehavior.AllowGet);

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

                    city.Add(new SelectListItem { Text = myReader["Name"].ToString(), Value = myReader["Code"].ToString() });
                }
            }

            return Json(city, JsonRequestBehavior.AllowGet);

        }

    }
}
