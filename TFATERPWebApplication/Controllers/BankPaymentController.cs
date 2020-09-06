using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Models;
using System.Data.Entity;


namespace TFATERPWebApplication.Controllers
{
    public class BankPaymentController : Controller
    {


        IListViewGridOperation mIlst = new ListViewGridOperation();
        IBusinessCommon mIBuss = new BusinessCommon();
        TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();

        //
        // GET: /BankPayment/

        public ActionResult Index()
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View();
        }

        [ActionName("BankPayment")]
        public ActionResult Bank_Payment(string id, string msg = "")
        {
            var NewFromDetail = mIBuss.SelectSingleTfatDeignHeader(id);

            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            ViewBag.ErrorMsg = msg;

            return View("Bank_Payment");
        }

        public JsonResult PopulateFromDB(string id)
        {

            var jsonData = from c in ctx.LedgerBranches
                           select new { c.Sno, c.Branch, c.Code, c.Debit, c.Credit, c.CostCentre, c.Cheque, c.BankCode, c.Narr }.ToString();
            
            if (id.ToUpper() == "ADD")
            {
                jsonData = null;
            }
            if (id.ToUpper() == "EDIT")
            {
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        

       public ActionResult GetData(string sidx, string sord, int page, int rows)

        {
           
            var jsonData = new

                               {

                                  
                                   rows = (from c in ctx.LedgerBranches
                                           select new

                                                      {

                                                        c.Sno, c.Branch, c.Code, c.CostCentre, c.Cheque, c.BankCode, c.Narr
                                                                 
                                                      }).ToArray()

                               };
           
            return Json(jsonData);

}


        public ActionResult Add()
        {

            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View("Bank_Payment");
        }

        public ActionResult Edit()
        {

            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            return View("Bank_Payment");
        }
        //[HttpPost]
        //public string Create([Bind(Exclude = "Id")] BankPayment bj)
        //{

        //    string msg;
        //    try
        //    {
        //       if(ModelState.IsValid)
        //       {


        //           ctx.bankPaymentlist.Add(bj);
        //           ctx.SaveChanges();
        //           msg = "Save Successfully";

        //       }
        //       else
        //       {
        //           msg = "validation data not successfully";
        //       }



        //    }
        //    catch(Exception ex)
        //    {
        //        msg = "Error occured" + ex.Message;
        //    }
        //    return msg;




        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult AddProduct(FormCollection postData)
        //{
        //    //Creating new product object based on postData
        //    BankPayment Ledger = new BankPayment();
        //    Ledger.Sno = postData["SrNo"];
        //    Ledger.Branch = postData["Plan/BU"];
        //    Ledger.Code = postData["Code"];
        //    Ledger.BankCode = postData["Account Description"];
        //    Ledger.Debit = Convert.ToDecimal(postData["Debit (INR)"].Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        //    Ledger.Credit = Convert.ToInt16(postData["Credit (INR)"]);
        //    product.Discontinued = false;

        //    //Adding product to repository
        //    bool success = _repository.AddProduct(product);

        //    //Returning data - we can hadle this data in form afterSubmit event
        //    return Json(success);
        //}




    }
}
