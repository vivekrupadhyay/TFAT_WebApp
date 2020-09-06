using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TFATERPWebApplication.DynamicBusinessLayer.Repositary
{
    interface IDynamicEdit
    {
        void DynamicEditMaster(int DHeaderID, FormCollection frm);
        void DynamicGirdEditMaster(int DHeaderID, FormCollection frm, DataTable DtTbl);
        void DynamicEditMaster(FormCollection frm, string TableName);
    }
}
