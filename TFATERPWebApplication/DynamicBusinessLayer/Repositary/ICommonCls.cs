using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TFATERPWebApplication.DynamicBusinessLayer.Repositary
{
    interface ICommonCls
    {
       string FieldOfTable(string _mTableName, string _mReturnField,string mValField);
    }
}
