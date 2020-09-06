using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class ItemBOMHeaderDetailModel
    {
        public List<ItemBOMHeaderModel> Item { get; set; }
        public List<ItemBOMModel> ItemBom { get; set; }
        public List<ItemBOMRouteModel> ItemRoute { get; set; }
        public List<AddOn_BModel> AddOn { get; set; }
    }
    
}