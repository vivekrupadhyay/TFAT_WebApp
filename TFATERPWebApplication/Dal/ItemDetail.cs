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
    
    public partial class ItemDetail
    {
        public int RecordKey { get; set; }
        public string ABC { get; set; }
        public string ACCode { get; set; }
        public string ACCodeX { get; set; }
        public bool AllowProdCat { get; set; }
        public bool AllowUser { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public bool AutoBatch { get; set; }
        public int AutoBatchIssue { get; set; }
        public bool AutoMFG { get; set; }
        public bool AutoSerialGRN { get; set; }
        public bool AutoSerialMFG { get; set; }
        public bool Availability { get; set; }
        public bool BatchAutoGRN { get; set; }
        public bool BatchExp { get; set; }
        public int BatchExpDays { get; set; }
        public bool BatchForce { get; set; }
        public bool BatchMFG { get; set; }
        public bool BatchNoDupl { get; set; }
        public string BatchPattern { get; set; }
        public bool BatchRates { get; set; }
        public bool BatchReq { get; set; }
        public decimal BatchSizeQty { get; set; }
        public int BatchWidth { get; set; }
        public string BinNumber { get; set; }
        public string Branch { get; set; }
        public bool CanMfg { get; set; }
        public bool CanPurch { get; set; }
        public bool CanSale { get; set; }
        public bool CanSubContract { get; set; }
        public bool CheckPending2 { get; set; }
        public bool CheckStock { get; set; }
        public string Code { get; set; }
        public decimal CostRate { get; set; }
        public bool CostValue { get; set; }
        public string DCCode { get; set; }
        public decimal DefQty { get; set; }
        public decimal DeliverPrice { get; set; }
        public int DelyTime { get; set; }
        public decimal EOQ { get; set; }
        public decimal FIFORate { get; set; }
        public decimal FIFOValue { get; set; }
        public decimal GRNLeadTime { get; set; }
        public string Grp { get; set; }
        public decimal HalfPrice { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public string ItemCategory { get; set; }
        public decimal LastCostRate { get; set; }
        public decimal LastPurchRate { get; set; }
        public decimal LastValue { get; set; }
        public string LBTTaxCode { get; set; }
        public decimal LeadTime { get; set; }
        public decimal LIFORate { get; set; }
        public decimal LIFOValue { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MaxQty { get; set; }
        public decimal MfgLeadTime { get; set; }
        public string MfgLocation { get; set; }
        public decimal MinDelyQty { get; set; }
        public decimal MinDlyQty { get; set; }
        public decimal MinQty { get; set; }
        public decimal MinSaleRate { get; set; }
        public decimal MRP { get; set; }
        public bool MRPTaxP { get; set; }
        public bool MRPTaxS { get; set; }
        public string Name { get; set; }
        public bool OverReserve { get; set; }
        public string Party { get; set; }
        public string PCCode { get; set; }
        public decimal PointEarn { get; set; }
        public bool PortionPrice { get; set; }
        public decimal ProcLeadTime { get; set; }
        public decimal PurchDisc { get; set; }
        public decimal PurchDiscAmt { get; set; }
        public string PurchGroup { get; set; }
        public decimal PurchPer { get; set; }
        public decimal PurchRate { get; set; }
        public string PurchTaxCode { get; set; }
        public string PurchTaxOST { get; set; }
        public bool QCReqd { get; set; }
        public bool QCReqdMfg { get; set; }
        public bool QCReqdSub { get; set; }
        public decimal QtyToleMinus { get; set; }
        public decimal QtyTolePlus { get; set; }
        public decimal QuarterPrice { get; set; }
        public int RateMethod { get; set; }
        public bool RateOn2 { get; set; }
        public decimal RedemptionCost { get; set; }
        public int ReOrdDays { get; set; }
        public int ReOrdDaysC { get; set; }
        public bool ReOrdHighLow { get; set; }
        public decimal ReOrdLevel { get; set; }
        public decimal ReOrdQty { get; set; }
        public bool RestrictPR { get; set; }
        public decimal SalesDisc { get; set; }
        public decimal SalesDiscAmt { get; set; }
        public decimal SalesMargin { get; set; }
        public decimal SalesMaxDisc { get; set; }
        public decimal SalesPer { get; set; }
        public decimal SalesRate { get; set; }
        public string SalesTaxCode { get; set; }
        public string SalesTaxOST { get; set; }
        public bool SecondUnit { get; set; }
        public bool SerialNoDupl { get; set; }
        public string SerialPatternGRN { get; set; }
        public string SerialPatternMFG { get; set; }
        public bool SerialPrefix { get; set; }
        public bool SerialReq { get; set; }
        public bool SerialType { get; set; }
        public bool SerTax { get; set; }
        public string SerTaxCode { get; set; }
        public bool SourceListReq { get; set; }
        public bool StockReserve { get; set; }
        public bool StockSerial { get; set; }
        public string Store { get; set; }
        public decimal ThirdPrice { get; set; }
        public decimal TimePrice1 { get; set; }
        public decimal TimePrice2 { get; set; }
        public decimal TimePrice3 { get; set; }
        public decimal TimePrice4 { get; set; }
        public decimal TouchValue { get; set; }
        public string Unit { get; set; }
        public string Unit2 { get; set; }
        public string VED { get; set; }
        public System.DateTime VerifyDate { get; set; }
        public int VerifyDays { get; set; }
        public bool VerifyItem { get; set; }
        public decimal WTRate { get; set; }
        public decimal WTValue { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string MRPControlGroup { get; set; }
        public string MRPIPType { get; set; }
        public string MRPISType { get; set; }
        public bool MRPReqd { get; set; }
        public string MRPWOType { get; set; }
    }
}