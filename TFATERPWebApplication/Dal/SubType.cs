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
    
    public partial class SubType
    {
        public SubType()
        {
            this.DocTypes = new HashSet<DocType>();
            this.Ledgers = new HashSet<Ledger>();
            this.Sales = new HashSet<Sale>();
            this.Stocks = new HashSet<Stock>();
        }
    
        public int RecordKey { get; set; }
        public string MainType { get; set; }
        public string Name { get; set; }
        public decimal Seq { get; set; }
        public string Code { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string AUTHORISE { get; set; }
        public string AUTHIDS { get; set; }
        public string HWSERIAL { get; set; }
        public string HWSERIAL2 { get; set; }
    
        public virtual ICollection<DocType> DocTypes { get; set; }
        public virtual ICollection<Ledger> Ledgers { get; set; }
        public virtual MainType MainType1 { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}