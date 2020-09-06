using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.DataAccess;
using TFATERPWebApplication.Dal;

namespace TFATERPWebApplication.Models
{


    public class MyViewModel
    {

        public List<ItemBOM> itembom { get; set; }

        public List<ItemBOMHeader> itembomheader { get; set; }

        public List<ItemBOMRoute> itembookRoute { get; set; }

        public List<ItemMaster> itemMaster { get; set; }

        public List<AddOn_B> AddOn_B { get; set; }

    }
    public class itembomheader
    {
        public string BomName { get; set; }
        public string BomSrl { get; set; }
        public string Code { get; set; }
        public string BatchQty { get; set; }
    }
}