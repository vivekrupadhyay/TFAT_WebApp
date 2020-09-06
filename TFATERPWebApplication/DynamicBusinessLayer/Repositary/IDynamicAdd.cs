using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TFATERPWebApplication.DynamicBusinessLayer.Repositary
{
    interface IDynamicAdd
    {
        void DynamicAddMaster(int DHeaderID, FormCollection frm);
        string DynamicAddMaster(FormCollection frm, string TableName, string IDKey);
        void DynamicGirdAddMaster(int DHeaderID, FormCollection frm, DataTable DtTbl);
    }
}
