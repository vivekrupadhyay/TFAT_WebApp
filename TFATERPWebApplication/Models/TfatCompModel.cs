using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFATERPWebApplication.Dal;
using System.ComponentModel.DataAnnotations;

namespace TFATERPWebApplication.Models
{
    public class TfatCompModel:TfatComp 
    {
        public string Name { get; set; }
    }
}