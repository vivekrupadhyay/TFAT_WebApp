using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;

namespace TFATERPWebApplication.Models
{
    public class ItemBOMHeaderModel :ItemBOMHeader 
    {
        
        public decimal BatchQty { get; set; }
        
        public string BOMName { get; set; }
        
        public string BOMSrl { get; set; }
       
        
        public string Code { get; set; }

        public ItemBOMHeaderModel(decimal BatchQty, string BOMName, string BOMSrl, string Code)
        {
            this.BOMName = BOMName;
            this.BOMSrl = BOMSrl;
            this.Code = Code;
            this.BatchQty = BatchQty;
        }

    }
}