using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Core
{
    public class CoreCommon
    {
        public static object GetTableObject(string TableName)
        {
            Type mType = BuildManager.GetType(string.Format("TFATERPWebApplication.Dal.{0}", TableName), true);
            return System.Activator.CreateInstance(mType);
        }

        public static Type GetTableType(string TableName)
        {
            return BuildManager.GetType(string.Format("TFATERPWebApplication.Dal.{0}", TableName), true);
        }

        public static DbSet GetTableData(string tablename)
        {
            var mType = BuildManager.GetType(string.Format("TFATERPWebApplication.Dal.{0}", tablename), true);
            TFAT_WEBERPEntities ctx = new TFAT_WEBERPEntities();
            return ctx.Set(mType);
        }

        public static string GetString(string[] col)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in col)
            {
                sb.Append(s);
                sb.Append(",");
            }
            return sb.ToString().Substring(0, sb.Length - 1);
        }
    }
}