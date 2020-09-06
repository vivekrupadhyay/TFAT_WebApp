using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;

namespace TFATERPWebApplication.Models
{
    public class ItemBOMModel
    {
        
        public string BomCode { get; set; }
        public string BomSrl { get; set; }
        
        public string ChildBOM { get; set; }
        public string Code { get; set; }
       
    }
}