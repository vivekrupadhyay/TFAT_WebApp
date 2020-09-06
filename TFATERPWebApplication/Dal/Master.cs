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
    
    public partial class Master
    {
        public Master()
        {
            this.Ledgers = new HashSet<Ledger>();
            this.Ledgers1 = new HashSet<Ledger>();
            this.Ledgers2 = new HashSet<Ledger>();
            this.ProjectDetails = new HashSet<ProjectDetail>();
            this.Sales = new HashSet<Sale>();
            this.Sales1 = new HashSet<Sale>();
            this.Stocks = new HashSet<Stock>();
            this.TaxMasters = new HashSet<TaxMaster>();
            this.TaxMasters1 = new HashSet<TaxMaster>();
            this.TaxMasters2 = new HashSet<TaxMaster>();
            this.TaxMasters3 = new HashSet<TaxMaster>();
            this.TaxMasters4 = new HashSet<TaxMaster>();
            this.ServiceTaxMasters = new HashSet<ServiceTaxMaster>();
            this.ServiceTaxMasters1 = new HashSet<ServiceTaxMaster>();
            this.ServiceTaxMasters2 = new HashSet<ServiceTaxMaster>();
            this.ServiceTaxMasters3 = new HashSet<ServiceTaxMaster>();
            this.ServiceTaxMasters4 = new HashSet<ServiceTaxMaster>();
            this.ServiceTaxMasters5 = new HashSet<ServiceTaxMaster>();
        }
    
        public int RecordKey { get; set; }
        public string AcType { get; set; }
        public string AppBranch { get; set; }
        public bool ARAP { get; set; }
        public string Area { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public bool AutoEmail { get; set; }
        public bool AutoSMS { get; set; }
        public string BaseGr { get; set; }
        public string Broker { get; set; }
        public string Category { get; set; }
        public bool CCBudget { get; set; }
        public bool CCReqd { get; set; }
        public string Code { get; set; }
        public string CostCentre { get; set; }
        public bool CutTDS { get; set; }
        public decimal DftAddress { get; set; }
        public int ExcType { get; set; }
        public string Flag { get; set; }
        public bool ForceCC { get; set; }
        public string Grp { get; set; }
        public bool Hide { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public bool IsLast { get; set; }
        public bool IsLead { get; set; }
        public bool IsPublic { get; set; }
        public bool IsSubLedger { get; set; }
        public string LeadCode { get; set; }
        public System.DateTime LeadConvertDt { get; set; }
        public string Name { get; set; }
        public bool NonActive { get; set; }
        public string PCCode { get; set; }
        public short Rank { get; set; }
        public string RevGroup { get; set; }
        public string Salesman { get; set; }
        public string ShortName { get; set; }
        public string StringValue { get; set; }
        public string TDSCode { get; set; }
        public decimal TouchValue { get; set; }
        public string UserID { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    
        public virtual ICollection<Ledger> Ledgers { get; set; }
        public virtual ICollection<Ledger> Ledgers1 { get; set; }
        public virtual ICollection<Ledger> Ledgers2 { get; set; }
        public virtual TfatPass TfatPass { get; set; }
        public virtual TfatPass TfatPass1 { get; set; }
        public virtual SalesMan SalesMan1 { get; set; }
        public virtual ICollection<ProjectDetail> ProjectDetails { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Sale> Sales1 { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<TaxMaster> TaxMasters { get; set; }
        public virtual ICollection<TaxMaster> TaxMasters1 { get; set; }
        public virtual ICollection<TaxMaster> TaxMasters2 { get; set; }
        public virtual ICollection<TaxMaster> TaxMasters3 { get; set; }
        public virtual ICollection<TaxMaster> TaxMasters4 { get; set; }
        public virtual ICollection<ServiceTaxMaster> ServiceTaxMasters { get; set; }
        public virtual ICollection<ServiceTaxMaster> ServiceTaxMasters1 { get; set; }
        public virtual ICollection<ServiceTaxMaster> ServiceTaxMasters2 { get; set; }
        public virtual ICollection<ServiceTaxMaster> ServiceTaxMasters3 { get; set; }
        public virtual ICollection<ServiceTaxMaster> ServiceTaxMasters4 { get; set; }
        public virtual ICollection<ServiceTaxMaster> ServiceTaxMasters5 { get; set; }
    }
}
