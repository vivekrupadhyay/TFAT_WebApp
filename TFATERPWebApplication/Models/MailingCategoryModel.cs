using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;

namespace TFATERPWebApplication.Models
{
    public class MailingCategoryModel
    {
        public int RecordKey { get; set; }
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        [DataType (DataType.Date)]
        public System.DateTime LastUpdateDate { get; set; }
    }
}