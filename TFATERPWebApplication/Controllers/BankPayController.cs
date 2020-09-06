using iTextSharp.text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Models;

namespace TFATERPWebApplication.Controllers
{
    public class BankPayController : Controller
    {
        TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();

        IListViewGridOperation mIlst = new ListViewGridOperation();
        IBusinessCommon mIBuss = new BusinessCommon();


        //
        // GET: /BankPay/

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
            

            List<TempLedgerBranch> test;
            if (Session.Count != 0)
            {
                test = Session["postData"] as List<TempLedgerBranch>;
            }
            else
            {
                test = new List<TempLedgerBranch>();
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
                        x.Branch,
                        x.BankCode,
                        SubLdgr = x.Code,
                        x.Debit,
                        x.Credit,
                        x.CostCentre,
                        ProfitCenter = x.Code,
                        x.Cheque,
                        x.Narr
                    }
                    ).ToArray()
                           .Select(x => new
                           {
                               id = x.Sno,
                               cell = new string[] { x.Sno.ToString(),

                                                        x.Code,
                                                        x.Branch,  
                                                        x.BankCode,
                                                        x.Code,
                                                        Convert.ToString(x.Debit),
                                                        Convert.ToString(x.Credit),
                                                        x.CostCentre,
                                                        x.Code,
                                                        x.Cheque,
                                                        x.Narr
                                                      }
                           }
                                  ).ToArray()
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        } 

        private string[] GetStringArrFromDataTable(string p, int HeaderId, string IDKey, DataTable Dt)
        {
            var DHeader = ctx.TfatDesignHeaders.Single(h => h.HeaderRecordKey == HeaderId);
            var DForms = DHeader.TfatDesignForms.Where(f => f.TabName.ToUpper().Equals("GRID")).OrderBy(f => Math.Abs(Convert.ToDecimal(f.DisplayOrder)));
            int frmcount = DForms.Count();

            var resultDB = from mDt in Dt.AsEnumerable()
                           where mDt.Field<dynamic>(IDKey) == p
                           select mDt;

            string[] col = new string[frmcount];

            foreach (var colfrm in resultDB)
            {
                int i = 0;
                foreach (TfatDesignForm frm in DForms)
                {
                    col[i] = Convert.ToString(colfrm.Field<dynamic>(frm.Fld));
                    i++;
                }
            }



            return col;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void EditRecords(TempLedgerBranch postData, FormCollection collection, DataTable DtTbl)
        {
            //  if (ModelState.IsValid)
            //{
           
            try
            {
                List<TempLedgerBranch> test = new List<TempLedgerBranch>();
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
                        //collection.Remove("oper");
                        //    collection.Remove("id");
                        postData.RecordKey = 0;
                        postData.UserId = "1";
                        postData.AccPeriod = "";
                        postData.Audited = true;
                        postData.AuthIds = "";
                        postData.Authorise = "";
                        postData.BankCode = postData.BankCode;
                        postData.BillDate = System.DateTime.Now;
                        postData.BillNo = "333";
                        postData.Branch = postData.Branch;
                        postData.Cheque = postData.Cheque;
                        postData.ChequeReturn = true;
                        postData.ChqCategory = 12;
                        postData.ClearDate = System.DateTime.Now;
                        postData.Code = postData.Code;
                        postData.CostCentre = postData.CostCentre;
                        postData.Credit = postData.Credit;
                        postData.CurrAmount = 124;
                        postData.CurrName = "Dipti";
                        postData.CurrRate = 154;
                        postData.Debit = postData.Debit;
                        postData.DocDate = System.DateTime.Now;
                        postData.HWSerial = "";
                        postData.MainType = "";
                        postData.Narr = postData.Narr;
                        postData.OSAdj = "";
                        postData.Party = "";
                        postData.PCCode = "";
                        postData.PeriodCode = "";
                        postData.Prefix = "";
                        postData.ProjectCode = "";
                        postData.ProjectStage = "";
                        postData.ProjectUnit = "";
                        postData.RecoFlag = "";
                        postData.RefDoc = "";
                        postData.SLCode = "";
                        postData.Sno = postData.Sno;
                        postData.Srl = "";
                        postData.SubType = "";
                        postData.TDSCode = "";
                        postData.TDSFlag = false;
                        postData.TouchValue = 1;
                        postData.Type = "";
                        postData.ValueDate = System.DateTime.Now;
                        postData.xBranch = "";
                        postData.EnteredBy = "";
                        postData.LastUpdateDate = System.DateTime.Now;
                        postData.HWSERIAL2 = "";

                        DataRow Drow = DtTbl.NewRow();
                       
                       
                        if (Session.Count != 0)
                        {
                            test = Session["postData"] as List<TempLedgerBranch>;
                        }
                        else
                        {
                            test = new List<TempLedgerBranch>();
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
                else if (postData.Branch == null)
                {
                    string[] rowid = {collection["id"]};
                    string csvString = string.Join(",", rowid);
                    foreach (var id in csvString)
                    {
                        var DeleteRecord =
                        test.Where(x => x.Sno == Convert.ToString(id)).SingleOrDefault();
                        test.Remove(DeleteRecord);
                    }
                    Session["postData"] = test;
                    GetRecords("", "asc", 1, 100, true);
                    //ctx.SaveChanges();

                }
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
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
    }
}