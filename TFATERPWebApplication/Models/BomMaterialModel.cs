using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class BomMaterialModel
    {
        public string Sno { get; set; }
        public string Code { get; set; }
        public string Stock { get; set; }
        public string Substitute { get; set; }
        public string Partial { get; set; }
       // public string MfgQty { get; set; }
        public string loss { get; set; }
        public string wastage { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Qty { get; set; }
        public string Unit { get; set; }
        public decimal RatePer { get; set; }
        public string Unit1Code { get; set; }
        public string ShortName { get; set; }
        public string   PerUnit { get; set; }
        public string ReasonType { get; set;}
        public string ProductCode { get; set; }
        public string Narration { get; set; }
        public string MfgQty { get; set; }
        public string Consumed { get; set; }
        public string QuantityHiddn { get; set; }
        public decimal  Value { get; set; }
        public string ProductDesc { get; set; }

        public string ProcessCode { get; set; }

        public string ProcessName { get; set; }

        public string Description { get; set; }

        public string txtCode1_itemMaster { get; set; }

        public string txtName1_itemMaster { get; set; }
       

        public string StoreCode { get; set; }

        public string StoreName { get; set; }
    }
}