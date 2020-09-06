using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Xml;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using TFATERPWebApplication.Models;

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class GridOperations : IGridOperations
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        #region Chetan
        public JsonResult GetGridColStructure(int id)
        {
            var DHeader = ctx.TfatDesignHeaders.Single(h => h.HeaderRecordKey == id);
            var DForms = DHeader.TfatDesignForms.Where(f => f.TabName.ToUpper().Equals("GRID")).OrderBy(f => Math.Abs(Convert.ToDecimal(f.DisplayOrder)));

            List<string> colName = new List<string>();
            List<string> colNm = new List<string>();
            List<object> result = new List<object>();
            List<GridColumn> colModel = new List<GridColumn>();
            foreach (var DForm in DForms)
            {
                colName.Add(DForm.LabelCaption);
                colNm.Add(DForm.Fld);
                GridColumn gc = new GridColumn();
                gc.name = DForm.LabelCaption;
                gc.index = DForm.Fld;
                gc.key = (DHeader.IDKey.Split('^').LastOrDefault() == DForm.Fld ? true : false);
                if (gc.key == false)
                {
                    gc.editable = true;
                    if (DForm.fType == "D")
                    {
                        gc.edittype = "select";
                    }
                    else
                    {
                        gc.edittype = "text";
                    }
                }
                colModel.Add(gc);
            }

            result.Add(CoreCommon.GetString(colName.ToArray()));
            result.Add(colModel);

            JsonResult JR = new JsonResult();
            JR.Data = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            return JR;
        }

        public object Get(string sidx, string sord, int page, int rows)
        {
            int id = Convert.ToInt32(HttpContext.Current.Request.Url.Segments.Last());

            string viewtype = HttpContext.Current.Request.UrlReferrer.Segments.Last();

            string querystring = HttpContext.Current.Request.UrlReferrer.Query.ToString();

            int childid = Convert.ToInt32(string.IsNullOrEmpty(querystring) ? "0" : querystring.Split(new char[] { '=' }).LastOrDefault());

            var DHeader = ctx.TfatDesignHeaders.Single(h => h.HeaderRecordKey == id);

            var DForms = DHeader.TfatDesignForms.Where(f => f.TabName.ToUpper().Equals("GRID")).OrderBy(f => Math.Abs(Convert.ToDecimal(f.DisplayOrder)));

            string TableName = DHeader.TfatDesignForms.First(f => f.TabName.ToUpper().Equals("GRID")).Fle;
            object obj = CoreCommon.GetTableObject(TableName);

            IEnumerable<object> resultDB = ctx.Set(obj.GetType()) as IEnumerable<object>;

            string[] IDs = DHeader.IDKey.Split('^');

            if (viewtype.ToUpper() != "GRID")
            {
                resultDB = from r in resultDB
                           where r.GetType().GetProperty(IDs.First()).GetValue(r).Equals(childid)
                           select r;
            }

            if (sord == "desc")
            {
                resultDB = from r in resultDB
                           orderby r.GetType().GetProperty(sidx).GetValue(r) descending
                           select r;
            }
            else
            {
                resultDB = from r in resultDB
                           orderby r.GetType().GetProperty(sidx).GetValue(r)
                           select r;
            }

            int count = resultDB.Count();
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = count;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var Data = resultDB.Skip(pageIndex * pageSize).Take(pageSize);

            var result = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (from dt in Data
                        select new
                        {
                            i = dt.GetType().GetProperty(IDs.First()).GetValue(dt),
                            cell = GetStringArr(Convert.ToString(dt.GetType().GetProperty(viewtype.ToUpper().Equals("GRID") ? IDs.First() : IDs.Last()).GetValue(dt)), id, (viewtype.ToUpper().Equals("GRID") ? IDs.FirstOrDefault() : IDs.LastOrDefault()))
                        }).ToArray()
            };
            return result;
        }

        public object Get(string sidx, string sord, int page, int rows, ref DataTable DtTable)
        {
            int id = Convert.ToInt32(HttpContext.Current.Request.Url.Segments.Last());

            string viewtype = HttpContext.Current.Request.UrlReferrer.Segments.Last();

            string querystring = HttpContext.Current.Request.UrlReferrer.Query.ToString();

            int childid = Convert.ToInt32(string.IsNullOrEmpty(querystring) ? "0" : querystring.Split(new char[] { '=' }).LastOrDefault());

            var DHeader = ctx.TfatDesignHeaders.Single(h => h.HeaderRecordKey == id);

            var DForms = DHeader.TfatDesignForms.Where(f => f.TabName.ToUpper().Equals("GRID")).OrderBy(f => Math.Abs(Convert.ToDecimal(f.DisplayOrder)));

            string TableName = DHeader.TfatDesignForms.First(f => f.TabName.ToUpper().Equals("GRID")).Fle;
            object obj = CoreCommon.GetTableObject(TableName);

            IEnumerable<object> resultDB = ctx.Set(obj.GetType()) as IEnumerable<object>;

            string[] IDs = DHeader.IDKey.Split('^');

            if (viewtype.ToUpper() != "GRID")
            {
                resultDB = from r in resultDB
                           where r.GetType().GetProperty(IDs.First()).GetValue(r).Equals(childid)
                           select r;
            }

            if (sord == "desc")
            {
                resultDB = from r in resultDB
                           orderby r.GetType().GetProperty(sidx).GetValue(r) descending
                           select r;
            }
            else
            {
                resultDB = from r in resultDB
                           orderby r.GetType().GetProperty(sidx).GetValue(r)
                           select r;
            }

            DataTable DtTbl = new DataTable();
            foreach (TfatDesignForm frm in DForms)
            {
                DtTbl.Columns.Add(frm.Fld);
            }

            if (DtTable == null)
            {
                foreach (var colfrm in resultDB)
                {
                    DataRow drow = DtTbl.NewRow();
                    foreach (TfatDesignForm frm in DForms)
                    {
                        drow[frm.Fld] = Convert.ToString(colfrm.GetType().GetProperty(frm.Fld).GetValue(colfrm));
                    }
                    DtTbl.Rows.Add(drow);
                }
                DtTable = DtTbl;
            }

            int count = DtTable.Rows.Count;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = count;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var Data = DtTable.AsEnumerable().Skip(pageIndex * pageSize).Take(pageSize);
            DataTable mDT = DtTable;
            var result = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (from dt in Data
                        select new
                        {
                            //i = dt.GetType().GetProperty(IDs.First()).GetValue(dt),
                            i = childid,
                            cell = GetStringArrFromDataTable(Convert.ToString(dt.Field<dynamic>(viewtype.ToUpper().Equals("GRID") ? IDs.First() : IDs.Last())), id, (viewtype.ToUpper().Equals("GRID") ? IDs.FirstOrDefault() : IDs.LastOrDefault()), mDT)
                        }).ToArray()
            };
            return result;
        }

        private string[] GetStringArr(string p, int HeaderId, string IDKey)
        {
            var DHeader = ctx.TfatDesignHeaders.Single(h => h.HeaderRecordKey == HeaderId);
            var DForms = DHeader.TfatDesignForms.Where(f => f.TabName.ToUpper().Equals("GRID")).OrderBy(f => Math.Abs(Convert.ToDecimal(f.DisplayOrder)));
            int frmcount = DForms.Count();
            string TableName = DHeader.TfatDesignForms.First(f => f.TabName.ToUpper().Equals("GRID")).Fle;
            object obj = CoreCommon.GetTableObject(TableName);

            var resultDB = ctx.Set(obj.GetType()).SqlQuery("Select * from [" + TableName + "] Where " + IDKey + " = @ID", new SqlParameter("@ID", p)).ToListAsync().Result;
            string[] col = new string[frmcount];

            foreach (var colfrm in resultDB)
            {
                int i = 0;
                foreach (TfatDesignForm frm in DForms)
                {
                    col[i] = Convert.ToString(colfrm.GetType().GetProperty(frm.Fld).GetValue(colfrm));
                    i++;
                }
            }
            return col;
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
        #endregion

        #region Kailash
        public object GetReportCntrData(string ReportCode, string sidx, string sord, int page, int rows)
        {
            var reportData = ctx.ReportHeaders.Where(r => r.FormatGroup == ReportCode).ToList();
            int count = reportData.Count();
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            int totalRecords = count;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
            var Data = reportData.AsEnumerable().Skip(pageIndex * pageSize).Take(pageSize);

            var result = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = (from d in Data
                        select new
                        {
                            i = d.GetType().GetProperty("RecordKey").GetValue(d),
                            //cell = GetCellFields(Convert.ToInt32(d.GetType().GetProperty("RecordKey").GetValue(d)))
                            cell = new string[] { 
                                d.Code,
                                d.FormatHead,
                                d.SubCodeOf
                            }
                        }).ToArray()
            };
            return result;
        }

        //private string[] GetCellFields(int Code)
        //{
        //    var RHeader = ctx.ReportHeaders.Where(r => r.RecordKey == Code);
        //    int frmcount = RHeader.Count();
        //    string[] col = new string[frmcount];
        //    int i = 0;
        //    foreach (var colfrm in RHeader)
        //    {
        //        col[i] = Convert.ToString(colfrm.Code);
        //        i++;
        //    }
        //    return col;

        //}
        #endregion
    }
}