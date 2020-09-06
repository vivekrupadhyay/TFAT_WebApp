using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Models
{
    public class ReligionModel
    {
        [Required]
        public int Code { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string Name { get; set; }


    }
}