using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using TFATERPWebApplication.Core;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class DynamicEdit : IDynamicEdit
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        public void DynamicEditMaster(int DHeaderID, FormCollection frm)
        {
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);

            object[] Param = new object[frm.Count + 7];
            string SpString = string.Empty;
            SpString = "Tfat_Update_" + DHead.TableName + " ";
            int i = 0;
            foreach (var fldname in frm)
            {
                SpString += "@" + fldname.ToString() + " = " + "@" + fldname.ToString() + "1,";
                Param[i] = new SqlParameter(fldname.ToString() + "1", frm[fldname.ToString()]);
                i++;
            }

            SpString += "@RecordKey = @RecordKey+1,";
            Param[i] = new SqlParameter("RecordKey", "1");
            i++;
            SpString += "@EnteredBy = @EnteredBy1,";
            Param[i] = new SqlParameter("EnteredBy1", "Admin");
            i++;
            SpString += "@AUTHORISE = @AUTHORISE1,";
            Param[i] = new SqlParameter("AUTHORISE1", "Adm");
            i++;
            SpString += "@AUTHIDS = @AUTHIDS1,";
            Param[i] = new SqlParameter("AUTHIDS1", "Admin");
            i++;
            SpString += "@HWSERIAL = @HWSERIAL1,";
            Param[i] = new SqlParameter("HWSERIAL1", "WEB001");
            i++;
            SpString += "@HWSERIAL2 = @HWSERIAL21,";
            Param[i] = new SqlParameter("HWSERIAL21", "WEB001");
            i++;
            SpString += "@LastUpdateDate = @LastUpdateDate1,";
            Param[i] = new SqlParameter("LastUpdateDate1", DateTime.Now);
            i++;
            SpString += "@TOUCHVALUE = @TOUCHVALUE1,";
            Param[i] = new SqlParameter("TOUCHVALUE1", DateTime.Now.ToString("ddmmyyyyHHMM"));

            int result = ctx.Database.ExecuteSqlCommand(SpString.Substring(0, SpString.Length - 1), Param);
            ctx.SaveChanges();
        }

        public void DynamicGirdEditMaster(int DHeaderID, FormCollection frm, DataTable DtTbl)
        {
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);

            string TableIDKey = DHead.IDKey.Split('^').LastOrDefault();

            DataRow[] DtRow = DtTbl.Select(TableIDKey + "=" + frm[TableIDKey]);

            DtTbl.Rows.Remove(DtRow[0]);

            DataRow Drow = DtTbl.NewRow();

            foreach (var fldname in frm)
            {
                Drow[DHead.TfatDesignForms.Where(f => f.TabName.ToUpper() == "GRID" && f.Section == 2 && f.LabelCaption.Equals(fldname.ToString())).First().Fld] = frm[fldname.ToString()];
            }

            DtTbl.Rows.Add(Drow);
        }

        public void DynamicEditMaster(FormCollection frm, string TableName)
        {
            //TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);

            object[] Param = new object[frm.Count + 7];
            string SpString = string.Empty;
            SpString = "Tfat_Update_" + TableName + " ";
            int i = 0;
            foreach (var fldname in frm)
            {
                SpString += "@" + fldname.ToString() + " = " + "@" + fldname.ToString() + "1,";
                Param[i] = new SqlParameter(fldname.ToString() + "1", frm[fldname.ToString()]);
                i++;
            }

            SpString += "@EnteredBy = @EnteredBy1,";
            Param[i] = new SqlParameter("EnteredBy1", "Admin");
            i++;
            SpString += "@AUTHORISE = @AUTHORISE1,";
            Param[i] = new SqlParameter("AUTHORISE1", "Adm");
            i++;
            SpString += "@AUTHIDS = @AUTHIDS1,";
            Param[i] = new SqlParameter("AUTHIDS1", "Admin");
            i++;
            SpString += "@HWSERIAL = @HWSERIAL1,";
            Param[i] = new SqlParameter("HWSERIAL1", "WEB001");
            i++;
            SpString += "@HWSERIAL2 = @HWSERIAL21,";
            Param[i] = new SqlParameter("HWSERIAL21", "WEB001");
            i++;
            SpString += "@LastUpdateDate = @LastUpdateDate1,";
            Param[i] = new SqlParameter("LastUpdateDate1", DateTime.Now);
            i++;
            SpString += "@TOUCHVALUE = @TOUCHVALUE1,";
            Param[i] = new SqlParameter("TOUCHVALUE1", DateTime.Now.ToString("ddmmyyyyHHMM"));

            int result = ctx.Database.ExecuteSqlCommand(SpString.Substring(0, SpString.Length - 1), Param);
            ctx.SaveChanges();
        }
    }
}