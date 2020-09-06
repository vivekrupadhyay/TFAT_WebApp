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
using System.Linq.Expressions.Internal;
using System.Linq.Expressions;
using System.Data;
using System.Web.Script.Serialization;

namespace TFATERPWebApplication.Controllers
{
    public class SalesController : Controller
    {
        Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();
        SalesModel sales = new SalesModel();
        public ActionResult Index(SalesModel sale)
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            ViewBag.TableName = "TFatBranch";
            ViewBag.TfatCity = "TfatCity";
            ViewBag.TfatComp = "TfatComp";
          //  sales.TfatBranchName = "TFatBranch";
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        public ActionResult SaveData(SalesModel sale)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddRecord()
        {
            List<SelectListItem> li = new List<SelectListItem>();

            foreach (var cat in ctx.TfatComps.ToList())
            {
                li.Add(new SelectListItem { Text = cat.Name, Value = cat.Code });
            }

            ViewData["Category"] = li;
            ViewBag.TableName = "TFatBranch";

            return PartialView();
        }
        [HttpPost]
        public ActionResult AddRecord(StockModel postData, DataTable DtTbl)
        {
            try
            {
                List<StockModel> test = new List<StockModel>();

                postData.Sno = postData.Sno;
                postData.Code = postData.Code;
                postData.DCCode = postData.DCCode;
                postData.Qty = postData.Qty;
                postData.Unit = postData.Unit;
                postData.Qty2 = postData.Qty2;
                postData.Unit2 = postData.Unit2;
                postData.Code = postData.Code;
                postData.Rate = postData.Rate;
                postData.RatePer = postData.RatePer;
                postData.Disc = postData.Disc;
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
                    test = Session["postData"] as List<StockModel>;
                }
                else
                {
                    test = new List<StockModel>();
                }
                test.Add(postData);
                Session["postData"] = test;
                GetRecords("", "asc", 1, 100, true);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);

            }
            List<SelectListItem> li = new List<SelectListItem>();

            foreach (var cat in ctx.TfatComps.ToList())
            {
                li.Add(new SelectListItem { Text = cat.Name, Value = cat.Code });
            }

            ViewData["Category"] = li;
            ViewBag.TableName = "TFatBranch";

            return PartialView();
        }

        public ActionResult Edit(string Id)
        {

            StockModel model = new StockModel();
            List<StockModel> test;

            if (Session.Count != 0)
            {
                test = Session["postData"] as List<StockModel>;
                var result = test.FirstOrDefault(u => u.Sno == Id);
                return PartialView(result);
            }
            else
            {
                test = new List<StockModel>();
            }

            return PartialView();
        }
        [HttpPost]
        public ActionResult Edit(StockModel postData)
        {
            List<StockModel> test;

            if (Session.Count != 0)
            {
                test = Session["postData"] as List<StockModel>;
                var result = test.FirstOrDefault(u => u.Sno == postData.Sno);
                test.Remove(result);

                  
             //   List<StockModel> test = new List<StockModel>();

                result.Sno = postData.Sno;
                result.Code = postData.Code;
                result.DCCode = postData.DCCode;
                result.Qty = postData.Qty;
                result.Unit = postData.Unit;
                result.Qty2 = postData.Qty2;
                result.Unit2 = postData.Unit2;
              //  result.Code = postData.Code;
                result.Rate = postData.Rate;
                result.RatePer = postData.RatePer;
                result.Disc = postData.Disc;
                result.DiscAmt = postData.DiscAmt;
                result.OrdDate = System.DateTime.Now;
                result.OrdNumber = postData.OrdNumber;
                result.PCCode = postData.PCCode;
                result.Pending = postData.Pending;
                result.Pending2 = postData.Pending2;
                result.PeriodCode = postData.PeriodCode;
                result.PerUnit = postData.PerUnit;
                result.Prefix = postData.Prefix;
                result.ProcessCode = postData.ProcessCode;
                result.ProjectCode = postData.ProjectCode;
                result.ProjectStage = postData.ProjectStage;
                result.ProjectUnit = postData.ProjectUnit;
                result.QCDone = postData.QCDone;
                result.QCIssued = postData.QCIssued;
                result.QCQty = postData.QCQty;
                result.QCRequire = postData.QCRequire;
                result.QtyEqsn = postData.QtyEqsn;
                result.RateOn = postData.RateOn;
                result.EnteredBy = "";
               // DataRow Drow = DtTbl.NewRow();
                if (Session.Count != 0)
                {
                    test = Session["postData"] as List<StockModel>;
                }
                else
                {
                    test = new List<StockModel>();
                }
              //  test.Add(postData);
             //   Session["postData"] = result;
             //   GetRecords("", "asc", 1, 100, true);

               //  var EditRecord =
                 //   test.Where(x => x.Sno == id).SingleOrDefault();
               
                 test.Add(result);
                 TempData.Remove("result");
                 Session["postData"] = test;
                 GetRecords("", "asc", 1, 100, true);

               // return PartialView(result);
            }
            return PartialView();
        }

        //public ActionResult Delete(string Id)
        //{
        //    List<StockModel> test = new List<StockModel>();
           
        //    string[] rowid = { Id };
        //    string csvString = string.Join(",", rowid);
        //    foreach (var id in csvString)
        //    {
        //        test = Session["postData"] as List<StockModel>;
        //        var DeleteRecord =
        //        test.Where(x => x.Sno == Convert.ToString(id)).SingleOrDefault();
        //        test.Remove(DeleteRecord);
        //    }
        //    Session["postData"] = test;
        //   // GetRecords("", "asc", 1, 100, true);

        //    RedirectToAction("Index");
        //}

        //#region
        ////Code for DropDown
        //public ActionResult PopulateDropDown()
        //{
        //    SalesModel model = new SalesModel();
        //    List<SelectListItem> ls = new List<SelectListItem>();
        //    model.AddressList = (from m in model.AddressList where m.Sno == "1" select new { m.Sno, m.Name }); 

        //    foreach(var temp in model.AddressList )
        //    {
        //        ls.Add(new SelectListItem() { Text = temp.Sno, Value = temp.Name.ToString() });

        //    }
        //    return View(ls);

        //}

        //#endregion
        #region Plant Autocomplete
        [HttpPost]
        public JsonResult AutocompleteName(string id, string name)
        {
            var TblSet = Core.CoreCommon.GetTableData(id);
            var output = TblSet.AsQueryable().ToListAsync().Result.ToList();
            Dal.TFAT_WEBERPEntities context = new Dal.TFAT_WEBERPEntities();
            return Json(from m in output
                        where m.GetType().GetProperty("Name").GetValue(m).ToString().Contains(name)
                        select m.GetType().GetProperty("Name").GetValue(m).ToString());
        }
        [HttpPost]
        public JsonResult AutocompleteCode(string id, string code)
        {
            var TblSet = Core.CoreCommon.GetTableData(id);
            var output = TblSet.AsQueryable().ToListAsync().Result.ToList();
            return Json(from m in output
                        where m.GetType().GetProperty("Code").GetValue(m).ToString().Contains(code)
                        select m.GetType().GetProperty("Code").GetValue(m).ToString());
        }
        [HttpPost]
        public ActionResult GetCodeName(string id, string codeName, string mPara)
        {
            var TblSet = Core.CoreCommon.GetTableData(id);
            var output = TblSet.AsQueryable().ToListAsync().Result.ToList();
            Dal.TFAT_WEBERPEntities context = new Dal.TFAT_WEBERPEntities();
            string UserName = "";
            if (mPara == "C")
            {
                var query = (from m in output
                             where m.GetType().GetProperty("Code").GetValue(m).ToString().Contains(codeName)
                             select m.GetType().GetProperty("Name").GetValue(m).ToString());
                if (query != null)
                {
                    UserName = query.First().ToString();
                }
            }
            else
            {
                var query = (from m in output
                             where m.GetType().GetProperty("Name").GetValue(m).ToString().Contains(mPara)
                             select m.GetType().GetProperty("Code").GetValue(m).ToString());
                if (query != null)
                {
                    UserName = query.First().ToString();
                }
            }
            return Content(UserName);
        }
        #endregion
        #region
        //charges
        //Get Charges
        public ActionResult Charges(ChargesModel model)
        {
            Charge charge = ctx.Charges.Find();
            var newCharge = new Charge();
            newCharge.Fld = model.Fld;
            newCharge.Equation = model.Equation;
            newCharge.Head = model.Head;
            if (ModelState.IsValid)
            {
                ctx.Entry(charge).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            if (charge == null)
            {
                return HttpNotFound();
            }
            // ViewData["result"] = model;
            return View(model);
        }
        #endregion
        #region


        #endregion
        #region
        //Display Grid Data
        [HttpGet]
        public JsonResult GetRecords(string sidx, string sord, int page, int rows, bool _search)
        {
            List<StockModel> test;
            if (Session.Count != 0)
            {
                test = Session["postData"] as List<StockModel>;
            }
            else
            {
                test = new List<StockModel>();
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
                        x.DiscAmt,
                        x.TotalDisc,
                        x.Value,
                        x.Narr,
                        x.OrdNumber,
                        x.VenderID
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
                                   Convert.ToString( x.DiscAmt),
                                   Convert.ToString( x.Value),
                                   Convert.ToString( x.Narr),
                                   Convert.ToString( x.OrdNumber),
                                   Convert.ToString( x.VenderID)
                               }
                           }
                                  ).ToArray()
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
      //  [AcceptVerbs(HttpVerbs.Post)]
        public void EditRecords(StockModel postData, FormCollection collection, DataTable DtTbl)
        {
            try
            {
                List<StockModel> test = Session["postData"] as List<StockModel>;
                //if (collection["oper"] == "edit")
                //{

                //    collection.Remove("oper");
                //    string id = collection["id"];
                //    var EditRecord =
                //    test.Where(x => x.Sno == id).SingleOrDefault();
                //    test.Remove(EditRecord);
                //    test.Add(postData);
                //    TempData.Remove("EditRecord");
                //    Session["postData"] = test;
                //    GetRecords("", "asc", 1, 100, true);
                //}
                //else if (collection["oper"] == "add" && postData.Code != null)
                //{
                //    try
                //    {
                //        postData.Sno = postData.Sno;
                //        postData.Code = postData.Code;
                //        postData.DCCode = postData.DCCode;
                //        postData.Qty = postData.Qty;
                //        postData.Unit = postData.Unit;
                //        postData.Qty2 = postData.Qty2;
                //        postData.Unit2 = postData.Unit2;
                //        postData.Code = postData.Code;
                //        postData.Rate = postData.Rate;
                //        postData.RatePer = postData.RatePer;
                //        postData.Disc = postData.Disc; ;
                //        postData.DiscAmt = postData.DiscAmt;
                //        postData.OrdDate = System.DateTime.Now;
                //        postData.OrdNumber = postData.OrdNumber;
                //        postData.PCCode = postData.PCCode;
                //        postData.Pending = postData.Pending;
                //        postData.Pending2 = postData.Pending2;
                //        postData.PeriodCode = postData.PeriodCode;
                //        postData.PerUnit = postData.PerUnit;
                //        postData.Prefix = postData.Prefix;
                //        postData.ProcessCode = postData.ProcessCode;
                //        postData.ProjectCode = postData.ProjectCode;
                //        postData.ProjectStage = postData.ProjectStage;
                //        postData.ProjectUnit = postData.ProjectUnit;
                //        postData.QCDone = postData.QCDone;
                //        postData.QCIssued = postData.QCIssued;
                //        postData.QCQty = postData.QCQty;
                //        postData.QCRequire = postData.QCRequire;
                //        postData.QtyEqsn = postData.QtyEqsn;
                //        postData.RateOn = postData.RateOn;
                //        postData.EnteredBy = "";
                //        DataRow Drow = DtTbl.NewRow();
                //        if (Session.Count != 0)
                //        {
                //            test = Session["postData"] as List<StockModel>;
                //        }
                //        else
                //        {
                //            test = new List<StockModel>();
                //        }
                //        test.Add(postData);
                //        Session["postData"] = test;
                //        GetRecords("", "asc", 1, 100, true);

                //    }
                //    catch (Exception ex)
                //    {
                //        Debug.WriteLine(ex.StackTrace);

                //    }
                //}
                if (postData.Sno == null)
                {
                   // TempData["Sno"] = Sno;
                    string[] rowid = { collection["id"] };
                    string csvString = string.Join(",", rowid);

                    string[] words = csvString.Split(',');

                    if (words != null)
                    {
                        foreach (var id in words)
                        {
                            var DeleteRecord =
                            test.Where(x => x.Sno == Convert.ToString(id)).FirstOrDefault();
                            if (DeleteRecord != null)
                            {
                                test.Remove(DeleteRecord);
                            }
                        }
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
      //  fill Dynamic GridView
        public ActionResult Category()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (var cat in ctx.TfatComps.ToList())
            {
                d.Add(cat.Code, cat.Name);
            }
            return Json(d, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDestinationList()
        {
            var li = from s in ctx.TfatComps
                     select new
                     {
                         Per = s.Name
                     };
            //return new  JavaScriptSerializer().Serialize(li));
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult AutocompleteBranch(string term)
        {

            //IEnumerable<PartialModel> modelList = new List<PartialModel>();
            Dal.TFAT_WEBERPEntities context = new Dal.TFAT_WEBERPEntities();

            return Json(context.TFatBranches.Where(x => x.Code.Contains(term)).Select(s => s.Code).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCodeNames(string codeName, string mPara)
        {
            string UserName = "";
            if (mPara == "C")
            {
                var query = (from u in ctx.TFatBranches
                             where u.Code.ToLower() == codeName.ToLower()
                             select u.Name).SingleOrDefault();
                if (query != null)
                {
                    UserName = query;
                }
            }
            else
            {
                var query = (from u in ctx.TFatBranches
                             where u.Name.ToLower() == codeName.ToLower()
                             select u.Code).SingleOrDefault();
                if (query != null)
                {
                    UserName = query;
                }
            }
            return Json(UserName, JsonRequestBehavior.AllowGet);
        }
        public string XGetCalData(string mPrcType, long mAmount)
        {
            GeneralFunCls ms = new GeneralFunCls();
            string mData = ms.FieldOfTable("Master1", "", "", mPrcType);
            string mStrData = ms.CalculateTax(mData, mAmount);
            return mStrData;
        }
       // #endregion
    }
}




