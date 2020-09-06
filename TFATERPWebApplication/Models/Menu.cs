using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class Menu
    {
        public Menu()
        {
            children = new List<Menu>();
        }

        public List<Menu> children { get; set; }
        public string label { get; set; }
        public string id { get; set; }
    }
}