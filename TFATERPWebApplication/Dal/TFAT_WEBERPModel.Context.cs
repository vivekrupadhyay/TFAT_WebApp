﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TFAT_WEBERPEntities : DbContext
    {
        public TFAT_WEBERPEntities()
            : base("name=TFAT_WEBERPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActivityStatu> ActivityStatus { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<CommissionType> CommissionTypes { get; set; }
        public virtual DbSet<CompanyAccType> CompanyAccTypes { get; set; }
        public virtual DbSet<CompanyBussType> CompanyBussTypes { get; set; }
        public virtual DbSet<ContactSource> ContactSources { get; set; }
        public virtual DbSet<CorrespondenceType> CorrespondenceTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<ItemBOM> ItemBOMs { get; set; }
        public virtual DbSet<ItemBOMHeader> ItemBOMHeaders { get; set; }
        public virtual DbSet<ItemBOMRoute> ItemBOMRoutes { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemDetail> ItemDetails { get; set; }
        public virtual DbSet<ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<ItemMaster> ItemMasters { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Ledger> Ledgers { get; set; }
        public virtual DbSet<LedgerBranch> LedgerBranches { get; set; }
        public virtual DbSet<MailingCategory> MailingCategories { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<ReportGroup> ReportGroups { get; set; }
        public virtual DbSet<ReportHeader> ReportHeaders { get; set; }
        public virtual DbSet<RequisitionType> RequisitionTypes { get; set; }
        public virtual DbSet<ResourceCategory> ResourceCategories { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<SLA> SLAs { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<TFatBranch> TFatBranches { get; set; }
        public virtual DbSet<TfatCity> TfatCities { get; set; }
        public virtual DbSet<TfatComp> TfatComps { get; set; }
        public virtual DbSet<TfatCountry> TfatCountries { get; set; }
        public virtual DbSet<TfatDesignForm> TfatDesignForms { get; set; }
        public virtual DbSet<TfatDesignHeader> TfatDesignHeaders { get; set; }
        public virtual DbSet<TfatMenu> TfatMenus { get; set; }
        public virtual DbSet<TfatPass> TfatPasses { get; set; }
        public virtual DbSet<TfatSearch> TfatSearches { get; set; }
        public virtual DbSet<TfatState> TfatStates { get; set; }
        public virtual DbSet<WarrantyType> WarrantyTypes { get; set; }
        public virtual DbSet<AddOn_B> AddOn_B { get; set; }
        public virtual DbSet<ItemClass> ItemClasses { get; set; }
        public virtual DbSet<rStock> rStocks { get; set; }
        public virtual DbSet<SuchanProject> SuchanProjects { get; set; }
        public virtual DbSet<TfatDesign> TfatDesigns { get; set; }
        public virtual DbSet<TfatForm> TfatForms { get; set; }
        public virtual DbSet<TfatPerd> TfatPerds { get; set; }
        public virtual DbSet<AddOn_A> AddOn_A { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<MasterInfo> MasterInfoes { get; set; }
        public virtual DbSet<MasterGroup> MasterGroups { get; set; }
        public virtual DbSet<MasterInfoDC> MasterInfoDCs { get; set; }
        public virtual DbSet<MasterSubLedger> MasterSubLedgers { get; set; }
        public virtual DbSet<AddOn_D> AddOn_D { get; set; }
        public virtual DbSet<AddOn_P> AddOn_P { get; set; }
        public virtual DbSet<AddonValue> AddonValues { get; set; }
        public virtual DbSet<CurrRate> CurrRates { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<IncoTerm> IncoTerms { get; set; }
        public virtual DbSet<ItemMore> ItemMores { get; set; }
        public virtual DbSet<ItemWarranty> ItemWarranties { get; set; }
        public virtual DbSet<MainType> MainTypes { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesChannel> SalesChannels { get; set; }
        public virtual DbSet<SalesDivision> SalesDivisions { get; set; }
        public virtual DbSet<SalesMan> SalesMen { get; set; }
        public virtual DbSet<SalesmanCategory> SalesmanCategories { get; set; }
        public virtual DbSet<SalesTaxDetail> SalesTaxDetails { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockMore> StockMores { get; set; }
        public virtual DbSet<StockSerialData> StockSerialDatas { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<SubLedger> SubLedgers { get; set; }
        public virtual DbSet<SubType> SubTypes { get; set; }
        public virtual DbSet<TransportDetail> TransportDetails { get; set; }
        public virtual DbSet<TransporterMa> TransporterMas { get; set; }
        public virtual DbSet<UnitMaster> UnitMasters { get; set; }
        public virtual DbSet<AddOn_DRev> AddOn_DRev { get; set; }
        public virtual DbSet<AddOn_F> AddOn_F { get; set; }
        public virtual DbSet<AddOn_G> AddOn_G { get; set; }
        public virtual DbSet<AddOn_J> AddOn_J { get; set; }
        public virtual DbSet<AddOnAG> AddOnAGs { get; set; }
        public virtual DbSet<AddOnBP> AddOnBPs { get; set; }
        public virtual DbSet<AddOnBR> AddOnBRs { get; set; }
        public virtual DbSet<AddOnCM> AddOnCMs { get; set; }
        public virtual DbSet<AddOnCN> AddOnCNs { get; set; }
        public virtual DbSet<AddOnCP> AddOnCPs { get; set; }
        public virtual DbSet<AddOnCR> AddOnCRs { get; set; }
        public virtual DbSet<AddOnC> AddOnCS { get; set; }
        public virtual DbSet<AddOnDN> AddOnDNs { get; set; }
        public virtual DbSet<AddOnEP> AddOnEPs { get; set; }
        public virtual DbSet<AddOnEPRev> AddOnEPRevs { get; set; }
        public virtual DbSet<AddOnE> AddOnES { get; set; }
        public virtual DbSet<AddOnESRev> AddOnESRevs { get; set; }
        public virtual DbSet<AddOnF> AddOnFS { get; set; }
        public virtual DbSet<AddOnGD> AddOnGDs { get; set; }
        public virtual DbSet<AddOnGI> AddOnGIs { get; set; }
        public virtual DbSet<AddOnGJ> AddOnGJs { get; set; }
        public virtual DbSet<AddOnGO> AddOnGOes { get; set; }
        public virtual DbSet<AddOnGP> AddOnGPs { get; set; }
        public virtual DbSet<AddOnGrid> AddOnGrids { get; set; }
        public virtual DbSet<AddOnGT> AddOnGTs { get; set; }
        public virtual DbSet<AddOnHP> AddOnHPs { get; set; }
        public virtual DbSet<AddOnIA> AddOnIAs { get; set; }
        public virtual DbSet<AddOnIC> AddOnICs { get; set; }
        public virtual DbSet<AddOnIM> AddOnIMs { get; set; }
        public virtual DbSet<AddOnIP> AddOnIPs { get; set; }
        public virtual DbSet<AddOnI> AddOnIS { get; set; }
        public virtual DbSet<AddOnIV> AddOnIVs { get; set; }
        public virtual DbSet<AddOnJB> AddOnJBs { get; set; }
        public virtual DbSet<AddOnJC> AddOnJCs { get; set; }
        public virtual DbSet<AddOnJE> AddOnJEs { get; set; }
        public virtual DbSet<AddOnJI> AddOnJIs { get; set; }
        public virtual DbSet<AddOnJM> AddOnJMs { get; set; }
        public virtual DbSet<AddOnJO> AddOnJOes { get; set; }
        public virtual DbSet<AddOnJ> AddOnJS { get; set; }
        public virtual DbSet<AddOnJV> AddOnJVs { get; set; }
        public virtual DbSet<AddOnJX> AddOnJXes { get; set; }
        public virtual DbSet<AddOnMB> AddOnMBs { get; set; }
        public virtual DbSet<AddOnMC> AddOnMCs { get; set; }
        public virtual DbSet<AddOnMM> AddOnMMs { get; set; }
        public virtual DbSet<AddOnMP> AddOnMPs { get; set; }
        public virtual DbSet<AddOnMR> AddOnMRs { get; set; }
        public virtual DbSet<AddOnMV> AddOnMVs { get; set; }
        public virtual DbSet<AddOnNP> AddOnNPs { get; set; }
        public virtual DbSet<AddOnN> AddOnNS { get; set; }
        public virtual DbSet<AddOnOC> AddOnOCs { get; set; }
        public virtual DbSet<AddOnOP> AddOnOPs { get; set; }
        public virtual DbSet<AddOnOPRev> AddOnOPRevs { get; set; }
        public virtual DbSet<AddOnO> AddOnOS { get; set; }
        public virtual DbSet<AddOnOSRev> AddOnOSRevs { get; set; }
        public virtual DbSet<AddOnPC> AddOnPCs { get; set; }
        public virtual DbSet<AddOnPG> AddOnPGs { get; set; }
        public virtual DbSet<AddOnPI> AddOnPIs { get; set; }
        public virtual DbSet<AddOnPIRev> AddOnPIRevs { get; set; }
        public virtual DbSet<AddOnPJ> AddOnPJs { get; set; }
        public virtual DbSet<AddOnPK> AddOnPKs { get; set; }
        public virtual DbSet<AddOnPM> AddOnPMs { get; set; }
        public virtual DbSet<AddOnPP> AddOnPPs { get; set; }
        public virtual DbSet<AddOnPR> AddOnPRs { get; set; }
        public virtual DbSet<AddOnP> AddOnPS { get; set; }
        public virtual DbSet<AddOnPV> AddOnPVs { get; set; }
        public virtual DbSet<AddOnPX> AddOnPXes { get; set; }
        public virtual DbSet<AddOnQP> AddOnQPs { get; set; }
        public virtual DbSet<AddOnQPRev> AddOnQPRevs { get; set; }
        public virtual DbSet<AddOnQ> AddOnQS { get; set; }
        public virtual DbSet<AddOnQSRev> AddOnQSRevs { get; set; }
        public virtual DbSet<AddOnRC> AddOnRCs { get; set; }
        public virtual DbSet<AddOnRJ> AddOnRJs { get; set; }
        public virtual DbSet<AddOnRM> AddOnRMs { get; set; }
        public virtual DbSet<AddOnRP> AddOnRPs { get; set; }
        public virtual DbSet<AddOnR> AddOnRS { get; set; }
        public virtual DbSet<AddOn> AddOns { get; set; }
        public virtual DbSet<AddOnSG> AddOnSGs { get; set; }
        public virtual DbSet<AddonsIG> AddonsIGs { get; set; }
        public virtual DbSet<AddOnSL> AddOnSLs { get; set; }
        public virtual DbSet<AddOnSX> AddOnSXes { get; set; }
        public virtual DbSet<AddOnTG> AddOnTGs { get; set; }
        public virtual DbSet<AddOnTH> AddOnTHs { get; set; }
        public virtual DbSet<AddOnTI> AddOnTIs { get; set; }
        public virtual DbSet<AddOnTJ> AddOnTJs { get; set; }
        public virtual DbSet<AddOnTO> AddOnTOes { get; set; }
        public virtual DbSet<AddOnTP> AddOnTPs { get; set; }
        public virtual DbSet<AddOnT> AddOnTS { get; set; }
        public virtual DbSet<AddOnTT> AddOnTTs { get; set; }
        public virtual DbSet<AddOnU> AddOnUS { get; set; }
        public virtual DbSet<AddOnWO> AddOnWOes { get; set; }
        public virtual DbSet<AddOnX> AddOnXS { get; set; }
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<CurrencyMaster> CurrencyMasters { get; set; }
        public virtual DbSet<LCMaster> LCMasters { get; set; }
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }
        public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }
        public virtual DbSet<Scheme> Schemes { get; set; }
        public virtual DbSet<StockAdj> StockAdjs { get; set; }
        public virtual DbSet<StockBatch> StockBatches { get; set; }
        public virtual DbSet<StockClass> StockClasses { get; set; }
        public virtual DbSet<StockExcise> StockExcises { get; set; }
        public virtual DbSet<StockMCPara> StockMCParas { get; set; }
        public virtual DbSet<StockO> StockOS { get; set; }
        public virtual DbSet<StockQC> StockQCs { get; set; }
        public virtual DbSet<StockReserve> StockReserves { get; set; }
        public virtual DbSet<StockRev> StockRevs { get; set; }
        public virtual DbSet<StockSerial> StockSerials { get; set; }
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<TempLedgerBranch> TempLedgerBranches { get; set; }
        public virtual DbSet<TaxMaster> TaxMasters { get; set; }
        public virtual DbSet<TaxDetail> TaxDetails { get; set; }
        public virtual DbSet<TaxForm> TaxForms { get; set; }
        public virtual DbSet<Master1> Master1 { get; set; }
        public virtual DbSet<ServiceTaxMaster> ServiceTaxMasters { get; set; }
        public virtual DbSet<ServiceTaxRate> ServiceTaxRates { get; set; }
        public virtual DbSet<UnitMaster1> UnitMaster1 { get; set; }
        public virtual DbSet<ItemMaster1> ItemMaster1 { get; set; }
        public virtual DbSet<ProcessMas1> ProcessMas1 { get; set; }
        public virtual DbSet<ReasonMaster1> ReasonMaster1 { get; set; }
        public virtual DbSet<MfgRejection1> MfgRejection1 { get; set; }
        public virtual DbSet<MfgTimeLoss1> MfgTimeLoss1 { get; set; }
        public virtual DbSet<Stores1> Stores1 { get; set; }
        public virtual DbSet<StockMCPara1> StockMCPara1 { get; set; }
        public virtual DbSet<MfgParameter> MfgParameters { get; set; }
        public virtual DbSet<MfgQuantity> MfgQuantities { get; set; }
        public virtual DbSet<MachineParameter> MachineParameters { get; set; }
        public virtual DbSet<Test_Date> Test_Date { get; set; }
    }
}
