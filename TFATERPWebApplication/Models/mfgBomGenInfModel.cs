using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TFATERPWebApplication.Models
{
    public class mfgBomGenInfModel
    {
      
        public decimal MachineChgs { get; set; }
        public System.DateTime DocDate { get; set; }
        public System.DateTime ExpDate { get; set; }
        public System.DateTime MfgDate { get; set; }
        public int Stage { get; set; }
        public string Branch { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public List<PerUnit> per_unit { get; set; }
        public List<StoresMasterModel> Stores { get; set; }
        public List<ProcessMassModel> Processmass { get; set; }
        public List<mfgUnitMasterModel> UnitMaster { get; set; }
        //public List<mfgReasonMasterModel> ReasonMaster { get; set; }
        public List<BomMaterialModel> BomMaterials { get; set; }
       // public string PerUnit { get; set; }
        public SelectList Codelist { get; set; }
        public string WONumber { get; set; }
    }
    public class PerUnit
    {
        public string Name { get; set; }
    }
}