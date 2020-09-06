using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class ChargesModel
    {
        public string Head { get; set; }
        public string Equation { get; set; }
        public string Fld { get; set; }
        public List<ChargesFor> Cmodel { get; set; }
    }
    public class ChargesFor
    {
        public string Description { get; set; }
    }
}