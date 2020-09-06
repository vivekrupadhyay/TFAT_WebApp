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
    
    public partial class ItemMaster1
    {
        public string AcType { get; set; }
        public string AppBranch { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public string BarCode { get; set; }
        public string BaseGr { get; set; }
        public bool BomExist { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public string Grp { get; set; }
        public bool Hide { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public bool IsLast { get; set; }
        public bool IsPacking { get; set; }
        public string Name { get; set; }
        public string Narr { get; set; }
        public bool NonStock { get; set; }
        public string PopupMsg { get; set; }
        public string Prefix { get; set; }
        public decimal RedemptionCost { get; set; }
        public byte Stocking { get; set; }
        public decimal TouchValue { get; set; }
        public string Unit { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public int RecordKey { get; set; }
        public string UnitM { get; set; }
        public string UnitP { get; set; }
        public string UnitS { get; set; }
        public decimal AbtRate { get; set; }
        public decimal ADC { get; set; }
        public bool AllowProdCat { get; set; }
        public string AltItem { get; set; }
        public decimal AMCChgs { get; set; }
        public string AssetCategory { get; set; }
        public decimal AssRate { get; set; }
        public bool AutoBatch { get; set; }
        public int AutoBatchIssue { get; set; }
        public bool AutoMFG { get; set; }
        public bool BatchExp { get; set; }
        public int BatchExpDays { get; set; }
        public bool BatchForce { get; set; }
        public bool BatchMFG { get; set; }
        public bool BatchNoDupl { get; set; }
        public string BatchPattern { get; set; }
        public bool BatchRates { get; set; }
        public bool BatchReq { get; set; }
        public decimal BatchSize { get; set; }
        public decimal BatchSizeQty { get; set; }
        public int BatchWidth { get; set; }
        public decimal BCD { get; set; }
        public decimal BCDAmt { get; set; }
        public decimal CallChgs { get; set; }
        public bool CanMfg { get; set; }
        public bool CanPurch { get; set; }
        public bool CanSale { get; set; }
        public bool CanSubContract { get; set; }
        public string Category { get; set; }
        public decimal Cess { get; set; }
        public bool ChargesOnQty2 { get; set; }
        public bool CheckPending2 { get; set; }
        public bool CheckStock { get; set; }
        public decimal CostRate { get; set; }
        public bool CostValue { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public decimal CurrYearExc { get; set; }
        public short DelyTime { get; set; }
        public decimal ExcRate { get; set; }
        public bool FreeLabour { get; set; }
        public bool FreeParts { get; set; }
        public int FreeService { get; set; }
        public string GoodsHSN { get; set; }
        public string GroupTree { get; set; }
        public decimal GrWeight { get; set; }
        public decimal GSIRate { get; set; }
        public string Hazard { get; set; }
        public decimal Humidity { get; set; }
        public string iDim1 { get; set; }
        public string iDim2 { get; set; }
        public string iDim3 { get; set; }
        public int iHeight { get; set; }
        public int iLength { get; set; }
        public string iUnit1 { get; set; }
        public string iUnit2 { get; set; }
        public string iUnit3 { get; set; }
        public int iWidth { get; set; }
        public System.DateTime LastUpdateOn { get; set; }
        public decimal LCharges { get; set; }
        public decimal LeadTime { get; set; }
        public decimal MCharges { get; set; }
        public string MfgLocation { get; set; }
        public decimal MinCharges { get; set; }
        public bool MRPbase { get; set; }
        public decimal NCCDRate { get; set; }
        public decimal NetWeight { get; set; }
        public decimal NextYearExc { get; set; }
        public decimal OCharges { get; set; }
        public decimal oDuty1 { get; set; }
        public decimal oDuty2 { get; set; }
        public decimal oDuty3 { get; set; }
        public decimal oDutyAmt1 { get; set; }
        public decimal oDutyAmt2 { get; set; }
        public decimal oDutyAmt3 { get; set; }
        public bool OnSite { get; set; }
        public bool OverReserve { get; set; }
        public decimal PackingSize { get; set; }
        public int pHeight { get; set; }
        public short Pickup { get; set; }
        public string PicturePath { get; set; }
        public int pLength { get; set; }
        public string Potency { get; set; }
        public string Principle { get; set; }
        public int pWidth { get; set; }
        public bool QCReqd { get; set; }
        public string QtyEqsn { get; set; }
        public decimal QtyToleMinus { get; set; }
        public decimal QtyTolePlus { get; set; }
        public int RateMethod { get; set; }
        public bool RateOn2 { get; set; }
        public string SCentreNo { get; set; }
        public bool SecondUnit { get; set; }
        public decimal SEDRate { get; set; }
        public bool SerialNoDupl { get; set; }
        public bool SerialPrefix { get; set; }
        public bool SerialReq { get; set; }
        public bool SerialType { get; set; }
        public bool ServiceCard { get; set; }
        public bool ServiceSch { get; set; }
        public decimal SHECess { get; set; }
        public string StdCode { get; set; }
        public string StockistID { get; set; }
        public bool StockReserve { get; set; }
        public bool StockSerial { get; set; }
        public decimal Storage { get; set; }
        public string Tariff { get; set; }
        public string TariffGrp { get; set; }
        public decimal Temperature { get; set; }
        public decimal TTARate { get; set; }
        public string Unit2 { get; set; }
        public System.DateTime VerifyDate { get; set; }
        public int VerifyDays { get; set; }
        public bool VerifyItem { get; set; }
        public int Warranty { get; set; }
        public string WarrantyCover { get; set; }
        public string WarrantyNote { get; set; }
        public bool WarrantyPart { get; set; }
        public decimal WarrantyRun { get; set; }
    }
}