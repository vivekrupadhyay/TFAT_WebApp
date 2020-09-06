using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TFATERPWebApplication.Core;
using System.Drawing;
using TFATERPWebApplication.Dal;
using TFATERPWebApplication.DynamicBusinessLayer.Repositary;
using System.Net;

namespace TFATERPWebApplication.DynamicBusinessLayer
{
    public class DynamicAdd : IDynamicAdd
    {
        private TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();

        public void DynamicAddMaster(int DHeaderID, FormCollection frm)
        {
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);
            try
            {
                object[] Param = new object[frm.Count + 8 - 1];
                string SpString = string.Empty;
                SpString = "Tfat_Insert_" + DHead.TableName + " ";
                int i = 0;
                foreach (var fldname in frm)
                {
                    //if (!(DHead.IDKey).Equals(fldname))
                    //{
                    SpString += "@" + fldname.ToString() + " = " + "@" + fldname.ToString() + "1,";
                    Param[i] = new SqlParameter(fldname.ToString() + "1", frm[fldname.ToString()]);
                    i++;
                    //}
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

                i++;


                int result = ctx.Database.ExecuteSqlCommand(SpString.Substring(0, SpString.Length - 1), Param);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public string DynamicAddMaster(FormCollection frm, string TableName, string IDKey)
        {
            string message = string.Empty;
            try
            {
                object[] Param = new object[frm.Count + 8 - 1];
                string SpString = string.Empty;
                SpString = "Tfat_Insert_" + TableName + " ";

                int i = 0;
                foreach (var fldname in frm)
                {
                    //if (!(IDKey).Equals(fldname))
                    //{
                    SpString += "@" + fldname.ToString() + " = " + "@" + fldname.ToString() + "1,";
                    Param[i] = new SqlParameter(fldname.ToString() + "1", frm[fldname.ToString()]);
                    i++;
                    //}
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
                i++;


                int result = ctx.Database.ExecuteSqlCommand(SpString.Substring(0, SpString.Length - 1), Param);

                ctx.SaveChanges();
            }
            catch (SqlException ex)
            {
                message = ex.Message.ToString().Replace("\r", "").Replace("\n", "");
            }

            return message;
        }

        public void DynamicGirdAddMaster(int DHeaderID, FormCollection frm, DataTable DtTbl)
        {
            TfatDesignHeader DHead = ctx.TfatDesignHeaders.First(h => h.HeaderRecordKey == DHeaderID);

            string TableIDKey = DHead.IDKey.Split('^').LastOrDefault();
            DataRow Drow = DtTbl.NewRow();

            foreach (var fldname in frm)
            {
                Drow[DHead.TfatDesignForms.Where(f => f.TabName.ToUpper() == "GRID" && f.Section == 2 && f.LabelCaption.Equals(fldname.ToString())).First().Fld] = frm[fldname.ToString()];
            }

            DtTbl.Rows.Add(Drow);
        }
    }
}