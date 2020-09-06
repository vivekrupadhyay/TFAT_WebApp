using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TFATERPWebApplication.DynamicBusinessLayer.Repositary
{
    interface IDynamicDelete
    {
        void DynamicDeleteMaster(int DHeaderID, FormCollection frm);
        void DynamicDeleteMaster(string TableName, string IDKey, FormCollection frm);
        void DynamicGirdDeleteMaster(int DHeaderID, FormCollection frm, DataTable DtTbl);
    }
}
