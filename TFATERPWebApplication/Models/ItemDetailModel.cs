using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Models
{
    public class ItemDetailModel
    {
        public string Name { get; set; }
       
        public string Party { get; set; }
        public string PCCode { get; set; }
        public decimal PointEarn { get; set; }
        public bool PortionPrice { get; set; }
        public decimal ProcLeadTime { get; set; }
        public decimal PurchDisc { get; set; }
        public decimal PurchDiscAmt { get; set; }
        public string PurchGroup { get; set; }
        public decimal PurchPer { get; set; }
        public decimal PurchRate { get; set; }
        public string PurchTaxCode { get; set; }
        public string PurchTaxOST { get; set; }
    }
}