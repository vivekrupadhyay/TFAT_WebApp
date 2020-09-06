using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;

namespace TFATERPWebApplication.Models
{
    public class ItemBOMRouteModel
    {
       
        public string BOMCode { get; set; }
        public string BOMSrl { get; set; }
        public string Code { get; set; }
        public decimal Qty { get; set; }
        public string RouteCode { get; set; }
        public string Sno { get; set; }
        
    }
}