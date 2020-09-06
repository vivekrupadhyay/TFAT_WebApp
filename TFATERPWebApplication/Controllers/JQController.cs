using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.UI;
using TFATERPWebApplication.Core;
using System.Reflection;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;

namespace TFATERPWebApplication.Controllers
{
    public class JQController : Controller
    {
        TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();

        IListViewGridOperation mIlst = new ListViewGridOperation();
        IBusinessCommon mIBuss = new BusinessCommon();
        //
        // GET: /JQ/

        public ActionResult Index(string id, string msg = "")
        {
            TempData["BnkPay"] = "";
            //Session["UserId"] = 1;
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            var NewFromDetail = mIBuss.SelectSingleTfatDeignHeader(id);
            //var c = ctx.LedgerBranches.ToList();
            //return View(c);
            return View();
        }


        [HttpGet]
        public JsonResult GetRecords(string sidx, string sord, int page, int rows, bool _search)
        {
            List<Stock> test;
            if (Session.Count != 0)
            {
                test = Session["postData"] as List<Stock>;
            }
            else
            {
                test = new List<Stock>();
            }
            var count = test == null ? 0 : test.Count;
            int pageIndex = page;
            int pageSize = rows;
            int startRow = (pageIndex * pageSize) + 1;
            int totalRecords = count;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            if (test == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new
                {
                    total = totalPages,
                    page = pageIndex,
                    records = count,
                    rows = test.Select(x => new
                    {
                        x.Sno,
                        x.Code,
                        x.DCCode,
                        x.Qty,
                        x.Unit,
                        x.Qty2,
                        x.Unit2,
                        x.Rate,
                        x.RatePer,
                        x.Disc,
                        x.DiscAmt
                    }
                    ).ToArray()
                           .Select(x => new
                           {
                               id = x.Sno,
                               cell = new string[] {
                              
                                    x.Sno.ToString(),
                                    x.Code,
                                    x.DCCode,
                                    Convert.ToString(x.Qty),
                                    Convert.ToString(x.Unit) ,
                                    Convert.ToString(x.Qty2),
                                    x.Unit2,
                                   Convert.ToString(x.Rate),
                                   Convert.ToString(x.RatePer),
                                   Convert.ToString(x.Disc),
                                   Convert.ToString( x.DiscAmt)
                               }
                           }
                                  ).ToArray()
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public void EditRecords(Stock postData, FormCollection collection, DataTable DtTbl)
        {
            try
            {
                List<Stock> test = new List<Stock>();
                if (collection["oper"] == "edit")
                {

                    collection.Remove("oper");
                    string id = collection["id"];
                    var EditRecord =
                    test.Where(x => x.Sno == id).SingleOrDefault();
                    test.Remove(EditRecord);
                    test.Add(postData);
                    Session["postData"] = test;
                    GetRecords("", "asc", 1, 100, true);

                }
                else if (collection["oper"] == "add" && postData.Code != null)
                {

                    try
                    {
                        postData.RecordKey = 0;
                        postData.AccPeriod = "";
                        postData.AddTax = 0; 
                        postData.Amt=121;
                        postData.aSurcharge=0;
                        postData.Audited=true;
                        postData.AuthIds="";
                        postData.Authorise="";
                        postData.Sno = "1"; 
        postData. Batch="";
        postData.BCD=0;
        postData.BCDAmt=0;
       postData. BillDate=System.DateTime.Now;
        postData. BillNumber="";
        postData. BOMSrl ="";
        postData. Branch ="";
        postData.Cess =0;
        postData.ChlnDate = System.DateTime.Now;
        postData.ChlnNumber ="";
        postData.Code = postData.Code;
        postData.cRate =0;
        postData. CurrName ="";
        postData.CurrRate =0;
        postData. DCCode ="";
        postData.Disc =0;
        postData.DiscAmt =0;
        postData.Discount =0;
        postData. Division ="";
        postData.DocDate = System.DateTime.Now;
        postData. Excisable =true;
        postData.ExciseAs =0;
        postData. ExcUnits ="";
        postData. Factor =0;
        postData. FirstSno =;
        postData. FreeQty ="";
        postData. Fvalue ="";
        postData. GINNumber ="";
        postData. HWSerial ="";
        postData. HWSerial2 ="";
        postData. IndNumber ="";
        postData. IsChargeable = "";
        postData. IsReturnable ="";
        postData. IssueNo ="";
        postData. MainType ="";
        postData. Narr ="";
        postData.NewRate ="";
        postData.NewRateEntry ="";
        postData.NewRateLink ="";
        postData. NotInStock ="";
        postData.oDuty1 ="";
        postData.oDuty2 ="";
        postData.oDuty3 ="";
        postData.oDutyAmt1 ="";
        postData.oDutyAmt2 ="";
        postData.oDutyAmt3 ="";
       postData. OrdDate ="";
        postData. OrdNumber ="";
        postData. Party ="";
        postData. PCCode ="";
        postData.Pending ="";
        postData.Pending2 ="";
        postData. PeriodCode ="";
        postData. PerUnit ="";
        postData.pQty ="";
        postData. Prefix ="";
        postData. ProcessCode ="";
        postData. ProjectCode ="";
        postData. ProjectStage ="";
        postData. ProjectUnit ="";
        postData. QCDone ="";
        postData. QCIssued ="";
        postData.QCQty ="";
        postData. QCRequire ="";
        postData.Qty ="";
        postData.Qty2 ="";
        postData. QtyEqsn ="";
        postData.Rate ="";
        postData.RateOn ="";
        postData.RatePer ="";
        postData. ReasonCode ="";
        postData. RouteCode ="";
        postData.SHECess ="";
        postData.SHECessAmt ="";
        postData. Sno ="";
        postData. Srl ="";
        postData.Stage ="";
        postData.STAmt ="";
        postData.STaxable ="";
        postData.STCess ="";
        postData. STCode ="";
        postData. Store ="";
        postData.STSheCess ="";
        postData. SubType ="";
        postData. SuppInvoice ="";
        postData.SurCharge ="";
        postData.Taxable ="";
        postData.TaxAmt ="";
        postData. TaxCode ="";
        postData. Type ="";
        postData. Unit ="";
        postData. Unit2 ="";
        postData. WasteFlag ="";
        postData.Weightage ="";
        postData. WONumber ="";
        postData.TOUCHVALUE ="";
        postData. EnteredBy ="";
      
                        postData.Code = postData.Code;
                        postData.DCCode = postData.DCCode;
                        postData.Qty = postData.Qty;
                        postData.Unit = postData.Unit;
                        postData.Qty2 = postData.Qty2;
                        postData.Unit2 = postData.Unit2;
                        postData.Code = postData.Code;
                        postData.Rate = postData.Rate;
                        postData.RatePer = postData.RatePer;
                        postData.Disc = postData.Disc; ;
                        postData.DiscAmt = postData.DiscAmt;
                        postData.OrdDate = System.DateTime.Now;
                        postData.OrdNumber = postData.OrdNumber;
                        postData.PCCode = postData.PCCode;
                        postData.Pending = postData.Pending;
                        postData.Pending2 = postData.Pending2;
                        postData.PeriodCode = postData.PeriodCode;
                        postData.PerUnit = postData.PerUnit;
                        postData.Prefix = postData.Prefix;
                        postData.ProcessCode = postData.ProcessCode;
                        postData.ProjectCode = postData.ProjectCode;
                        postData.ProjectStage = postData.ProjectStage;
                        postData.ProjectUnit = postData.ProjectUnit;
                        postData.QCDone = postData.QCDone;
                        postData.QCIssued = postData.QCIssued;
                        postData.QCQty = postData.QCQty;
                        postData.QCRequire = postData.QCRequire;
                        postData.QtyEqsn = postData.QtyEqsn;
                        postData.RateOn = postData.RateOn;



                        postData.EnteredBy = "";
                        DataRow Drow = DtTbl.NewRow();
                        if (Session.Count != 0)
                        {
                            test = Session["postData"] as List<Stock>;
                        }
                        else
                        {
                            test = new List<Stock>();
                        }
                        test.Add(postData);
                        Session["postData"] = test;
                        GetRecords("", "asc", 1, 100, true);

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);

                    }
                }
                else if (postData.Sno == null)
                {
                    string[] rowid = { collection["id"] };
                    string csvString = string.Join(",", rowid);
                    foreach (var id in csvString)
                    {
                        var DeleteRecord =
                        test.Where(x => x.Sno == Convert.ToString(id)).SingleOrDefault();
                        test.Remove(DeleteRecord);
                    }
                    Session["postData"] = test;
                    GetRecords("", "asc", 1, 100, true);
                }
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
