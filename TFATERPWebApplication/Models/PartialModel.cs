using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFATERPWebApplication.Models
{
    public  class PartialModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
       
      
    }

   
  

}
