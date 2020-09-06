using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class DynamicDelete : IDynamicDelete
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

    public void DynamicDeleteMaster(int DHeaderID, FormCollection frm)
        {
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);
            object[] Param = new object[1];
            string SpString = string.Empty;
            SpString = "Tfat_Delete_" + DHead.TableName + " ";
            int i = 0;

            foreach (var fldname in frm)
            {
                if ((DHead.IDKey).Equals(fldname))
                {
                    SpString += "@" + fldname.ToString() + " = " + "@" + fldname.ToString() + "1,";
                    Param[i] = new SqlParameter(fldname.ToString() + "1", frm[fldname.ToString()]);
                    break;
                }
            }

            int result = ctx.Database.ExecuteSqlCommand(SpString.Substring(0, SpString.Length - 1), Param);
            ctx.SaveChanges();
        }

        public void DynamicDeleteMaster(string TableName, string IDKey, FormCollection frm)
        {
            //TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);
            object[] Param = new object[1];
            string SpString = string.Empty;
            SpString = "Tfat_Delete_" + TableName + " ";
            int i = 0;

            foreach (var fldname in frm)
            {
                if ((IDKey).Equals(fldname))
                {
                    SpString += "@" + fldname.ToString() + " = " + "@" + fldname.ToString() + "1,";
                    Param[i] = new SqlParameter(fldname.ToString() + "1", frm[fldname.ToString()]);
                    break;
                }
            }

            int result = ctx.Database.ExecuteSqlCommand(SpString.Substring(0, SpString.Length - 1), Param);
            ctx.SaveChanges();
        }

        public void DynamicGirdDeleteMaster(int DHeaderID, FormCollection frm, DataTable DtTbl)
        {
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);

            string TableIDKey = DHead.IDKey.Split('^').LastOrDefault();

            DataRow[] DtRow = DtTbl.Select(TableIDKey + "='" + frm[TableIDKey].ToString() + "'");

            DtTbl.Rows.Remove(DtRow[0]);
        }
    }
}