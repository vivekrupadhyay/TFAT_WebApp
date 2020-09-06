using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Models
{
    public class ProductCategoryModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    }
}