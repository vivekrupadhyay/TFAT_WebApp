using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.DynamicBusinessLayer.Repositary
{
    interface IBusinessCommon
    {
        FormCollection GetDBFormCollection(TfatDesignHeader DHead, FormCollection fc);

        IQueryable<TfatDesignHeader> SelectSingleTfatDeignHeader(string OptionCode);

        IQueryable<ReportHeader> SelectSingleReportHeader(string Code);
    }
}
