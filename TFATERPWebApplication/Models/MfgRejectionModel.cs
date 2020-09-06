using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class MfgRejectionModel
    {
        public int RecordKey { get; set; }
        public string Branch { get; set; }
        public string Code { get; set; }
        public double Factor { get; set; }
        public string MachineCode { get; set; }
        public string ParentMC { get; set; }
        public string Prefix { get; set; }
        public decimal Qty { get; set; }
        public decimal Qty2 { get; set; }
        public string ReasonCode { get; set; }
        public byte Shift { get; set; }
        public string Sno { get; set; }
        public string Srl { get; set; }
        public string Type { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string AUTHORISE { get; set; }
        public string AUTHIDS { get; set; }
        public string HWSERIAL { get; set; }
        public string HWSERIAL2 { get; set; }
        public string AccPeriod { get; set; }
        public string PeriodCode { get; set; }
    }
}