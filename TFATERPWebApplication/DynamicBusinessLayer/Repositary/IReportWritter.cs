using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TFATERPWebApplication.DynamicBusinessLayer.Repositary
{
    interface IReportWritter
    {
        JsonResult GetReportWritterStruct(string id);
        object GetReportData(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString);
        JsonResult XGetReportColumn(string mOptionName);
        object XGetReportData(string sidx, string sord, int page, int rows, string Code);
        JsonResult GetQueryStructResult(string Qry);
        object GetQueryDataResult(string Qry, string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString);
        string GetQueryHtmlResult(string cType, string Qry, string Para);
        string ExecuteQuery(string Qry);
    }
}
