using System.ComponentModel.DataAnnotations;
using TFATERPWebApplication.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class ReportGroupModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Users { get; set; }
    }
}