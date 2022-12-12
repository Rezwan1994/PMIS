using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PMIS.Domain.Entities;

namespace PMIS.Domain.DBContext
{
    public partial class PMISDbContext : DbContext
    {
        public PMISDbContext()
        {
        }

        public PMISDbContext(DbContextOptions<PMISDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllocationDtl> AllocationDtls { get; set; } = null!;
        public virtual DbSet<AllocationMst> AllocationMsts { get; set; } = null!;
        public virtual DbSet<BatchDateWiseStock> BatchDateWiseStocks { get; set; } = null!;
        public virtual DbSet<BatchWiseStock> BatchWiseStocks { get; set; } = null!;
        public virtual DbSet<BudgetDoctorCategoryDtl> BudgetDoctorCategoryDtls { get; set; } = null!;
        public virtual DbSet<BudgetDtl> BudgetDtls { get; set; } = null!;
        public virtual DbSet<BudgetMst> BudgetMsts { get; set; } = null!;
        public virtual DbSet<ChallanDtl> ChallanDtls { get; set; } = null!;
        public virtual DbSet<ChallanMst> ChallanMsts { get; set; } = null!;
        public virtual DbSet<ChallanReturnDtl> ChallanReturnDtls { get; set; } = null!;
        public virtual DbSet<ChallanReturnMst> ChallanReturnMsts { get; set; } = null!;
        public virtual DbSet<CompanyInfo> CompanyInfos { get; set; } = null!;
        public virtual DbSet<DateWiseStock> DateWiseStocks { get; set; } = null!;
        public virtual DbSet<DepotInfo> DepotInfos { get; set; } = null!;
        public virtual DbSet<DoctorCategoryInfo> DoctorCategoryInfos { get; set; } = null!;
        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; } = null!;
        public virtual DbSet<MenuConfiguration> MenuConfigurations { get; set; } = null!;
        public virtual DbSet<MenuUserConfiguration> MenuUserConfigurations { get; set; } = null!;
        public virtual DbSet<ModuleInfo> ModuleInfos { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<NotificationPolicy> NotificationPolicies { get; set; } = null!;
        public virtual DbSet<NotificationView> NotificationViews { get; set; } = null!;
        public virtual DbSet<NotificationViewPolicy> NotificationViewPolicies { get; set; } = null!;
        public virtual DbSet<PmCategoryInfo> PmCategoryInfos { get; set; } = null!;
        public virtual DbSet<ProductionUnitInfo> ProductionUnitInfos { get; set; } = null!;
        public virtual DbSet<PromotionalMaterialInfo> PromotionalMaterialInfos { get; set; } = null!;
        public virtual DbSet<ReceiveDtl> ReceiveDtls { get; set; } = null!;
        public virtual DbSet<ReceiveMst> ReceiveMsts { get; set; } = null!;
        public virtual DbSet<ReportConfiguration> ReportConfigurations { get; set; } = null!;
        public virtual DbSet<ReportUserConfiguration> ReportUserConfigurations { get; set; } = null!;
        public virtual DbSet<ReturnCauseInfo> ReturnCauseInfos { get; set; } = null!;
        public virtual DbSet<RoleInfo> RoleInfos { get; set; } = null!;
        public virtual DbSet<RoleMenuConfiguration> RoleMenuConfigurations { get; set; } = null!;
        public virtual DbSet<RoleReportConfiguration> RoleReportConfigurations { get; set; } = null!;
        public virtual DbSet<RoleUserConfiguration> RoleUserConfigurations { get; set; } = null!;
        public virtual DbSet<TransferDtl> TransferDtls { get; set; } = null!;
        public virtual DbSet<TransferMst> TransferMsts { get; set; } = null!;
        public virtual DbSet<TransferReceiveDtl> TransferReceiveDtls { get; set; } = null!;
        public virtual DbSet<TransferReceiveMst> TransferReceiveMsts { get; set; } = null!;
        public virtual DbSet<UnitInfo> UnitInfos { get; set; } = null!;
        public virtual DbSet<UserDefaultPage> UserDefaultPages { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;
        public virtual DbSet<UserLog> UserLogs { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseOracle("Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.243.234)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME=silsqadb1.squaregroup.com)(SERVER = DEDICATED)));User Id=SPL_PPM;Password=SPLPPM");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SPL_PPM");

            modelBuilder.Entity<AllocationDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ALLOCATION_DTL");

                entity.Property(e => e.AllocationQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ALLOCATION_QTY");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<AllocationMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ALLOCATION_MST");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.DivisionCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION_CODE");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MarketCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MARKET_CODE");

                entity.Property(e => e.MarketGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MARKET_GROUP");

                entity.Property(e => e.MonthCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_CODE");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.ProductGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_GROUP");

                entity.Property(e => e.RegionCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REGION_CODE");

                entity.Property(e => e.TerritoryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TERRITORY_CODE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.YearCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("YEAR_CODE");
            });

            modelBuilder.Entity<BatchDateWiseStock>(entity =>
            {
                entity.HasKey(e => new { e.StockDate, e.DepotCode, e.PmCode, e.BatchNo })
                    .HasName("UK1_BATCH_DATE_WISE_STOCK");

                entity.ToTable("BATCH_DATE_WISE_STOCK");

                entity.Property(e => e.StockDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STOCK_DATE");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_NO");

                entity.Property(e => e.BatchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.ClosingStockQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLOSING_STOCK_QTY");

                entity.Property(e => e.OpeningStockQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OPENING_STOCK_QTY");
            });

            modelBuilder.Entity<BatchWiseStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BATCH_WISE_STOCK");

                entity.HasIndex(e => new { e.DepotCode, e.PmCode, e.BatchNo }, "UK1_BATCH_WISE_STOCK")
                    .IsUnique();

                entity.Property(e => e.BatchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_NO");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DATE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.StockQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STOCK_QTY");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_PRICE");
            });

            modelBuilder.Entity<BudgetDoctorCategoryDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BUDGET_DOCTOR_CATEGORY_DTL");

                entity.Property(e => e.BudgetQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUDGET_QUANTITY");

                entity.Property(e => e.DoctoryCategoryCode)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCTORY_CATEGORY_CODE");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<BudgetDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BUDGET_DTL");

                entity.Property(e => e.BudgetQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUDGET_QUANTITY");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.ProductionUnitCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTION_UNIT_CODE");

                entity.Property(e => e.Sbu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SBU");

                entity.Property(e => e.UnitCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UNIT_CODE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<BudgetMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BUDGET_MST");

                entity.Property(e => e.BudgetDate)
                    .HasColumnType("DATE")
                    .HasColumnName("BUDGET_DATE");

                entity.Property(e => e.BudgetNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BUDGET_NO");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MonthCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_CODE");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.YearCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("YEAR_CODE");
            });

            modelBuilder.Entity<ChallanDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CHALLAN_DTL");

                entity.Property(e => e.AllocationQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ALLOCATION_QTY");

                entity.Property(e => e.BatchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_NO");

                entity.Property(e => e.ChallanAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHALLAN_AMOUNT");

                entity.Property(e => e.ChallanDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHALLAN_DATE");

                entity.Property(e => e.ChallanQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHALLAN_QTY");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_PRICE");

                entity.Property(e => e.UnitVat)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_VAT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<ChallanMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CHALLAN_MST");

                entity.Property(e => e.AllocationNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALLOCATION_NO");

                entity.Property(e => e.AllocationType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ALLOCATION_TYPE");

                entity.Property(e => e.ChallanDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHALLAN_DATE");

                entity.Property(e => e.ChallanNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHALLAN_NO");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_CODE");

                entity.Property(e => e.LocationEcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_ECODE");

                entity.Property(e => e.LocationType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_TYPE");

                entity.Property(e => e.MonthCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_CODE");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.YearCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("YEAR_CODE");
            });

            modelBuilder.Entity<ChallanReturnDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CHALLAN_RETURN_DTL");

                entity.Property(e => e.BatchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_NO");

                entity.Property(e => e.ChallanQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHALLAN_QTY");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.ReturnAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RETURN_AMOUNT");

                entity.Property(e => e.ReturnQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RETURN_QTY");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_PRICE");

                entity.Property(e => e.UnitVat)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_VAT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<ChallanReturnMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CHALLAN_RETURN_MST");

                entity.Property(e => e.AllocationType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ALLOCATION_TYPE");

                entity.Property(e => e.ChallanNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHALLAN_NO");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_CODE");

                entity.Property(e => e.LocationEcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_ECODE");

                entity.Property(e => e.LocationType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_TYPE");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ReturnCauseCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RETURN_CAUSE_CODE");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RETURN_DATE");

                entity.Property(e => e.ReturnType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RETURN_TYPE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COMPANY_INFO");

                entity.Property(e => e.CompanyAddress1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_ADDRESS1");

                entity.Property(e => e.CompanyAddress2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_ADDRESS2");

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_CODE");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.CompanyShortName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_SHORT_NAME");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPNAY_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<DateWiseStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DATE_WISE_STOCK");

                entity.HasIndex(e => new { e.StockDate, e.DepotCode, e.PmCode }, "UK1_DATE_WISE_STOCK")
                    .IsUnique();

                entity.Property(e => e.ClosingStockQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLOSING_STOCK_QTY");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.OpeningStockQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OPENING_STOCK_QTY");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.StockDate)
                    .HasColumnType("DATE")
                    .HasColumnName("STOCK_DATE");
            });

            modelBuilder.Entity<DepotInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPOT_INFO");

                entity.HasIndex(e => e.DepotCode, "UK1_DEPOT_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.DepotName, "UK2_DEPOT_INFO")
                    .IsUnique();

                entity.Property(e => e.DepotAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_ADDRESS");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.DepotId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPOT_ID");

                entity.Property(e => e.DepotName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_NAME");

                entity.Property(e => e.DepotShortName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_SHORT_NAME");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<DoctorCategoryInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DOCTOR_CATEGORY_INFO");

                entity.HasIndex(e => e.DoctorCategoryCode, "UK1_DOCTOR_CATEGORY_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.DoctorCategoryName, "UK2_DOCTOR_CATEGORY_INFO")
                    .IsUnique();

                entity.Property(e => e.DoctorCategoryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_CATEGORY_CODE");

                entity.Property(e => e.DoctorCategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCTOR_CATEGORY_ID");

                entity.Property(e => e.DoctorCategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOCTOR_CATEGORY_NAME");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EMPLOYEE_INFO");

                entity.HasIndex(e => e.EmployeeCode, "UK1_EMPLOYEE_INFO")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_CODE");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NAME");

                entity.Property(e => e.EmployeeStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_STATUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");
            });

            modelBuilder.Entity<MenuConfiguration>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK_MENU_CONFIGARATION_MENU_ID");

                entity.ToTable("MENU_CONFIGURATION");

                entity.Property(e => e.MenuId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MENU_ID");

                entity.Property(e => e.Action)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.Area)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("AREA");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.Controller)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CONTROLLER");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Href)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("HREF");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MENU_NAME");

                entity.Property(e => e.MenuShow)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MENU_SHOW");

                entity.Property(e => e.ModuleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.OrderBySlno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_BY_SLNO");

                entity.Property(e => e.ParentMenuId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PARENT_MENU_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.MenuConfigurations)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_CONFIGARATION");
            });

            modelBuilder.Entity<MenuUserConfiguration>(entity =>
            {
                entity.ToTable("MENU_USER_CONFIGURATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.AddPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADD_PERMISSION");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.ConfirmPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONFIRM_PERMISSION");

                entity.Property(e => e.DeletePermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETE_PERMISSION");

                entity.Property(e => e.DetailView)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DETAIL_VIEW");

                entity.Property(e => e.DownloadPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOWNLOAD_PERMISSION");

                entity.Property(e => e.EditPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_PERMISSION");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.ListView)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LIST_VIEW");

                entity.Property(e => e.MenuId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MENU_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuUserConfigurations)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK1_MENU_USER_CONFIGURATION");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MenuUserConfigurations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK2_MENU_USER_CONFIGURATION");
            });

            modelBuilder.Entity<ModuleInfo>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PK_MODULE_INFO_MODULE_ID");

                entity.ToTable("MODULE_INFO");

                entity.Property(e => e.ModuleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MODULE_ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MODULE_NAME");

                entity.Property(e => e.OrderByNo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_BY_NO");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("NOTIFICATION");

                entity.Property(e => e.NotificationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NOTIFICATION_ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.NotificationBody)
                    .HasMaxLength(350)
                    .HasColumnName("NOTIFICATION_BODY");

                entity.Property(e => e.NotificationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("NOTIFICATION_DATE");

                entity.Property(e => e.NotificationPolicyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NOTIFICATION_POLICY_ID");

                entity.Property(e => e.NotificationTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NOTIFICATION_TITLE");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");
            });

            modelBuilder.Entity<NotificationPolicy>(entity =>
            {
                entity.ToTable("NOTIFICATION_POLICY");

                entity.Property(e => e.NotificationPolicyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NOTIFICATION_POLICY_ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.NotificationTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NOTIFICATION_TITLE");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");
            });

            modelBuilder.Entity<NotificationView>(entity =>
            {
                entity.ToTable("NOTIFICATION_VIEW");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.NotificationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NOTIFICATION_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.ViewDate)
                    .HasColumnType("DATE")
                    .HasColumnName("VIEW_DATE");
            });

            modelBuilder.Entity<NotificationViewPolicy>(entity =>
            {
                entity.ToTable("NOTIFICATION_VIEW_POLICY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.NotificationPolicyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NOTIFICATION_POLICY_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.ViewPermission)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIEW_PERMISSION");
            });

            modelBuilder.Entity<PmCategoryInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PM_CATEGORY_INFO");

                entity.HasIndex(e => e.PmCategoryCode, "UK1_PM_CATEGORY_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.PmCategoryName, "UK2_PM_CATEGORY_INFO")
                    .IsUnique();

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PM_CATEGORY_ID");

                entity.Property(e => e.PmCategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<ProductionUnitInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PRODUCTION_UNIT_INFO");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.ProductionUnitCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTION_UNIT_CODE");

                entity.Property(e => e.ProductionUnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCTION_UNIT_ID");

                entity.Property(e => e.ProductionUnitName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTION_UNIT_NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UnitCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UNIT_CODE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<PromotionalMaterialInfo>(entity =>
            {
                entity.HasKey(e => e.PmCode)
                    .HasName("PK1_PM_INFO");

                entity.ToTable("PROMOTIONAL_MATERIAL_INFO");

                entity.HasIndex(e => e.PmName, "UK1_PM_INFO")
                    .IsUnique();

                entity.Property(e => e.PmCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.PackSize)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PACK_SIZE");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PM_ID");

                entity.Property(e => e.PmName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PM_NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<ReceiveDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RECEIVE_DTL");

                entity.Property(e => e.BatchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_NO");

                entity.Property(e => e.BudgetQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUDGET_QUANTITY");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.DuePartDueExcessQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DUE_PART_DUE_EXCESS_QUANTITY");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DATE");

                entity.Property(e => e.FromSurplusQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FROM_SURPLUS_QUANTITY");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.NoOfSlot)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NO_OF_SLOT");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.ProductionUnitCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTION_UNIT_CODE");

                entity.Property(e => e.ReceiveAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECEIVE_AMOUNT");

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVE_DATE");

                entity.Property(e => e.ReceivedQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECEIVED_QUANTITY");

                entity.Property(e => e.Sbu)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SBU");

                entity.Property(e => e.StockTransferOrderQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STOCK_TRANSFER_ORDER_QUANTITY");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_PRICE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<ReceiveMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RECEIVE_MST");

                entity.Property(e => e.BudgetNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BUDGET_NO");

                entity.Property(e => e.ChallanDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHALLAN_DATE");

                entity.Property(e => e.ChallanNo)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CHALLAN_NO");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPOT_CODE");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MonthCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_CODE");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PoDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PO_DATE");

                entity.Property(e => e.PoNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PO_NO");

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVE_DATE");

                entity.Property(e => e.ReceiveNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVE_NO");

                entity.Property(e => e.ReceiveType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVE_TYPE");

                entity.Property(e => e.SupplierCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLIER_CODE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.YearCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("YEAR_CODE");
            });

            modelBuilder.Entity<ReportConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REPORT_CONFIGURATION");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.HasCsv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HAS_CSV");

                entity.Property(e => e.HasPdf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HAS_PDF");

                entity.Property(e => e.HasPreview)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HAS_PREVIEW");

                entity.Property(e => e.MenuId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MENU_ID");

                entity.Property(e => e.OrderBySlno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_BY_SLNO");

                entity.Property(e => e.ReportId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_NAME");

                entity.Property(e => e.ReportTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_TITLE");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<ReportUserConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REPORT_USER_CONFIGURATION");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.CsvPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CSV_PERMISSION");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.PdfPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PDF_PERMISSION");

                entity.Property(e => e.PreviewPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PREVIEW_PERMISSION");

                entity.Property(e => e.ReportId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");
            });

            modelBuilder.Entity<ReturnCauseInfo>(entity =>
            {
                entity.HasKey(e => e.ReturnCauseId)
                    .HasName("PK1_RETURN_CAUSE_INFO");

                entity.ToTable("RETURN_CAUSE_INFO");

                entity.HasIndex(e => e.ReturnCauseCode, "UK1_RETURN_CAUSE_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.ReturnCauseName, "UK2_RETURN_CAUSE_INFO")
                    .IsUnique();

                entity.Property(e => e.ReturnCauseId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RETURN_CAUSE_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.ReturnCauseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RETURN_CAUSE_CODE");

                entity.Property(e => e.ReturnCauseName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("RETURN_CAUSE_NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<RoleInfo>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_ROLE_INFO_ROLE_ID");

                entity.ToTable("ROLE_INFO");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<RoleMenuConfiguration>(entity =>
            {
                entity.ToTable("ROLE_MENU_CONFIGURATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.AddPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADD_PERMISSION");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.ConfirmPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONFIRM_PERMISSION");

                entity.Property(e => e.DeletePermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETE_PERMISSION");

                entity.Property(e => e.DetailView)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DETAIL_VIEW");

                entity.Property(e => e.DownloadPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOWNLOAD_PERMISSION");

                entity.Property(e => e.EditPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EDIT_PERMISSION");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.ListView)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LIST_VIEW");

                entity.Property(e => e.MenuId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MENU_ID");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleMenuConfigurations)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK2_ROLE_MENU_CONFIGURATION");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMenuConfigurations)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK1_ROLE_MENU_CONFIGURATION");
            });

            modelBuilder.Entity<RoleReportConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ROLE_REPORT_CONFIGURATION");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.CsvPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CSV_PERMISSION");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.PdfPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PDF_PERMISSION");

                entity.Property(e => e.PreviewPermission)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PREVIEW_PERMISSION");

                entity.Property(e => e.ReportId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<RoleUserConfiguration>(entity =>
            {
                entity.ToTable("ROLE_USER_CONFIGURATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.PermiteDate)
                    .HasColumnType("DATE")
                    .HasColumnName("PERMITE_DATE");

                entity.Property(e => e.PermittedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PERMITTED_BY");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUserConfigurations)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK1_ROLE_USER_CONFIGURATION");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleUserConfigurations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK2_ROLE_USER_CONFIGURATION");
            });

            modelBuilder.Entity<TransferDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TRANSFER_DTL");

                entity.Property(e => e.BatchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_NO");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.TransferAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRANSFER_AMOUNT");

                entity.Property(e => e.TransferDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSFER_DATE");

                entity.Property(e => e.TransferDepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANSFER_DEPOT_CODE");

                entity.Property(e => e.TransferQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRANSFER_QTY");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_PRICE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<TransferMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TRANSFER_MST");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PmCategoryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.ReceiveDepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVE_DEPOT_CODE");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REF_NO");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.TransferDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSFER_DATE");

                entity.Property(e => e.TransferDepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANSFER_DEPOT_CODE");

                entity.Property(e => e.TransferNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANSFER_NO");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<TransferReceiveDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TRANSFER_RECEIVE_DTL");

                entity.Property(e => e.BatchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_NO");

                entity.Property(e => e.DtlId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DTL_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.PmCategoryCode)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PM_CATEGORY_CODE");

                entity.Property(e => e.PmCode)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PM_CODE");

                entity.Property(e => e.ReceiveAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECEIVE_AMOUNT");

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVE_DATE");

                entity.Property(e => e.ReceiveDepotCode)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECEIVE_DEPOT_CODE");

                entity.Property(e => e.ReceiveQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECEIVE_QTY");

                entity.Property(e => e.TransferAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRANSFER_AMOUNT");

                entity.Property(e => e.TransferQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRANSFER_QTY");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_PRICE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<TransferReceiveMst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TRANSFER_RECEIVE_MST");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MstId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MST_ID");

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVE_DATE");

                entity.Property(e => e.ReceiveDepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVE_DEPOT_CODE");

                entity.Property(e => e.ReceiveNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVE_NO");

                entity.Property(e => e.RefDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REF_DATE");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REF_NO");

                entity.Property(e => e.TransferDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSFER_DATE");

                entity.Property(e => e.TransferDepotCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANSFER_DEPOT_CODE");

                entity.Property(e => e.TransferNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANSFER_NO");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<UnitInfo>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK1_UNIT_INFO");

                entity.ToTable("UNIT_INFO");

                entity.HasIndex(e => e.UnitCode, "UK1_UNIT_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.UnitName, "UK2_UNIT_INFO")
                    .IsUnique();

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UnitCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UNIT_CODE");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UNIT_NAME");

                entity.Property(e => e.UnitShortName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UNIT_SHORT_NAME");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");
            });

            modelBuilder.Entity<UserDefaultPage>(entity =>
            {
                entity.ToTable("USER_DEFAULT_PAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.MenuId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MENU_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_USER_INFO_USER_ID");

                entity.ToTable("USER_INFO");

                entity.HasIndex(e => new { e.UserName, e.UnitId, e.CompanyId }, "UK_USER_INFO")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Uniqueaccesskey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UNIQUEACCESSKEY");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_PASSWORD");

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USER_TYPE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_USER_INFO");
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_USER_LOG_LOG_ID");

                entity.ToTable("USER_LOG");

                entity.Property(e => e.LogId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOG_ID");

                entity.Property(e => e.ActivityTable)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TABLE");

                entity.Property(e => e.ActivityType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE");

                entity.Property(e => e.CompanyId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.Dtl)
                    .IsUnicode(false)
                    .HasColumnName("DTL");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_BY");

                entity.Property(e => e.EnteredDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENTERED_DATE");

                entity.Property(e => e.EnteredTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTERED_TERMINAL");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.LogDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LOG_DATE");

                entity.Property(e => e.PageRef)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PAGE_REF");

                entity.Property(e => e.TransactionId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRANSACTION_ID");

                entity.Property(e => e.UnitId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UNIT_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATED_DATE");

                entity.Property(e => e.UpdatedTerminal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_TERMINAL");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserTerminal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_TERMINAL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK1_USER_LOG_USER_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
