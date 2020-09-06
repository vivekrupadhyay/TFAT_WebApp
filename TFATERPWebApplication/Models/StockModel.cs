using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFATERPWebApplication.Models
{
    public class StockModel
    {
        public int RecordKey { get; set; }
        public string AccPeriod { get; set; }
        public decimal AddTax { get; set; }
        public decimal Amt { get; set; }
        public decimal aSurcharge { get; set; }
        public bool Audited { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public string Batch { get; set; }
        public decimal BCD { get; set; }
        public decimal BCDAmt { get; set; }
        public System.DateTime BillDate { get; set; }
        public string BillNumber { get; set; }
        public string BOMSrl { get; set; }
        public string Branch { get; set; }
        public decimal Cess { get; set; }
        public System.DateTime ChlnDate { get; set; }
        public string ChlnNumber { get; set; }
        public string Code { get; set; }
        public decimal cRate { get; set; }
        public string CurrName { get; set; }
        public decimal CurrRate { get; set; }
        public string DCCode { get; set; }
        public decimal Disc { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal Discount { get; set; }
        public string Division { get; set; }
        public System.DateTime DocDate { get; set; }
        public bool Excisable { get; set; }
        public decimal ExciseAs { get; set; }
        public string ExcUnits { get; set; }
        public double Factor { get; set; }
        public bool FirstSno { get; set; }
        public bool FreeQty { get; set; }
        public bool Fvalue { get; set; }
        public string GINNumber { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public string IndNumber { get; set; }
        public bool IsChargeable { get; set; }
        public bool IsReturnable { get; set; }
        public string IssueNo { get; set; }
        public string MainType { get; set; }
        public string Narr { get; set; }
        public decimal NewRate { get; set; }
        public decimal NewRateEntry { get; set; }
        public decimal NewRateLink { get; set; }
        public bool NotInStock { get; set; }
        public decimal oDuty1 { get; set; }
        public decimal oDuty2 { get; set; }
        public decimal oDuty3 { get; set; }
        public decimal oDutyAmt1 { get; set; }
        public decimal oDutyAmt2 { get; set; }
        public decimal oDutyAmt3 { get; set; }
        public System.DateTime OrdDate { get; set; }
        public string OrdNumber { get; set; }
        public int Order { get; set; }
        public string Party { get; set; }
        public string PCCode { get; set; }
        public decimal Pending { get; set; }
        public decimal Pending2 { get; set; }
        public string PeriodCode { get; set; }
        public string PerUnit { get; set; }
        public decimal pQty { get; set; }
        public string Prefix { get; set; }
        public string ProcessCode { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectStage { get; set; }
        public string ProjectUnit { get; set; }
        public bool QCDone { get; set; }
        public bool QCIssued { get; set; }
        public decimal QCQty { get; set; }
        public bool QCRequire { get; set; }
        public decimal Qty { get; set; }
        public decimal Qty2 { get; set; }
        public string QtyEqsn { get; set; }
        public decimal Rate { get; set; }
        public decimal RateOn { get; set; }
        public decimal RatePer { get; set; }
        public string ReasonCode { get; set; }
        public string RouteCode { get; set; }
        public decimal SHECess { get; set; }
        public decimal SHECessAmt { get; set; }
        public string Sno { get; set; }
        public string Srl { get; set; }
        public int Stage { get; set; }
        public decimal STAmt { get; set; }
        public decimal STaxable { get; set; }
        public decimal STCess { get; set; }
        public string STCode { get; set; }
        public string Store { get; set; }
        public decimal STSheCess { get; set; }
        public string SubType { get; set; }
        public bool SuppInvoice { get; set; }
        public decimal SurCharge { get; set; }
        public decimal Taxable { get; set; }
        public decimal TaxAmt { get; set; }
        public string TaxCode { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Unit2 { get; set; }
        public string WasteFlag { get; set; }
        public decimal Weightage { get; set; }
        public string WONumber { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public decimal TotalDisc { get; set;}
        public int VenderID { get; set; }
        public int Value { get; set; }
       
    }
}