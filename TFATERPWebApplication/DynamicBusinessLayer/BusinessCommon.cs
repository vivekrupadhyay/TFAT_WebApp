using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;


namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class BusinessCommon : IBusinessCommon
    {
        TFAT_WEBERPEntities mCtx = new TFAT_WEBERPEntities();
        public FormCollection GetDBFormCollection(TfatDesignHeader DHead, FormCollection fc)
        {
            FormCollection fcoll = new FormCollection();
            foreach (string Name in fc.AllKeys)
            {
                string n = DHead.TfatDesignForms.Where(f => f.LabelCaption == Name).Select(f => f.Fld).ToList()[0].ToString();
                string v = fc[Name].ToString();
                fc.Add(n, v);
            }
            return fcoll;
        }

        public IQueryable<TfatDesignHeader> SelectSingleTfatDeignHeader(string OptionCode)
        {
            return from t in mCtx.TfatDesignHeaders
                   where t.OptionCode == OptionCode
                   select t;
        }

        public IQueryable<ReportHeader> SelectSingleReportHeader(string Code)
        {
            return from t in mCtx.ReportHeaders
                   where t.Code == Code
                   select t;
        }
    }
}