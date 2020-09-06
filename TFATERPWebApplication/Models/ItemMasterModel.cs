using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;

namespace TFATERPWebApplication.Models
{
    public class ItemMasterModel
    {
        [Required ]
        public string Name { get; set; }
        [Required ]
        public string Code { get; set; }
        public string Flag { get; set; }
        public string Grp { get; set; }
        public bool Hide { get; set; }
        public string BarCode { get; set; }
        public string BaseGr { get; set; }
        public bool BomExist { get; set; }
    }
}