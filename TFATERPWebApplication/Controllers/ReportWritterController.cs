using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFATERPWebApplication.DynamicBusinessLayer;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.Core;
using System.Data.Entity.Infrastructure;
using System.Reflection.Emit;
using System.Text;
using TFATERPWebApplication.Models;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace TFATERPWebApplication.Controllers
{
    public class ReportWritterController : BaseController
    {
        // GET: /ReportWritter/
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();
        IBusinessCommon mIBuss = new BusinessCommon();
        IReportWritter RptWritter = new ReportWritter();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(string id)
        {
            ViewBag.SuchanProjects = ctx.SuchanProjects.ToList();
            ViewBag.Query = mIBuss.SelectSingleReportHeader(id).ToList().FirstOrDefault().UserQuery.ToString().Trim();
            return View();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetReportGrid(string id)
        {
            return RptWritter.GetReportWritterStruct(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="_search"></param>
        /// <param name="searchField"></param>
        /// <param name="searchOper"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetReportData(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            object result = RptWritter.GetReportData(sidx, sord, page, rows, _search, searchField, searchOper, searchString);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExecCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GetQueryStructResult(ExecuteCommand ExecCommand)
        {
            return RptWritter.GetQueryStructResult(ExecCommand.Query);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExecCommand"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="_search"></param>
        /// <param name="searchField"></param>
        /// <param name="searchOper"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GetQueryDataResult(string ExecCommand, string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            object result = RptWritter.GetQueryDataResult(ExecCommand, sidx, sord, page, rows, _search, searchField, searchOper, searchString);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QryHtmlPara"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetQueryHtmlResult(QueryHtmlParameter QryHtmlPara)
        {
            return Content(RptWritter.GetQueryHtmlResult(QryHtmlPara.cType, QryHtmlPara.Query, QryHtmlPara.Para), "text/html", Encoding.UTF8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ExecCommand"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="_search"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Export(string ExecCommand, string sidx, string sord, int page, int rows, bool _search,string oper)
        {
            var GrdData = Json(RptWritter.ExecuteQuery(ExecCommand));
            var ExpType = oper;
            DataTable TempDt = JsonConvert.DeserializeObject<DataTable>(GrdData.Data.ToString());

            Response.ClearContent();
            StringWriter sw = new StringWriter();
            switch (oper)
            {
                case "excel":
                    {
                        var grid = new GridView();
                        grid.DataSource = TempDt;
                        grid.DataBind();
                        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
                        Response.ContentType = "application/excel";
                        HtmlTextWriter htw = new HtmlTextWriter(sw);
                        grid.RenderControl(htw);
                        Response.Write(sw.ToString());
                    }
                    break;
                case "word":
                    {
                        var grid = new GridView();
                        grid.DataSource = TempDt;
                        grid.DataBind();
                        Response.AddHeader("content-disposition", "attachment; filename=MyWordFile.doc");
                        Response.ContentType = "application/word";
                        HtmlTextWriter htw = new HtmlTextWriter(sw);
                        grid.RenderControl(htw);
                        Response.Write(sw.ToString());
                    }
                    break;
                case "csv":
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (DataColumn col in TempDt.Columns)
                        {
                            sb.Append(col.ColumnName);
                            sb.Append(",");
                        }

                        sw.WriteLine(sb.ToString().Substring(0, sb.ToString().Length - 1));

                        foreach (DataRow row in TempDt.Rows)
                        {
                            sb = new StringBuilder();
                            foreach (object iCol in row.ItemArray)
                            {
                                sb.Append(iCol.ToString());
                                sb.Append(",");
                            }
                            sw.WriteLine(sb.ToString().Substring(0, sb.ToString().Length - 1));
                        }

                        Response.AddHeader("content-disposition", "attachment; filename=MyCSVFile.csv");
                        Response.ContentType = "text/csv";
                        Response.Write(sw.ToString());
                    }
                    break;
                case "pdf":
                    {
                        var grid = new GridView();
                        grid.DataSource = TempDt;
                        grid.DataBind();
                        HtmlTextWriter htextw = new HtmlTextWriter(sw);
                        grid.RenderControl(htextw);
                        Document document = new Document();
                        PdfWriter.GetInstance(document, Response.OutputStream);
                        document.Open();
                        StringReader str = new StringReader(sw.ToString());
                        HTMLWorker htmlworker = new HTMLWorker(document);
                        htmlworker.Parse(str);
                        document.Close();
                        Response.AddHeader("content-disposition", "attachment; filename=MyPDFFile.pdf");
                        Response.ContentType = "application/pdf";
                        Response.Write(document);
                    }
                    break;
            }

            Response.End();
            return View();
        }
    }
}