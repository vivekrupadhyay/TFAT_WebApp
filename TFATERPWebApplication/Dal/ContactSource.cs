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
    
    public partial class ContactSource
    {
        public ContactSource()
        {
            this.Addresses = new HashSet<Address>();
        }
    
        public int RecordKey { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string AUTHORISE { get; set; }
        public string AUTHIDS { get; set; }
        public string HWSERIAL { get; set; }
        public string HWSERIAL2 { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
