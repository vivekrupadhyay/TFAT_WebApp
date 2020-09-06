using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class GridColumn
    {
        public string name { get; set; }
        public string index { get; set; }
        //public string width { get; set; }
        //public string align { get; set; }
        public bool key { get; set; }
        //public string sortable { get; set; }
        //public string sorttype { get; set; }
        public bool editable { get; set; }
        public string edittype { get; set; }
        //public string editoptions { get; set; }
        //public string editrules { get; set; }
    }
}