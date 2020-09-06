//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFATERPWebApplication.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxMaster
    {
        public TaxMaster()
        {
            this.Addresses = new HashSet<Address>();
            this.Addresses1 = new HashSet<Address>();
            this.Sales = new HashSet<Sale>();
            this.Stocks = new HashSet<Stock>();
            this.ProjectDetails = new HashSet<ProjectDetail>();
        }
    
        public int RecordKey { get; set; }
        public decimal AddTax { get; set; }
        public string AddTaxCode { get; set; }
        public string aDescr { get; set; }
        public string aSchgCode { get; set; }
        public decimal aSurCharge { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public decimal Cess { get; set; }
        public string CessCode { get; set; }
        public string Code { get; set; }
        public string Form { get; set; }
        public string FormName { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public bool Inclusive { get; set; }
        public bool IsSERTax { get; set; }
        public bool Locked { get; set; }
        public bool MRPTax { get; set; }
        public string Name { get; set; }
        public bool NoCost { get; set; }
        public decimal Pct { get; set; }
        public string PostCode { get; set; }
        public string SchgCode { get; set; }
        public string Scope { get; set; }
        public decimal SetOff { get; set; }
        public decimal SurCharge { get; set; }
        public bool VATApp { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Address> Addresses1 { get; set; }
        public virtual Master Master { get; set; }
        public virtual Master Master1 { get; set; }
        public virtual Master Master2 { get; set; }
        public virtual Master Master3 { get; set; }
        public virtual Master Master4 { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<ProjectDetail> ProjectDetails { get; set; }
    }
}
