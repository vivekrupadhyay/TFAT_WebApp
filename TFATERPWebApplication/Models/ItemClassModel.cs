using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Models
{
    public class ItemClassModel
    {
      
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public string Class { get; set; }
        public string Code { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    }
}