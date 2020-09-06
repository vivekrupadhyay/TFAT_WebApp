using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class AddOn_BModel
    {
        public int RecordKey { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public string CheckedAddOns { get; set; }
        public string Code { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public string Product { get; set; }
        public string Sno { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    }
}