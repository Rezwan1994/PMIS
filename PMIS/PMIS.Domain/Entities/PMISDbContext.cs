using Microsoft.EntityFrameworkCore;

namespace PMIS.Domain.Entities
{
    public partial class PMISDbContext : DbContext
    {
        public PMISDbContext(DbContextOptions<PMISDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ALLOCATION_DTL> ALLOCATION_DTLs { get; set; } = null!;
        public virtual DbSet<ALLOCATION_MST> ALLOCATION_MSTs { get; set; } = null!;
        public virtual DbSet<BATCH_DATE_WISE_STOCK> BATCH_DATE_WISE_STOCKs { get; set; } = null!;
        public virtual DbSet<BATCH_WISE_STOCK> BATCH_WISE_STOCKs { get; set; } = null!;
        public virtual DbSet<BUDGET_DOCTOR_CATEGORY_DTL> BUDGET_DOCTOR_CATEGORY_DTLs { get; set; } = null!;
        public virtual DbSet<BUDGET_DTL> BUDGET_DTLs { get; set; } = null!;
        public virtual DbSet<BUDGET_MST> BUDGET_MSTs { get; set; } = null!;
        public virtual DbSet<CHALLAN_DTL> CHALLAN_DTLs { get; set; } = null!;
        public virtual DbSet<CHALLAN_MST> CHALLAN_MSTs { get; set; } = null!;
        public virtual DbSet<CHALLAN_RETURN_DTL> CHALLAN_RETURN_DTLs { get; set; } = null!;
        public virtual DbSet<CHALLAN_RETURN_MST> CHALLAN_RETURN_MSTs { get; set; } = null!;
        public virtual DbSet<COMPANY_INFO> COMPANY_INFOs { get; set; } = null!;
        public virtual DbSet<DATE_WISE_STOCK> DATE_WISE_STOCKs { get; set; } = null!;
        public virtual DbSet<DEPOT_INFO> DEPOT_INFOs { get; set; } = null!;
        public virtual DbSet<DOCTOR_CATEGORY_INFO> DOCTOR_CATEGORY_INFOs { get; set; } = null!;
        public virtual DbSet<EMPLOYEE_INFO> EMPLOYEE_INFOs { get; set; } = null!;
        public virtual DbSet<FIELD_FORCE> FIELD_FORCEs { get; set; } = null!;
        public virtual DbSet<MENU_CONFIGURATION> MENU_CONFIGURATIONs { get; set; } = null!;
        public virtual DbSet<MENU_USER_CONFIGURATION> MENU_USER_CONFIGURATIONs { get; set; } = null!;
        public virtual DbSet<MODULE_INFO> MODULE_INFOs { get; set; } = null!;
        public virtual DbSet<NOTIFICATION> NOTIFICATIONs { get; set; } = null!;
        public virtual DbSet<NOTIFICATION_POLICY> NOTIFICATION_POLICies { get; set; } = null!;
        public virtual DbSet<NOTIFICATION_VIEW> NOTIFICATION_VIEWs { get; set; } = null!;
        public virtual DbSet<NOTIFICATION_VIEW_POLICY> NOTIFICATION_VIEW_POLICies { get; set; } = null!;
        public virtual DbSet<PM_CATEGORY_INFO> PM_CATEGORY_INFOs { get; set; } = null!;
        public virtual DbSet<PRODUCTION_SECTION_INFO> PRODUCTION_UNIT_INFOs { get; set; } = null!;
        public virtual DbSet<PROMOTIONAL_MATERIAL_INFO> PROMOTIONAL_MATERIAL_INFOs { get; set; } = null!;
        public virtual DbSet<RECEIVE_DTL> RECEIVE_DTLs { get; set; } = null!;
        public virtual DbSet<RECEIVE_MST> RECEIVE_MSTs { get; set; } = null!;
        public virtual DbSet<REPORT_CONFIGURATION> REPORT_CONFIGURATIONs { get; set; } = null!;
        public virtual DbSet<REPORT_USER_CONFIGURATION> REPORT_USER_CONFIGURATIONs { get; set; } = null!;
        public virtual DbSet<RETURN_CAUSE_INFO> RETURN_CAUSE_INFOs { get; set; } = null!;
        public virtual DbSet<ROLE_INFO> ROLE_INFOs { get; set; } = null!;
        public virtual DbSet<ROLE_MENU_CONFIGURATION> ROLE_MENU_CONFIGURATIONs { get; set; } = null!;
        public virtual DbSet<ROLE_REPORT_CONFIGURATION> ROLE_REPORT_CONFIGURATIONs { get; set; } = null!;
        public virtual DbSet<ROLE_USER_CONFIGURATION> ROLE_USER_CONFIGURATIONs { get; set; } = null!;
        public virtual DbSet<SUPPLIER_INFO> SUPPLIER_INFOs { get; set; } = null!;
        public virtual DbSet<TRANSFER_DTL> TRANSFER_DTLs { get; set; } = null!;
        public virtual DbSet<TRANSFER_MST> TRANSFER_MSTs { get; set; } = null!;
        public virtual DbSet<TRANSFER_RECEIVE_DTL> TRANSFER_RECEIVE_DTLs { get; set; } = null!;
        public virtual DbSet<TRANSFER_RECEIVE_MST> TRANSFER_RECEIVE_MSTs { get; set; } = null!;
        public virtual DbSet<UNIT_INFO> UNIT_INFOs { get; set; } = null!;
        public virtual DbSet<USER_DEFAULT_PAGE> USER_DEFAULT_PAGEs { get; set; } = null!;
        public virtual DbSet<USER_INFO> USER_INFOs { get; set; } = null!;
        public virtual DbSet<USER_LOG> USER_LOGs { get; set; } = null!;
        public virtual DbSet<SBU_INFO> SBU_INFOs { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseOracle("Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.243.234)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME=silsqadb1.squaregroup.com)(SERVER = DEDICATED)));User Id=SPL_PPM;Password=SPLPPM");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SPL_PPM");

            modelBuilder.Entity<ALLOCATION_DTL>(entity =>
            {
                entity.HasKey(e => e.DTL_ID)
                    .HasName("ALLOCATION_DTL_PK");

                entity.ToTable("ALLOCATION_DTL");

                entity.Property(e => e.DTL_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ALLOCATION_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<ALLOCATION_MST>(entity =>
            {
                entity.HasKey(e => e.MST_ID)
                    .HasName("ALLOCATION_MST_PK");

                entity.ToTable("ALLOCATION_MST");

                entity.Property(e => e.MST_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DIVISION_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MARKET_CODE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MARKET_GROUP)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MONTH_CODE)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PRODUCT_GROUP)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.REGION_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TERRITORY_CODE)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.YEAR_CODE)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BATCH_DATE_WISE_STOCK>(entity =>
            {
                entity.HasKey(e => new { e.STOCK_DATE, e.DEPOT_CODE, e.PM_CODE, e.BATCH_NO })
                    .HasName("UK1_BATCH_DATE_WISE_STOCK");

                entity.ToTable("BATCH_DATE_WISE_STOCK");

                entity.Property(e => e.STOCK_DATE).HasColumnType("DATE");

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BATCH_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BATCH_ID).HasPrecision(9);

                entity.Property(e => e.CLOSING_STOCK_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.OPENING_STOCK_QTY).HasColumnType("NUMBER");
            });

            modelBuilder.Entity<BATCH_WISE_STOCK>(entity =>
            {
                entity.ToTable("BATCH_WISE_STOCK");

                entity.HasIndex(e => new { e.DEPOT_CODE, e.PM_CODE, e.BATCH_NO }, "UK1_BATCH_WISE_STOCK")
                    .IsUnique();

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BATCH_ID).HasColumnType("NUMBER(38)");

                entity.Property(e => e.BATCH_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EXPIRY_DATE).HasColumnType("DATE");

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.STOCK_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.UNIT_PRICE).HasColumnType("NUMBER");
            });

            modelBuilder.Entity<BUDGET_DOCTOR_CATEGORY_DTL>(entity =>
            {
                entity.ToTable("BUDGET_DOCTOR_CATEGORY_DTL");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BUDGET_QUANTITY).HasColumnType("NUMBER");

                entity.Property(e => e.DOCTORY_CATEGORY_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DTL_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BUDGET_DTL>(entity =>
            {
                entity.HasKey(e => e.DTL_ID)
                    .HasName("BUDGET_DTL_PK");

                entity.ToTable("BUDGET_DTL");

                entity.Property(e => e.DTL_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BUDGET_QUANTITY).HasColumnType("NUMBER");

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PRODUCTION_UNIT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SBU)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BUDGET_MST>(entity =>
            {
                entity.HasKey(e => e.MST_ID)
                    .HasName("BUDGET_MST_PK");

                entity.ToTable("BUDGET_MST");

                entity.Property(e => e.MST_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BUDGET_DATE).HasColumnType("DATE");

                entity.Property(e => e.BUDGET_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MONTH_CODE)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YEAR_CODE)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CHALLAN_DTL>(entity =>
            {
                entity.HasKey(e => e.DTL_ID)
                    .HasName("CHALLAN_DTL_PK");

                entity.ToTable("CHALLAN_DTL");

                entity.Property(e => e.DTL_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ALLOCATION_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.BATCH_ID).HasPrecision(9);

                entity.Property(e => e.BATCH_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CHALLAN_AMOUNT).HasColumnType("NUMBER");

                entity.Property(e => e.CHALLAN_DATE).HasColumnType("DATE");

                entity.Property(e => e.CHALLAN_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_PRICE).HasColumnType("NUMBER");

                entity.Property(e => e.UNIT_VAT).HasColumnType("NUMBER");

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CHALLAN_MST>(entity =>
            {
                entity.HasKey(e => e.MST_ID)
                    .HasName("CHALLAN_MST_PK");

                entity.ToTable("CHALLAN_MST");

                entity.Property(e => e.MST_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ALLOCATION_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ALLOCATION_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CHALLAN_DATE).HasColumnType("DATE");

                entity.Property(e => e.CHALLAN_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_ECODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MONTH_CODE)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.REMARKS)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YEAR_CODE)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CHALLAN_RETURN_DTL>(entity =>
            {
                entity.HasKey(e => e.DTL_ID)
                    .HasName("CHALLAN_RETURN_DTL_PK");

                entity.ToTable("CHALLAN_RETURN_DTL");

                entity.Property(e => e.DTL_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BATCH_ID).HasPrecision(9);

                entity.Property(e => e.BATCH_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CHALLAN_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RETURN_AMOUNT).HasColumnType("NUMBER");

                entity.Property(e => e.RETURN_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.UNIT_PRICE).HasColumnType("NUMBER");

                entity.Property(e => e.UNIT_VAT).HasColumnType("NUMBER");

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CHALLAN_RETURN_MST>(entity =>
            {
                entity.HasKey(e => e.MST_ID)
                    .HasName("CHALLAN_RETURN_MST_PK");

                entity.ToTable("CHALLAN_RETURN_MST");

                entity.Property(e => e.MST_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ALLOCATION_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CHALLAN_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_ECODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.REMARKS)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RETURN_CAUSE_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RETURN_DATE).HasColumnType("DATE");

                entity.Property(e => e.RETURN_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<COMPANY_INFO>(entity =>
            {
                entity.HasKey(e => e.COMPANY_ID)
                    .HasName("COMPANY_INFO_PK");

                entity.ToTable("COMPANY_INFO");

                entity.Property(e => e.COMPANY_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ADDRESS1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_ADDRESS2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_CODE)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_SHORT_NAME)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<DATE_WISE_STOCK>(entity =>
            {
                entity.ToTable("DATE_WISE_STOCK");

                entity.HasIndex(e => new { e.STOCK_DATE, e.DEPOT_CODE, e.PM_CODE }, "UK1_DATE_WISE_STOCK")
                    .IsUnique();

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.CLOSING_STOCK_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OPENING_STOCK_QTY).HasColumnType("NUMBER");

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.STOCK_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<DEPOT_INFO>(entity =>
            {
                entity.HasKey(e => e.DEPOT_ID)
                    .HasName("DEPOT_INFO_PK");

                entity.ToTable("DEPOT_INFO");

                entity.HasIndex(e => e.DEPOT_CODE, "UK1_DEPOT_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.DEPOT_NAME, "UK2_DEPOT_INFO")
                    .IsUnique();

                entity.Property(e => e.DEPOT_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.DEPOT_ADDRESS)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_NAME)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_SHORT_NAME)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DOCTOR_CATEGORY_INFO>(entity =>
            {
                entity.HasKey(e => e.DOCTOR_CATEGORY_ID)
                    .HasName("DOCTOR_CATEGORY_INFO_PK");

                entity.ToTable("DOCTOR_CATEGORY_INFO");

                entity.HasIndex(e => e.DOCTOR_CATEGORY_CODE, "UK1_DOCTOR_CATEGORY_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.DOCTOR_CATEGORY_NAME, "UK2_DOCTOR_CATEGORY_INFO")
                    .IsUnique();

                entity.Property(e => e.DOCTOR_CATEGORY_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.DOCTOR_CATEGORY_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DOCTOR_CATEGORY_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EMPLOYEE_INFO>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ID);

                entity.ToTable("EMPLOYEE_INFO");

                entity.HasIndex(e => e.EMPLOYEE_CODE, "UK1_EMPLOYEE_INFO")
                    .IsUnique();

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EMPLOYEE_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EMPLOYEE_STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FIELD_FORCE>(entity =>
            {
                entity.ToTable("FIELD_FORCE");

                entity.HasIndex(e => new { e.PRODUCT_GROUP_CODE, e.MARKET_CODE }, "UNIQUE_MARKET_CODE")
                    .IsUnique();

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_NAME)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DEPARTMENT_NAME)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DESIGNATION)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DIVISION_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DIVISION_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EMAIL)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EMPLOYEE_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.JOINING_DATE).HasColumnType("DATE");

                entity.Property(e => e.JOINING_PLACE)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MARKET_CODE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MARKET_GROUP_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MARKET_GROUP_NAME)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MARKET_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PHONE_NO)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PRODUCT_GROUP_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PRODUCT_GROUP_NAME)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.REGION_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.REGION_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TERRITORY_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TERRITORY_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<MENU_CONFIGURATION>(entity =>
            {
                entity.HasKey(e => e.MENU_ID)
                    .HasName("PK_MENU_CONFIGARATION_MENU_ID");

                entity.ToTable("MENU_CONFIGURATION");

                entity.Property(e => e.MENU_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ACTION)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AREA)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.CONTROLLER)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HREF)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MENU_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MENU_SHOW)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MODULE_ID).HasPrecision(9);

                entity.Property(e => e.ORDER_BY_SLNO).HasPrecision(9);

                entity.Property(e => e.PARENT_MENU_ID).HasPrecision(9);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MODULE)
                    .WithMany(p => p.MENU_CONFIGURATIONs)
                    .HasForeignKey(d => d.MODULE_ID)
                    .HasConstraintName("FK_CONFIGARATION");
            });

            modelBuilder.Entity<MENU_USER_CONFIGURATION>(entity =>
            {
                entity.ToTable("MENU_USER_CONFIGURATION");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ADD_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.CONFIRM_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DELETE_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DETAIL_VIEW)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DOWNLOAD_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EDIT_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LIST_VIEW)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENU_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.USER_ID).HasPrecision(9);

                entity.HasOne(d => d.MENU)
                    .WithMany(p => p.MENU_USER_CONFIGURATIONs)
                    .HasForeignKey(d => d.MENU_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_MENU_USER_CONFIGURATION");
            });

            modelBuilder.Entity<MODULE_INFO>(entity =>
            {
                entity.HasKey(e => e.MODULE_ID)
                    .HasName("PK_MODULE_INFO_MODULE_ID");

                entity.ToTable("MODULE_INFO");

                entity.Property(e => e.MODULE_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MODULE_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ORDER_BY_NO).HasPrecision(9);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NOTIFICATION>(entity =>
            {
                entity.HasKey(e => e.NOTIFICATION_ID)
                    .HasName("SYS_C0079618");

                entity.ToTable("NOTIFICATION");

                entity.Property(e => e.NOTIFICATION_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.NOTIFICATION_BODY).HasMaxLength(350);

                entity.Property(e => e.NOTIFICATION_DATE).HasColumnType("DATE");

                entity.Property(e => e.NOTIFICATION_POLICY_ID).HasPrecision(9);

                entity.Property(e => e.NOTIFICATION_TITLE)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_ID).HasPrecision(9);

                entity.Property(e => e.USER_ID).HasPrecision(9);
            });

            modelBuilder.Entity<NOTIFICATION_POLICY>(entity =>
            {
                entity.HasKey(e => e.NOTIFICATION_POLICY_ID)
                    .HasName("SYS_C0079619");

                entity.ToTable("NOTIFICATION_POLICY");

                entity.Property(e => e.NOTIFICATION_POLICY_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.NOTIFICATION_TITLE)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_ID).HasPrecision(9);
            });

            modelBuilder.Entity<NOTIFICATION_VIEW>(entity =>
            {
                entity.ToTable("NOTIFICATION_VIEW");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.NOTIFICATION_ID).HasPrecision(9);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_ID).HasPrecision(9);

                entity.Property(e => e.USER_ID)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VIEW_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<NOTIFICATION_VIEW_POLICY>(entity =>
            {
                entity.ToTable("NOTIFICATION_VIEW_POLICY");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.NOTIFICATION_POLICY_ID).HasPrecision(9);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_ID).HasPrecision(9);

                entity.Property(e => e.USER_ID).HasPrecision(9);

                entity.Property(e => e.VIEW_PERMISSION)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PM_CATEGORY_INFO>(entity =>
            {
                entity.HasKey(e => e.PM_CATEGORY_ID)
                    .HasName("PM_CATEGORY_INFO_PK");

                entity.ToTable("PM_CATEGORY_INFO");

                entity.HasIndex(e => e.PM_CATEGORY_CODE, "UK1_PM_CATEGORY_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.PM_CATEGORY_NAME, "UK2_PM_CATEGORY_INFO")
                    .IsUnique();

                entity.Property(e => e.PM_CATEGORY_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CATEGORY_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.REMARKS)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PRODUCTION_SECTION_INFO>(entity =>
            {
                entity.ToTable("PRODUCTION_SECTION_INFO");

                entity.HasKey(e => e.SECTION_ID)
                    .HasName("PK_PRODUCTION_SECTION_INFO");

                entity.HasIndex(e => e.SECTION_CODE, "UK2_PRODUCTION_SECTION_INFO")
                        .IsUnique();

                entity.HasIndex(e => e.SECTION_NAME, "UK1_PRODUCTION_SECTION_INFO")
                       .IsUnique();

                entity.Property(e => e.UNIT_ID).HasColumnType("NUMBER");

                entity.Property(e => e.SECTION_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.UNIT_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.SECTION_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PROMOTIONAL_MATERIAL_INFO>(entity =>
            {
                entity.HasKey(e => e.PM_ID)
                    .HasName("PROMOTIONAL_MATERIAL_INFO_PK");

                entity.ToTable("PROMOTIONAL_MATERIAL_INFO");

                entity.HasIndex(e => e.PM_CODE, "PK1_PM_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.PM_NAME, "UK1_PM_INFO")
                    .IsUnique();

                entity.Property(e => e.PM_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PACK_SIZE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CATEGORY_ID)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PM_NAME)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RECEIVE_DTL>(entity =>
            {
                entity.HasKey(e => e.DTL_ID)
                    .HasName("RECEIVE_DTL_PK");

                entity.ToTable("RECEIVE_DTL");

                entity.Property(e => e.DTL_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BATCH_ID).HasPrecision(9);

                entity.Property(e => e.BATCH_NO).HasPrecision(9);

                entity.Property(e => e.BUDGET_QUANTITY).HasColumnType("NUMBER(38)");

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DUE_PART_DUE_EXCESS_QUANTITY).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EXPIRY_DATE).HasColumnType("DATE");

                entity.Property(e => e.FROM_SURPLUS_QUANTITY).HasPrecision(9);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.NO_OF_SLOT).HasPrecision(9);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PRODUCTION_UNIT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RECEIVED_QUANTITY).HasColumnType("NUMBER(38)");

                entity.Property(e => e.RECEIVE_AMOUNT).HasColumnType("NUMBER");

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("DATE");

                entity.Property(e => e.SBU)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.STOCK_TRANSFER_ORDER_QUANTITY).HasColumnType("NUMBER(38)");

                entity.Property(e => e.UNIT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_PRICE).HasColumnType("NUMBER");

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<RECEIVE_MST>(entity =>
            {
                entity.HasKey(e => e.MST_ID)
                    .HasName("RECEIVE_MST_PK");

                entity.ToTable("RECEIVE_MST");

                entity.Property(e => e.MST_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BUDGET_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CHALLAN_DATE).HasColumnType("DATE");

                entity.Property(e => e.CHALLAN_NO)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MONTH_CODE)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PO_DATE).HasColumnType("DATE");

                entity.Property(e => e.PO_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("DATE");

                entity.Property(e => e.RECEIVE_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RECEIVE_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SUPPLIER_CODE)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.YEAR_CODE)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<REPORT_CONFIGURATION>(entity =>
            {
                entity.HasKey(e => e.REPORT_ID)
                    .HasName("REPORT_CONFIGURATION_PK");

                entity.ToTable("REPORT_CONFIGURATION");

                entity.Property(e => e.REPORT_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HAS_CSV)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HAS_PDF)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HAS_PREVIEW)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENU_ID).HasPrecision(9);

                entity.Property(e => e.ORDER_BY_SLNO).HasPrecision(9);

                entity.Property(e => e.REPORT_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.REPORT_TITLE)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<REPORT_USER_CONFIGURATION>(entity =>
            {
                entity.ToTable("REPORT_USER_CONFIGURATION");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.CSV_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PDF_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PREVIEW_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.REPORT_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.USER_ID).HasPrecision(9);
            });

            modelBuilder.Entity<RETURN_CAUSE_INFO>(entity =>
            {
                entity.HasKey(e => e.RETURN_CAUSE_ID)
                    .HasName("PK1_RETURN_CAUSE_INFO");

                entity.ToTable("RETURN_CAUSE_INFO");

                entity.HasIndex(e => e.RETURN_CAUSE_CODE, "UK1_RETURN_CAUSE_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.RETURN_CAUSE_NAME, "UK2_RETURN_CAUSE_INFO")
                    .IsUnique();

                entity.Property(e => e.RETURN_CAUSE_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RETURN_CAUSE_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RETURN_CAUSE_NAME)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ROLE_INFO>(entity =>
            {
                entity.HasKey(e => e.ROLE_ID)
                    .HasName("PK_ROLE_INFO_ROLE_ID");

                entity.ToTable("ROLE_INFO");

                entity.Property(e => e.ROLE_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ROLE_NAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ROLE_MENU_CONFIGURATION>(entity =>
            {
                entity.ToTable("ROLE_MENU_CONFIGURATION");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ADD_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.CONFIRM_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DELETE_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DETAIL_VIEW)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DOWNLOAD_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EDIT_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LIST_VIEW)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENU_ID).HasPrecision(9);

                entity.Property(e => e.ROLE_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MENU)
                    .WithMany(p => p.ROLE_MENU_CONFIGURATIONs)
                    .HasForeignKey(d => d.MENU_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2_ROLE_MENU_CONFIGURATION");

                entity.HasOne(d => d.ROLE)
                    .WithMany(p => p.ROLE_MENU_CONFIGURATIONs)
                    .HasForeignKey(d => d.ROLE_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_ROLE_MENU_CONFIGURATION");
            });

            modelBuilder.Entity<ROLE_REPORT_CONFIGURATION>(entity =>
            {
                entity.ToTable("ROLE_REPORT_CONFIGURATION");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.CSV_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PDF_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PREVIEW_PERMISSION)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.REPORT_ID).HasPrecision(9);

                entity.Property(e => e.ROLE_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ROLE_USER_CONFIGURATION>(entity =>
            {
                entity.ToTable("ROLE_USER_CONFIGURATION");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PERMITE_DATE).HasColumnType("DATE");

                entity.Property(e => e.PERMITTED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ROLE_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.USER_ID).HasPrecision(9);

                entity.HasOne(d => d.ROLE)
                    .WithMany(p => p.ROLE_USER_CONFIGURATIONs)
                    .HasForeignKey(d => d.ROLE_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_ROLE_USER_CONFIGURATION");
            });

            modelBuilder.Entity<SUPPLIER_INFO>(entity =>
            {
                entity.ToTable("SUPPLIER_INFO");

                entity.HasKey(e => e.SUPPLIER_ID);

                entity.HasIndex(e => e.SUPPLIER_CODE)
                    .IsUnique();

                entity.Property(e => e.SUPPLIER_ID)
                    .HasPrecision(9);
            });

            modelBuilder.Entity<TRANSFER_DTL>(entity =>
            {
                entity.HasKey(e => e.DTL_ID)
                    .HasName("TRANSFER_DTL_PK");

                entity.ToTable("TRANSFER_DTL");

                entity.Property(e => e.DTL_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BATCH_ID).HasPrecision(9);

                entity.Property(e => e.BATCH_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TRANSFER_AMOUNT).HasColumnType("NUMBER");

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("DATE");

                entity.Property(e => e.TRANSFER_DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TRANSFER_QTY).HasPrecision(9);

                entity.Property(e => e.UNIT_PRICE).HasColumnType("NUMBER");

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<TRANSFER_MST>(entity =>
            {
                entity.HasKey(e => e.MST_ID)
                    .HasName("TRANSFER_MST_PK");

                entity.ToTable("TRANSFER_MST");

                entity.Property(e => e.MST_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PM_CATEGORY_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RECEIVE_DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.REF_DATE).HasColumnType("DATE");

                entity.Property(e => e.REF_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.REMARKS)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("DATE");

                entity.Property(e => e.TRANSFER_DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TRANSFER_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRANSFER_RECEIVE_DTL>(entity =>
            {
                entity.HasKey(e => e.DTL_ID)
                    .HasName("TRANSFER_RECEIVE_DTL_PK");

                entity.ToTable("TRANSFER_RECEIVE_DTL");

                entity.Property(e => e.DTL_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.BATCH_ID).HasPrecision(9);

                entity.Property(e => e.BATCH_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MST_ID).HasPrecision(9);

                entity.Property(e => e.PM_CATEGORY_CODE).HasPrecision(9);

                entity.Property(e => e.PM_CODE).HasPrecision(9);

                entity.Property(e => e.RECEIVE_AMOUNT).HasColumnType("NUMBER");

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("DATE");

                entity.Property(e => e.RECEIVE_DEPOT_CODE).HasPrecision(9);

                entity.Property(e => e.RECEIVE_QTY).HasPrecision(9);

                entity.Property(e => e.TRANSFER_AMOUNT).HasColumnType("NUMBER");

                entity.Property(e => e.TRANSFER_QTY).HasPrecision(9);

                entity.Property(e => e.UNIT_PRICE).HasColumnType("NUMBER");

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<TRANSFER_RECEIVE_MST>(entity =>
            {
                entity.HasKey(e => e.MST_ID)
                    .HasName("TRANSFER_RECEIVE_MST_PK");

                entity.ToTable("TRANSFER_RECEIVE_MST");

                entity.Property(e => e.MST_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RECEIVE_DATE).HasColumnType("DATE");

                entity.Property(e => e.RECEIVE_DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RECEIVE_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.REF_DATE).HasColumnType("DATE");

                entity.Property(e => e.REF_NO)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TRANSFER_DATE).HasColumnType("DATE");

                entity.Property(e => e.TRANSFER_DEPOT_CODE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TRANSFER_NO)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");
            });

            modelBuilder.Entity<UNIT_INFO>(entity =>
            {
                entity.HasKey(e => e.UNIT_ID)
                    .HasName("PK1_UNIT_INFO");

                entity.ToTable("UNIT_INFO");

                entity.HasIndex(e => e.UNIT_CODE, "UK1_UNIT_INFO")
                    .IsUnique();

                entity.HasIndex(e => e.UNIT_NAME, "UK2_UNIT_INFO")
                    .IsUnique();

                entity.Property(e => e.UNIT_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_CODE)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UNIT_SHORT_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USER_DEFAULT_PAGE>(entity =>
            {
                entity.ToTable("USER_DEFAULT_PAGE");

                entity.Property(e => e.ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MENU_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.USER_ID).HasPrecision(9);
            });

            modelBuilder.Entity<USER_INFO>(entity =>
            {
                entity.HasKey(e => e.USER_ID)
                    .HasName("PK_USER_INFO_USER_ID");

                entity.ToTable("USER_INFO");

                entity.HasIndex(e => new { e.USER_NAME, e.DEPOT_ID, e.COMPANY_ID }, "UK_USER_INFO")
                    .IsUnique();

                entity.Property(e => e.USER_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.COMPANY_ID).HasPrecision(9);

                entity.Property(e => e.DEPOT_ID).HasColumnType("NUMBER");

                entity.Property(e => e.EMAIL)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EMPLOYEE_ID).HasPrecision(9);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UNIQUEACCESSKEY)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.USER_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.USER_PASSWORD)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.USER_TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.EMPLOYEE)
                    .WithMany(p => p.USER_INFOs)
                    .HasForeignKey(d => d.EMPLOYEE_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_USER_INFO");
            });

            modelBuilder.Entity<USER_LOG>(entity =>
            {
                entity.HasKey(e => e.LOG_ID)
                    .HasName("PK_USER_LOG_LOG_ID");

                entity.ToTable("USER_LOG");

                entity.Property(e => e.LOG_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();

                entity.Property(e => e.ACTIVITY_TABLE)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ACTIVITY_TYPE)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.COMPANY_ID)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.DTL).IsUnicode(false);

                entity.Property(e => e.ENTERED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ENTERED_DATE).HasColumnType("DATE");

                entity.Property(e => e.ENTERED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LOCATION)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LOG_DATE).HasColumnType("DATE");

                entity.Property(e => e.PAGE_REF)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TRANSACTION_ID).HasColumnType("NUMBER(22,9)");

                entity.Property(e => e.UNIT_ID).HasPrecision(9);

                entity.Property(e => e.UPDATED_BY)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UPDATED_DATE).HasColumnType("DATE");

                entity.Property(e => e.UPDATED_TERMINAL)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.USER_ID).HasPrecision(9);

                entity.Property(e => e.USER_TERMINAL)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<SBU_INFO>(entity =>
            {
                entity.HasKey(e => e.SBU_ID)
                    .HasName("PK_SBU_INFO_SBU_ID");

                entity.ToTable("SBU_INFO");

                entity.Property(e => e.SBU_ID)
                    .HasPrecision(9)
                    .ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}