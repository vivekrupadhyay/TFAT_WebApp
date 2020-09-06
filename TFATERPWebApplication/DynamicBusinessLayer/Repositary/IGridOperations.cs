using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TFATERPWebApplication.DynamicBusinessLayer.Repositary
{
    interface IGridOperations
    {
        JsonResult GetGridColStructure(int id);
        object Get(string sidx, string sord, int page, int rows);
        object Get(string sidx, string sord, int page, int rows, ref DataTable DtTable);
        object GetReportCntrData(string ReportCode, string sidx, string sord, int page, int rows);
    }
}
