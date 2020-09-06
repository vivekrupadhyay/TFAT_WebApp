using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class MasterModel
    {
        public string Code { get; set; }
        public String Name { get; set; }
        public string CrPeriod { get; set; }
        public string Sno { get; set; }
        public MasterModel(string code,string name,string crperiod,string sn)
        {
            Name = name;
            Code = code;
            CrPeriod = crperiod;
            Sno = sn;
        }
        
        
    }
}