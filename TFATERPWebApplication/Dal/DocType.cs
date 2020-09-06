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
    
    public partial class DocType
    {
        public DocType()
        {
            this.Ledgers = new HashSet<Ledger>();
            this.Sales = new HashSet<Sale>();
            this.Stocks = new HashSet<Stock>();
        }
    
        public int RecordKey { get; set; }
        public string AccountGroups { get; set; }
        public decimal ADC { get; set; }
        public string AddCond { get; set; }
        public bool AddZero { get; set; }
        public int Agreement { get; set; }
        public bool AllowCurr { get; set; }
        public bool AllowNeg { get; set; }
        public bool AllowZero { get; set; }
        public string AssCategory { get; set; }
        public string AuthIds { get; set; }
        public string Authorise { get; set; }
        public bool AuthReq { get; set; }
        public bool AutoChild { get; set; }
        public bool AutoGT { get; set; }
        public bool AutoGTEntry { get; set; }
        public bool AutoReserve { get; set; }
        public bool BarCode { get; set; }
        public string BarCodeStruct { get; set; }
        public decimal BCD { get; set; }
        public decimal BCDAmt { get; set; }
        public bool BlanketOrder { get; set; }
        public string Branch { get; set; }
        public bool BrokerCalculate { get; set; }
        public bool BudgetControl { get; set; }
        public string BudgetFlags { get; set; }
        public string BulkCond { get; set; }
        public string CashAcc { get; set; }
        public string Category { get; set; }
        public bool CatRates { get; set; }
        public decimal Cess { get; set; }
        public string ChequeAcc { get; set; }
        public string ChlnTypes { get; set; }
        public int Circulars { get; set; }
        public string Code { get; set; }
        public bool CommonSeries { get; set; }
        public bool ConsigneeStock { get; set; }
        public string Constant { get; set; }
        public short ConstantMode { get; set; }
        public string CreditCardAcc { get; set; }
        public string CurrConv { get; set; }
        public string DCCode { get; set; }
        public int DefaultNet { get; set; }
        public string DeleteCond { get; set; }
        public decimal DftExcPost { get; set; }
        public bool DocApprovalReq { get; set; }
        public bool DocBackward { get; set; }
        public short DocWidth { get; set; }
        public string EditCond { get; set; }
        public string EnqTypes { get; set; }
        public string ExcBaseOn { get; set; }
        public bool ExcCost { get; set; }
        public bool ExcCredit { get; set; }
        public bool ExcEdit { get; set; }
        public decimal ExciseAs { get; set; }
        public decimal ExcRate { get; set; }
        public bool ExpandKIT { get; set; }
        public string ExternalApp { get; set; }
        public bool FetchWoDet { get; set; }
        public bool FetchWoNo { get; set; }
        public bool FIFOOrder { get; set; }
        public bool FOC { get; set; }
        public bool ForceChlnP { get; set; }
        public bool ForceChlnS { get; set; }
        public bool ForceIndents { get; set; }
        public bool ForceOrderP { get; set; }
        public bool ForceOrderS { get; set; }
        public string Formats { get; set; }
        public string FromStore { get; set; }
        public bool GenMFG { get; set; }
        public decimal GSIRate { get; set; }
        public string GTTypes { get; set; }
        public bool HideAddChg { get; set; }
        public bool HideAddon { get; set; }
        public bool HideAmt { get; set; }
        public bool HideBatchSrl { get; set; }
        public bool HideDiscount { get; set; }
        public bool HideExcise { get; set; }
        public bool HideProcess { get; set; }
        public bool HideProduct { get; set; }
        public bool HideQty { get; set; }
        public bool HideQty2 { get; set; }
        public bool HideRate { get; set; }
        public bool HideRatePer { get; set; }
        public bool HideStore { get; set; }
        public bool HideTax { get; set; }
        public bool HideUnits { get; set; }
        public bool HideValue { get; set; }
        public string HotKey { get; set; }
        public string HWSerial { get; set; }
        public string HWSerial2 { get; set; }
        public bool InnerBrkp { get; set; }
        public bool InterBranch { get; set; }
        public string ItemGroups { get; set; }
        public System.DateTime LastDate { get; set; }
        public string LastPrefix { get; set; }
        public string LastSerial { get; set; }
        public string LimitFrom { get; set; }
        public string LimitTo { get; set; }
        public bool LockAddChg { get; set; }
        public bool LockAddon { get; set; }
        public bool LockAmt { get; set; }
        public bool LockBatchSrl { get; set; }
        public bool LockDiscount { get; set; }
        public bool LockExcise { get; set; }
        public bool LockNarr { get; set; }
        public bool LockProcess { get; set; }
        public bool LockProduct { get; set; }
        public bool LockQty { get; set; }
        public bool LockQty2 { get; set; }
        public bool LockRate { get; set; }
        public bool LockRatePer { get; set; }
        public bool LockStore { get; set; }
        public bool LockTax { get; set; }
        public bool LockUnits { get; set; }
        public bool LockValue { get; set; }
        public string MainType { get; set; }
        public decimal MaximumDetail { get; set; }
        public int MaxPrints { get; set; }
        public bool MFGMove { get; set; }
        public string Name { get; set; }
        public decimal NCCDRate { get; set; }
        public bool NoItemEdit { get; set; }
        public bool NoITF { get; set; }
        public bool NonStock { get; set; }
        public int NoOfEntries { get; set; }
        public bool NoPrintWindow { get; set; }
        public decimal oDuty1 { get; set; }
        public decimal oDuty2 { get; set; }
        public decimal oDuty3 { get; set; }
        public decimal oDutyAmt1 { get; set; }
        public decimal oDutyAmt2 { get; set; }
        public decimal oDutyAmt3 { get; set; }
        public string OrdTypes { get; set; }
        public bool OverReserve { get; set; }
        public string PCCode { get; set; }
        public string PostSave { get; set; }
        public bool PostShow { get; set; }
        public bool PostSummary { get; set; }
        public short PrefixAuto { get; set; }
        public string PrefixConst { get; set; }
        public short PrefixStyle { get; set; }
        public string PreSave { get; set; }
        public string PrintCond { get; set; }
        public bool PrintControl { get; set; }
        public bool PrintOnSave { get; set; }
        public string ProcessCode { get; set; }
        public bool ProductPost { get; set; }
        public bool Projects { get; set; }
        public bool QCReqd { get; set; }
        public string QtnTypes { get; set; }
        public bool QtyTole { get; set; }
        public string RateFlag { get; set; }
        public string ReasonCategory { get; set; }
        public string RefType { get; set; }
        public string RejStore { get; set; }
        public string ReqTypes { get; set; }
        public bool RequireCrLimit { get; set; }
        public bool RequireCrPeriod { get; set; }
        public bool RequireECC { get; set; }
        public bool RequireTIN { get; set; }
        public bool RequireTRNS { get; set; }
        public bool ReturnsType { get; set; }
        public bool RoundOff { get; set; }
        public bool RoundTax { get; set; }
        public short RoundTo { get; set; }
        public decimal SEDRate { get; set; }
        public int Seq { get; set; }
        public decimal SHECess { get; set; }
        public bool ShowExciseDetails { get; set; }
        public int ShowStores { get; set; }
        public string SkipStock { get; set; }
        public bool StockReserve { get; set; }
        public string Store { get; set; }
        public bool SubContCombine { get; set; }
        public string SubType { get; set; }
        public bool SuppInvoice { get; set; }
        public string Tariff { get; set; }
        public string Template { get; set; }
        public string ToStore { get; set; }
        public bool TradeExcise { get; set; }
        public decimal TTARate { get; set; }
        public bool TypeLock { get; set; }
        public bool ValueOrder { get; set; }
        public string vAuto { get; set; }
        public bool WOBatch { get; set; }
        public bool WOEditLoss { get; set; }
        public bool WOEditRM { get; set; }
        public bool WOFilterPro { get; set; }
        public bool WOInterface { get; set; }
        public bool WOLockCapacity { get; set; }
        public string WOTypes { get; set; }
        public decimal TOUCHVALUE { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
    
        public virtual MainType MainType1 { get; set; }
        public virtual SubType SubType1 { get; set; }
        public virtual ICollection<Ledger> Ledgers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
