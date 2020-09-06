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

    public class frmMfgBomController : Controller
    {
        Dal.TFAT_WEBERPEntities ctx = new Dal.TFAT_WEBERPEntities();

        mfgBomGenInfModel model = new mfgBomGenInfModel();
        public ActionResult Index()
        {
            //TempData["sno"] = "";
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            ViewBag.Message = "0.0";
            ViewBag.Titles = "0";
            ViewBag.Msg = "0.00-0.00";
            ViewBag.Data = "Hourly Mfg. Quantities:(Good Qty)";
            ViewBag.mfgRejection = "Rejection Quantities:";
            ViewBag.LostTime = "LostTime";
            ViewBag.UnitMaster1 = ctx.UnitMaster1.ToList();
            ViewBag.ReasonMaster = ctx.ReasonMaster1.ToList();
            ViewBag.Codelist = ctx.Stocks.ToList();
            ViewBag.itemMaster = "ItemMaster1";
            ViewBag.Store = "Stores1";

            return View();
        }
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
            string unitdata = "";
            if (mPara == "C")
            {

                var query = (from m in output
                             where m.GetType().GetProperty("Code").GetValue(m).ToString().Contains(codeName)
                             select m.GetType().GetProperty("Name").GetValue(m).ToString());
                if (id == "ItemMaster1")
                {
                    var query1 = (from m in output
                                  where m.GetType().GetProperty("Code").GetValue(m).ToString().Contains(codeName)
                                  select m.GetType().GetProperty("Unit").GetValue(m).ToString());
                    if (query1 != null)
                    {
                        unitdata = query1.First().ToString();
                    }
                }
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
            return Json(new { UserName, unitdata });
            // return Content(UserName);
        }
        #endregion
        [HttpGet]
        public ActionResult addrecord()
        {
            List<SelectListItem> li = new List<SelectListItem>();

            foreach (var cat in ctx.ReasonMaster1.ToList())
            {
                li.Add(new SelectListItem { Text = cat.Name, Value = cat.Code });
            }

            List<SelectListItem> unitlist = new List<SelectListItem>();

            foreach (var cat in ctx.ItemMaster1.ToList())
            {
                unitlist.Add(new SelectListItem { Text = cat.Unit, Value = cat.Name });
            }
            ViewBag.Reason = li;
            ViewBag.ReasonMaster = "ReasonMaster1";
            ViewBag.itemMaster = "ItemMaster1";
            ViewBag.Process = "ProcessMas1";
            ViewBag.Store = "Stores1";
            ViewBag.PerUnit = unitlist;
            List<BomMaterialModel> test;
            if (Session.Count != 0)
            {
                test = Session["postData"] as List<BomMaterialModel>;
                string max = test.Max(p => p.Sno);
                ViewBag.Sno = max + 1;

            }
            else
            {
                ViewBag.Sno = 1;
            }

            return PartialView();

        }
        [HttpPost]
        public ActionResult addrecord(BomMaterialModel postdata, DataTable dttbl)
        {

            try
            {
                List<BomMaterialModel> test = new List<BomMaterialModel>();
                postdata.Sno = TempData["sno"].ToString();
                postdata.Code = postdata.txtCode1_itemMaster;
                postdata.Name = postdata.txtName1_itemMaster;
                postdata.Stock = "0.00";
                postdata.Substitute = "";
                postdata.Partial = "0.00";
                if (postdata.QuantityHiddn == "Mfg")
                {
                    postdata.MfgQty = postdata.Qty;
                }
                else if (postdata.QuantityHiddn == "Loss n Scrap")
                {
                    postdata.loss = postdata.Qty;
                }
                else if (postdata.QuantityHiddn == "waste")
                {
                    postdata.wastage = postdata.Qty;
                }
                else
                {
                    postdata.Consumed = postdata.Qty;
                }
                postdata.Rate = postdata.Rate;

                postdata.StoreCode = postdata.StoreCode;
                postdata.Description = postdata.Description;
                postdata.RatePer = postdata.RatePer;
                postdata.ReasonType = postdata.ReasonType;
                postdata.Narration = postdata.Narration;
                postdata.Value = postdata.Value;
                postdata.Unit = postdata.Unit;
                DataRow drow = dttbl.NewRow();
                if (Session.Count != 0)
                {
                    test = Session["postdata"] as List<BomMaterialModel>;
                }
                else
                {
                    test = new List<BomMaterialModel>();
                }
                test.Add(postdata);
                Session["postdata"] = test;
                GetRecords("", "asc", 1, 100, true);
                List<SelectListItem> list = new List<SelectListItem>();

                foreach (var cat in ctx.ReasonMaster1.ToList())
                {
                    list.Add(new SelectListItem { Text = cat.Name, Value = cat.Code });
                }

                List<SelectListItem> unitlist = new List<SelectListItem>();

                foreach (var cat in ctx.ItemMaster1.ToList())
                {
                    unitlist.Add(new SelectListItem { Text = cat.Unit, Value = cat.Name });
                }
                ViewBag.Reason = list;
                ViewBag.itemMaster = "ItemMaster1";
                ViewBag.Process = "ProcessMas1";
                ViewBag.Store = "Stores1";
                ViewBag.ReasonMaster = "ReasonMaster1";

                ViewBag.PerUnit = unitlist;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);

            }
            List<SelectListItem> li = new List<SelectListItem>();

            foreach (var cat in ctx.ItemMaster1.ToList())
            {
                li.Add(new SelectListItem { Text = cat.Name, Value = cat.Code });
            }
            ViewData["category"] = li;
            ModelState.Clear();
            return PartialView();
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            BomMaterialModel model = new BomMaterialModel();
            List<BomMaterialModel> test;
            if (Session.Count != 0)
            {
                test = Session["postData"] as List<BomMaterialModel>;
                var result = test.FirstOrDefault(u => u.Sno == Id);
                List<SelectListItem> li = new List<SelectListItem>();

                foreach (var cat in ctx.ReasonMaster1.ToList())
                {
                    li.Add(new SelectListItem { Text = cat.Name, Value = cat.Code });
                }

                List<SelectListItem> unitlist = new List<SelectListItem>();

                foreach (var cat in ctx.ItemMaster1.ToList())
                {
                    unitlist.Add(new SelectListItem { Text = cat.Unit, Value = cat.Name });
                }
                ViewBag.Reason = li;
                ViewBag.itemMaster = "ItemMaster1";
                ViewBag.Process = "ProcessMas1";
                ViewBag.Store = "Stores1";
                ViewBag.ReasonMaster = "ReasonMaster1";
                ViewBag.PerUnit = unitlist;

                return PartialView(result);
            }
            else
            {
                test = new List<BomMaterialModel>();
            }

            return PartialView();
        }
        [HttpPost]
        public ActionResult Edit(string QuantityHiddn, BomMaterialModel postdata)
        {
            List<BomMaterialModel> test;
            if (Session.Count != 0)
            {
                test = Session["postData"] as List<BomMaterialModel>;
                var result = test.FirstOrDefault(u => u.Sno == postdata.Sno);
                test.Remove(result);
                result.Sno = postdata.Sno;
                result.Code = postdata.txtCode1_itemMaster;
                result.Name = postdata.txtName1_itemMaster;
                result.Stock = "0.00";
                result.Substitute = "";
                if (postdata.QuantityHiddn == "Mfg")
                {
                    postdata.MfgQty = postdata.Qty;
                }
                else if (postdata.QuantityHiddn == "Loss n Scrap")
                {
                    postdata.loss = postdata.Qty;
                }
                else if (postdata.QuantityHiddn == "waste")
                {
                    postdata.wastage = postdata.Qty;
                }
                else
                {
                    postdata.Consumed = postdata.Qty;
                }
                result.Rate = postdata.Rate;
                result.RatePer = postdata.RatePer;
                result.StoreCode = postdata.StoreCode;
                result.Description = postdata.Description;
                result.RatePer = postdata.RatePer;
                result.ReasonType = postdata.ReasonType;
                result.ProductDesc = postdata.ProductDesc;
                result.Value = postdata.Value;
                result.Narration = postdata.Narration;
                result.Unit = postdata.Unit;
                if (Session.Count != 0)
                {
                    test = Session["postData"] as List<BomMaterialModel>;
                }
                else
                {
                    test = new List<BomMaterialModel>();
                }
                test.Add(result);
                TempData.Remove("result");
                Session["postData"] = test;
                GetRecords("", "asc", 1, 100, true);

                List<SelectListItem> li = new List<SelectListItem>();

                foreach (var cat in ctx.ReasonMaster1.ToList())
                {
                    li.Add(new SelectListItem { Text = cat.Name, Value = cat.Code });
                }

                List<SelectListItem> unitlist = new List<SelectListItem>();

                foreach (var cat in ctx.ItemMaster1.ToList())
                {
                    unitlist.Add(new SelectListItem { Text = cat.Unit, Value = cat.Name });
                }
                ViewBag.Reason = li;
                ViewBag.TableName = "ReasonMaster1";
                ViewBag.itemMaster = "ItemMaster1";
                ViewBag.Process = "ProcessMas1";
                ViewBag.Store = "Stores1";
                ViewBag.PerUnit = unitlist;
            }
            return RedirectToAction("Index");
        }
        //AutoComplete
        public JsonResult Autocomplete(string term)
        {

            //IEnumerable<PartialModel> modelList = new List<PartialModel>();
            Dal.TFAT_WEBERPEntities context = new Dal.TFAT_WEBERPEntities();

            return Json(context.MfgQuantities.Where(x => x.Type.Contains(term)).Select(s => s.Type).ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetRecords(string sidx, string sord, int page, int rows, bool _search)
        {
            List<BomMaterialModel> test;
            if (Session.Count != 0)
            {
                test = Session["postData"] as List<BomMaterialModel>;
            }
            else
            {
                test = new List<BomMaterialModel>();
            }
            var count = test == null ? 0 : test.Count;
            int pageIndex = page;
            int pageSize = rows;
            int totalRecords = count;
            TempData["sno"] = count + 1;
            ViewBag.Sno = count + 1;
            int startRow = (pageIndex * pageSize) + 1;
            //  int totalRecords = count;
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
                        x.Name,
                        x.Stock,
                        x.Substitute,
                        x.Partial,
                        x.MfgQty,
                        x.Consumed,
                        x.wastage,
                        x.loss,
                        x.StoreCode,
                        x.Rate,
                        x.Unit,
                        x.PerUnit,
                        x.Value,
                        x.Narration,
                        //x.ReasonType,

                    }
                    ).ToArray()
                           .Select(x => new
                           {
                               id = x.Sno,
                               cell = new string[] {
                                    x.Sno,
                                    x.Code,
                                    x.Name,
                                    x.Stock,
                                    x.Substitute,
                                    x.Partial,
                                    x.MfgQty,
                                    x.Consumed,
                                    x.wastage,
                                    x.loss,
                                    x.StoreCode,
                                    Convert.ToString(x.Rate),
                                     x.Unit,
                                    Convert.ToString( x.PerUnit),
                                     Convert.ToString(x.Value),
                                    x.Narration
                                   
                                    //x.ReasonType,
                                    
                                    
                                       
                               }
                           }
                                  ).ToArray()
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public void EditRecords(BomMaterialModel postData, FormCollection collection, DataTable DtTbl)
        {
            //  if (ModelState.IsValid)
            //{

            try
            {
                List<BomMaterialModel> test = Session["postData"] as List<BomMaterialModel>;

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

        //Mfg_Parameter Vivek
        [HttpGet]
        public ActionResult EditMfgParameter(string Id)
        {
            BomMfgParameter mfgparm = new BomMfgParameter();
            //List<BomMfgParameter> test;

            return View();
        }
        [HttpPost]
        public ActionResult EditMfgParameter(BomMfgParameter postdata)
        {
            List<BomMfgParameter> test;
            //if (Session.Count != 0)
            //{

            test = Session["postData"] as List<BomMfgParameter>;
            int recordID = Convert.ToInt32(postdata.Para);
            var result = ctx.MachineParameters.FirstOrDefault(u => u.RecordKey == recordID);
            if (result != null)
            {
                result.uValue = postdata.UpperLimit;
                result.lValue = postdata.LowerLimit;
                result.Unit = postdata.Unit;
                //   result.Value = postdata.Value;
                ctx.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult mfgParameter()
        {
            TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

            return View("Index", ctx.MachineParameters.ToList());

        }

        [HttpGet]
        public JsonResult Getmfg_Parameter()//string sidx, string sord, int page, int rows, bool _search
        {
            var result = new
               {

                   rows = ctx.MachineParameters.Select(x => new
                   {
                       Para = x.Para,
                       x.Default,
                       Unit = x.Unit,
                       UpperLimit = x.uValue,
                       LowerLimit = x.lValue,
                   }).ToArray()
                          .Select(x => new
                          {
                              id = x.Para,
                              cell = new string[] {
                                Convert.ToString( x.Para) ,
                                    x.Default ,
                                    x.Unit,
                                    x.UpperLimit,
                                    x.LowerLimit 
                                   
                               }
                          }).ToArray()
               };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Mfg Quantity
        public JsonResult Getmfg_Quantity()//string sidx, string sord, int page, int rows, bool _search
        {
            var result = new
            {

                rows = ctx.MfgQuantities.Select(x => new
                {
                    x.Sno,
                    x.Srl,
                    x.Qty,
                    x.GrossWt,
                    x.NetWt,
                    x.TimeFrom,
                    x.TimeTo,
                    x.Qty2,
                    x.Type,
                    x.Code

                }
                ).ToArray()
                       .Select(x => new
                       {
                           id = x.Sno,
                           cell = new string[] {
                                x.Sno ,
                                x.Srl,
                               Convert.ToString( x.Qty),
                                Convert.ToString(x.GrossWt),
                               Convert.ToString(x.NetWt) ,
                                Convert.ToString(x.TimeFrom ),
                               Convert.ToString  (x.TimeTo),
                               Convert.ToString( x.Qty2),
                                x.Type,
                                x.Code

                               }
                       }).ToArray()
            };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        //Edit MfgTimeLoss
        [HttpPost]
        public ActionResult Editmfg_TimeLoss(string TimeFrom, MfgTimelossModel model)
        {
            var result = ctx.MfgTimeLoss1.FirstOrDefault(x => x.Sno == model.Sno);
            if (result != null)
            {
                result.TimeFrom = model.TimeFrom;
                result.TimeTo = model.TimeTo;
                result.ReasonCode = model.ReasonCode;
                ctx.SaveChanges();
            }
            else
            {
                try
                {
                    MfgTimeLoss1 obj = new MfgTimeLoss1();
                    obj.TimeFrom = DateTime.Now;
                    obj.TimeTo = model.TimeTo;
                    obj.ReasonCode = model.ReasonCode;
                    ctx.MfgTimeLoss1.Add(obj);
                    ctx.SaveChanges();
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
            return RedirectToAction("Index");
            //return View();
        }

        public ActionResult mfg_TimeLoss()
        {
            var result = new
            {
                row = ctx.MfgTimeLoss1.Select(x => new
                {
                    x.Sno,
                    x.TimeFrom,
                    x.TimeTo,
                    x.ReasonCode
                }).ToArray()
                .Select(x => new
                {
                    id = x.Sno,
                    cell = new string[]{
                      x.Sno,
                      Convert.ToString (x.TimeFrom),
                      Convert.ToString(x.TimeTo),
                      x.ReasonCode 

                  }
                }).ToArray()
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Get Mfg Rejection
        public ActionResult GetMfg_Rejection()
        {
            var result = new
            {
                row = ctx.MfgRejection1.Select(x => new
                {
                    x.Sno,
                    x.ReasonCode,
                    x.Qty
                }).ToArray()
                .Select(x => new
                {
                    id = x.Sno,
                    cell = new string[]{
                      x.Sno,
                       Convert.ToString(x.Qty),
                  x.ReasonCode
                  }

                }).ToArray()
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Edit MfgRejection
        [HttpPost]
        public ActionResult Editmfg_MfgRejection(string TimeFrom, MfgRejectionModel model)
        {
            List<MfgRejectionModel> test = new List<MfgRejectionModel>();
            model.Sno = TempData["Sno"].ToString();
            model.Qty = model.Qty;
            model.ReasonCode = model.ReasonCode;
            if (Session.Count != 0)
            {
                test = Session["model"] as List<MfgRejectionModel>;
            }
            else
            {
                test = new List<MfgRejectionModel>();
            }
            test.Add(model);
            Session["model"] = test;
            return View();
            //var result = ctx.MfgRejection1.FirstOrDefault(x => x.Sno == model.Sno);

            //if (result != null)
            //{

            //    result.Qty = model.Qty;
            //    result.ReasonCode = model.ReasonCode;
            //    ctx.SaveChanges();
            //}
            //else
            //{
            //    try
            //    {
            //        MfgRejection1 obj = new MfgRejection1();

            //        obj.Qty = model.Qty;
            //        obj.ReasonCode = model.ReasonCode;
            //        ctx.MfgRejection1.Add(obj);
            //        ctx.SaveChanges();
            //    }
            //    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            //    {
            //        Exception raise = dbEx;
            //        foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        {
            //            foreach (var validationError in validationErrors.ValidationErrors)
            //            {
            //                string message = string.Format("{0}:{1}",
            //                    validationErrors.Entry.Entity.ToString(),
            //                    validationError.ErrorMessage);
            //                // raise a new exception nesting
            //                // the current instance as InnerException
            //                raise = new InvalidOperationException(message, raise);
            //            }
            //        }
            //        throw raise;
            //    }
            //}
            //   
                //    catch (DbEntityValidationException ex)
                //    {
                //        // Retrieve the error messages as a list of strings.
                //        var errorMessages = ex.EntityValidationErrors
                //                .SelectMany(x => x.ValidationErrors)
                //                .Select(x => x.ErrorMessage);

                //        // Join the list to a single string.
                //        var fullErrorMessage = string.Join("; ", errorMessages);

                //        // Combine the original exception message with the new one.
                //        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                //        // Throw a new DbEntityValidationException with the improved exception message.
                //        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                //    }

                //}

            
        }
    }
}

