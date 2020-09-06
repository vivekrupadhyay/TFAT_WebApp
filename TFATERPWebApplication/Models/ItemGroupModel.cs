using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;

namespace TFATERPWebApplication.Models
{
    public class ItemGroupModel
    {
        [Required ]
        public string Name { get; set; }
        public string Prefix { get; set; }
        public decimal PurchDisc { get; set; }
        public decimal PurchPer { get; set; }
        public decimal PurchRate { get; set; }
        public string PurchTaxCode { get; set; }
        public decimal SalesDisc { get; set; }
        public decimal SalesMargin { get; set; }
        public decimal SalesMaxDisc { get; set; }
        public decimal SalesPer { get; set; }
    }
}