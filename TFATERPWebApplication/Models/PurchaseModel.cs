using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class PurchaseModel
    {
        public string BillNumber { get; set; }
        public string Type { get; set; }
        public PurchaseModel(string bill,string type)
        {
            BillNumber = bill;
            Type = type;
        }
    }
}