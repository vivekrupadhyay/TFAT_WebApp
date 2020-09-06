using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Models
{
    public class ItemCategoryModel
    {
       
        public string Code { get; set; }
        [Required ]
        public string Name { get; set; }
      
        public string EnteredBy { get; set; }
       
    }
}