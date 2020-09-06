﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using MvcJqGrid;

namespace TFATERPWebApplication.Models
{
    public class BankPayment
    {

        public int RecordKey { get; set; }
        public string AccPeriod { get; set; }
        public bool Audited { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public string BankCode { get; set; }
        public System.DateTime BillDate { get; set; }
        public string BillNo { get; set; }
        public string Branch { get; set; }
        public string Cheque { get; set; }
        public bool ChequeReturn { get; set; }
        public short ChqCategory { get; set; }
        public System.DateTime ClearDate { get; set; }
        public string Code { get; set; }
        public string CostCentre { get; set; }
        public decimal Credit { get; set; }
        public decimal CurrAmount { get; set; }
        public string CurrName { get; set; }
        public decimal CurrRate { get; set; }
        public decimal Debit { get; set; }
        public System.DateTime DocDate { get; set; }
        public string HWSerial { get; set; }
        public string MainType { get; set; }
        public string Narr { get; set; }
        public string OSAdj { get; set; }
        public string Party { get; set; }
        public string PCCode { get; set; }
        public string PeriodCode { get; set; }
        public string Prefix { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectStage { get; set; }
        public string ProjectUnit { get; set; }
        public string RecoFlag { get; set; }
        public string RefDoc { get; set; }
        public string SLCode { get; set; }
        public string Sno { get; set; }
        public string Srl { get; set; }
        public string SubType { get; set; }
        public string TDSCode { get; set; }
        public bool TDSFlag { get; set; }
        public decimal TouchValue { get; set; }
        public string Type { get; set; }
        public System.DateTime ValueDate { get; set; }
        public string xBranch { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string HWSERIAL2 { get; set; }
      
    }
    
}