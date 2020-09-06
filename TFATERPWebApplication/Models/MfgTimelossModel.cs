using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class MfgTimelossModel
    {
        public string Sno { get; set; }
        [Display(Name = "Release Date")]

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string ReasonCode { get; set; }
    }
}