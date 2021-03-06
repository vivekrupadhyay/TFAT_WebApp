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
    
    public partial class TaxDetail
    {
        public int RecordKey { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public string Code { get; set; }
        public bool CutTCS { get; set; }
        public bool CutTDS { get; set; }
        public string Deductee { get; set; }
        public decimal DifferRate { get; set; }
        public string DifferRateCertNo { get; set; }
        public bool FBT { get; set; }
        public string FBTCode { get; set; }
        public decimal FBTRate { get; set; }
        public decimal FBTSlab { get; set; }
        public System.DateTime Form15HCITDate { get; set; }
        public System.DateTime Form15HDate { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public bool IsDifferRate { get; set; }
        public bool IsForm15H { get; set; }
        public bool ServiceTax { get; set; }
        public string ServiceTaxCode { get; set; }
        public short ServiceTaxMethod { get; set; }
        public string TDSCode { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    }
}
