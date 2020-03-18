using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ErpMaterial.Models
{
    public partial class ErpMaterialContext : DbContext
    {
        public ErpMaterialContext()
        {
        }

        public ErpMaterialContext(DbContextOptions<ErpMaterialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ErpDetail> ErpDetail { get; set; }
        public virtual DbSet<ErpPlan> ErpPlan { get; set; }
        public virtual DbSet<ErpPurchase> ErpPurchase { get; set; }
        public virtual DbSet<ErpStorage> ErpStorage { get; set; }
        public virtual DbSet<MaterialProcurement> MaterialProcurement { get; set; }
        public virtual DbSet<MaterialStorage> MaterialStorage { get; set; }
        public virtual DbSet<MaterialUse> MaterialUse { get; set; }
        public virtual DbSet<MaterialWithDrawal> MaterialWithDrawal { get; set; }
        public virtual DbSet<PlanReport> PlanReport { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<SysAuthorityInfo> SysAuthorityInfo { get; set; }
        public virtual DbSet<SysDeptInfo> SysDeptInfo { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysNoticeInfo> SysNoticeInfo { get; set; }
        public virtual DbSet<SysRoleAuthority> SysRoleAuthority { get; set; }
        public virtual DbSet<SysRoleInfo> SysRoleInfo { get; set; }
        public virtual DbSet<SysUserInfo> SysUserInfo { get; set; }
        public virtual DbSet<SysUserRole> SysUserRole { get; set; }
        public virtual DbSet<WasteMaterials> WasteMaterials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ErpMaterial;Integrated Security=True",
                    b => b.UseRowNumberForPaging());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ErpDetail>(entity =>
            {
                entity.ToTable("ERP_DETAIL");

                entity.Property(e => e.ErpDetailId).HasColumnName("ERP_DETAIL_ID");

                entity.Property(e => e.Belnr)
                    .HasColumnName("BELNR")
                    .HasMaxLength(500);

                entity.Property(e => e.Bldat)
                    .HasColumnName("BLDAT")
                    .HasMaxLength(500);

                entity.Property(e => e.Budat)
                    .HasColumnName("BUDAT")
                    .HasMaxLength(500);

                entity.Property(e => e.Bwart)
                    .HasColumnName("BWART")
                    .HasMaxLength(500);

                entity.Property(e => e.Ebeln)
                    .HasColumnName("EBELN")
                    .HasMaxLength(500);

                entity.Property(e => e.Ebelp)
                    .HasColumnName("EBELP")
                    .HasMaxLength(500);

                entity.Property(e => e.Kostl)
                    .HasColumnName("KOSTL")
                    .HasMaxLength(500);

                entity.Property(e => e.Ktext)
                    .HasColumnName("KTEXT")
                    .HasMaxLength(500);

                entity.Property(e => e.Kunnr)
                    .HasColumnName("KUNNR")
                    .HasMaxLength(500);

                entity.Property(e => e.Lgort)
                    .HasColumnName("LGORT")
                    .HasMaxLength(500);

                entity.Property(e => e.LgortDesc)
                    .HasColumnName("LGORT_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.Lifnr)
                    .HasColumnName("LIFNR")
                    .HasMaxLength(500);

                entity.Property(e => e.LifnrDesc)
                    .HasColumnName("LIFNR_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.Maktx)
                    .HasColumnName("MAKTX")
                    .HasMaxLength(500);

                entity.Property(e => e.Matkl)
                    .HasColumnName("MATKL")
                    .HasMaxLength(500);

                entity.Property(e => e.Matnr)
                    .HasColumnName("MATNR")
                    .HasMaxLength(500);

                entity.Property(e => e.Mblnr)
                    .HasColumnName("MBLNR")
                    .HasMaxLength(500);

                entity.Property(e => e.Meins)
                    .HasColumnName("MEINS")
                    .HasMaxLength(500);

                entity.Property(e => e.Menge).HasColumnName("MENGE");

                entity.Property(e => e.Mjahr)
                    .HasColumnName("MJAHR")
                    .HasMaxLength(500);

                entity.Property(e => e.Pspel)
                    .HasColumnName("PSPEL")
                    .HasMaxLength(500);

                entity.Property(e => e.Rsnum)
                    .HasColumnName("RSNUM")
                    .HasMaxLength(500);

                entity.Property(e => e.Rspos)
                    .HasColumnName("RSPOS")
                    .HasMaxLength(500);

                entity.Property(e => e.Sobkz)
                    .HasColumnName("SOBKZ")
                    .HasMaxLength(500);

                entity.Property(e => e.Umlgo)
                    .HasColumnName("UMLGO")
                    .HasMaxLength(500);

                entity.Property(e => e.UmlgoDesc)
                    .HasColumnName("UMLGO_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.Umwrk)
                    .HasColumnName("UMWRK")
                    .HasMaxLength(500);

                entity.Property(e => e.Werks)
                    .HasColumnName("WERKS")
                    .HasMaxLength(500);

                entity.Property(e => e.Zthdw)
                    .HasColumnName("ZTHDW")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ErpPlan>(entity =>
            {
                entity.ToTable("ERP_PLAN");

                entity.Property(e => e.ErpPlanId).HasColumnName("ERP_PLAN_ID");

                entity.Property(e => e.Bdmng).HasColumnName("BDMNG");

                entity.Property(e => e.Maktx)
                    .HasColumnName("MAKTX")
                    .HasMaxLength(500);

                entity.Property(e => e.Matnr)
                    .HasColumnName("MATNR")
                    .HasMaxLength(500);

                entity.Property(e => e.Rkpf)
                    .HasColumnName("RKPF")
                    .HasMaxLength(500);

                entity.Property(e => e.Rsnum)
                    .HasColumnName("RSNUM")
                    .HasMaxLength(500);

                entity.Property(e => e.Rspos)
                    .HasColumnName("RSPOS")
                    .HasMaxLength(500);

                entity.Property(e => e.Ztbdw)
                    .HasColumnName("ZTBDW")
                    .HasMaxLength(500);

                entity.Property(e => e.Ztbrq)
                    .HasColumnName("ZTBRQ")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ErpPurchase>(entity =>
            {
                entity.ToTable("ERP_PURCHASE");

                entity.Property(e => e.ErpPurchaseId).HasColumnName("ERP_PURCHASE_ID");

                entity.Property(e => e.Ebeln)
                    .HasColumnName("EBELN")
                    .HasMaxLength(500);

                entity.Property(e => e.Ebelp)
                    .HasColumnName("EBELP")
                    .HasMaxLength(500);

                entity.Property(e => e.Interiorcode)
                    .HasColumnName("INTERIORCODE")
                    .HasMaxLength(500);

                entity.Property(e => e.Lifnr)
                    .HasColumnName("LIFNR")
                    .HasMaxLength(500);

                entity.Property(e => e.LifnrDesc)
                    .HasColumnName("LIFNR_DESC")
                    .HasMaxLength(500);

                entity.Property(e => e.Maktx)
                    .HasColumnName("MAKTX")
                    .HasMaxLength(500);

                entity.Property(e => e.Matnr)
                    .HasColumnName("MATNR")
                    .HasMaxLength(500);

                entity.Property(e => e.Menge).HasColumnName("MENGE");

                entity.Property(e => e.Netpr).HasColumnName("NETPR");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("RELEASE_DATE")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ErpStorage>(entity =>
            {
                entity.ToTable("ERP_STORAGE");

                entity.Property(e => e.ErpStorageId).HasColumnName("ERP_STORAGE_ID");

                entity.Property(e => e.Aging)
                    .HasColumnName("AGING")
                    .HasMaxLength(500);

                entity.Property(e => e.Lgnum)
                    .HasColumnName("LGNUM")
                    .HasMaxLength(500);

                entity.Property(e => e.Lgort)
                    .HasColumnName("LGORT")
                    .HasMaxLength(500);

                entity.Property(e => e.Lgpla)
                    .HasColumnName("LGPLA")
                    .HasMaxLength(500);

                entity.Property(e => e.Lgtyp)
                    .HasColumnName("LGTYP")
                    .HasMaxLength(500);

                entity.Property(e => e.Maktx)
                    .HasColumnName("MAKTX")
                    .HasMaxLength(500);

                entity.Property(e => e.Matkl)
                    .HasColumnName("MATKL")
                    .HasMaxLength(500);

                entity.Property(e => e.Matnr)
                    .HasColumnName("MATNR")
                    .HasMaxLength(500);

                entity.Property(e => e.Msehl)
                    .HasColumnName("MSEHL")
                    .HasMaxLength(500);

                entity.Property(e => e.NameTextc)
                    .HasColumnName("NAME_TEXTC")
                    .HasMaxLength(500);

                entity.Property(e => e.Salk).HasColumnName("SALK");

                entity.Property(e => e.Verme).HasColumnName("VERME");

                entity.Property(e => e.Wdatu)
                    .HasColumnName("WDATU")
                    .HasMaxLength(500);

                entity.Property(e => e.Werks)
                    .HasColumnName("WERKS")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<MaterialProcurement>(entity =>
            {
                entity.Property(e => e.MaterialProcurementId).HasColumnName("MaterialProcurementID");

                entity.Property(e => e.ContractDate).HasMaxLength(500);

                entity.Property(e => e.ContractNo).HasMaxLength(500);

                entity.Property(e => e.MaterialArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.MaterialCode).HasMaxLength(500);

                entity.Property(e => e.MaterialName).HasMaxLength(500);

                entity.Property(e => e.ProcurementPrice).HasMaxLength(50);

                entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(500);

                entity.Property(e => e.Supplier).HasMaxLength(500);
            });

            modelBuilder.Entity<MaterialStorage>(entity =>
            {
                entity.Property(e => e.MaterialStorageId).HasColumnName("MaterialStorageID");

                entity.Property(e => e.ContractNo).HasMaxLength(500);

                entity.Property(e => e.MaterialAge).HasColumnType("datetime");

                entity.Property(e => e.MaterialCode).HasMaxLength(500);

                entity.Property(e => e.MaterialDesc).HasMaxLength(500);

                entity.Property(e => e.PlanReportDateTime).HasColumnType("datetime");

                entity.Property(e => e.PlanReportDept).HasMaxLength(500);

                entity.Property(e => e.PlanReportPerson).HasMaxLength(500);

                entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(500);

                entity.Property(e => e.StorageTime).HasColumnType("datetime");

                entity.Property(e => e.Supplier).HasMaxLength(500);

                entity.Property(e => e.TransferTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MaterialUse>(entity =>
            {
                entity.Property(e => e.MaterialUseId).HasColumnName("MaterialUseID");

                entity.Property(e => e.ContractNo).HasMaxLength(500);

                entity.Property(e => e.DeviceNo).HasMaxLength(500);

                entity.Property(e => e.MaterialAge).HasMaxLength(500);

                entity.Property(e => e.MaterialCode).HasMaxLength(500);

                entity.Property(e => e.MaterialDesc).HasMaxLength(500);

                entity.Property(e => e.OutStockTime).HasColumnType("datetime");

                entity.Property(e => e.StorageTime).HasColumnType("datetime");

                entity.Property(e => e.TransferTime).HasColumnType("datetime");

                entity.Property(e => e.UsePerson).HasMaxLength(500);

                entity.Property(e => e.UserDept).HasMaxLength(500);
            });

            modelBuilder.Entity<MaterialWithDrawal>(entity =>
            {
                entity.Property(e => e.MaterialWithDrawalId).HasColumnName("MaterialWithDrawalID");

                entity.Property(e => e.Custodian).HasMaxLength(500);

                entity.Property(e => e.MaterialCode).HasMaxLength(500);

                entity.Property(e => e.MaterialCount).HasMaxLength(10);

                entity.Property(e => e.MaterialDesc).HasMaxLength(500);

                entity.Property(e => e.OutStockTime).HasMaxLength(10);

                entity.Property(e => e.ProjectName).HasMaxLength(500);

                entity.Property(e => e.ReturnDate).HasMaxLength(10);

                entity.Property(e => e.StorageTime).HasMaxLength(10);

                entity.Property(e => e.TransferTime).HasMaxLength(10);

                entity.Property(e => e.UsePerson).HasMaxLength(500);

                entity.Property(e => e.UserDept).HasMaxLength(500);
            });

            modelBuilder.Entity<PlanReport>(entity =>
            {
                entity.Property(e => e.PlanReportId).HasColumnName("PlanReportID");

                entity.Property(e => e.MaterialAge).HasMaxLength(500);

                entity.Property(e => e.MaterialCode).HasMaxLength(500);

                entity.Property(e => e.MaterialDesc).HasMaxLength(500);

                entity.Property(e => e.PlanReportDateTime).HasColumnType("datetime");

                entity.Property(e => e.PlanReportDept).HasMaxLength(500);

                entity.Property(e => e.PlanReportPerson).HasMaxLength(500);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId).HasColumnName("StockID");

                entity.Property(e => e.BookKeeper).HasMaxLength(500);

                entity.Property(e => e.MaterialCode).HasMaxLength(500);

                entity.Property(e => e.MaterialCount).HasMaxLength(500);

                entity.Property(e => e.MaterialDesc).HasMaxLength(500);

                entity.Property(e => e.MaterialGroup).HasMaxLength(500);

                entity.Property(e => e.StockNum).HasMaxLength(500);

                entity.Property(e => e.StorageTime).HasColumnType("datetime");

                entity.Property(e => e.UnitOfMeasurement).HasMaxLength(500);

                entity.Property(e => e.WarehousePosition).HasMaxLength(500);
            });

            modelBuilder.Entity<SysAuthorityInfo>(entity =>
            {
                entity.HasKey(e => e.AuthorityId)
                    .HasName("PK_dbo.AuthorityInfo");

                entity.Property(e => e.AuthorityId).HasColumnName("AuthorityID");

                entity.Property(e => e.AuthorityDescribe).HasMaxLength(500);

                entity.Property(e => e.AuthorityGroup).HasMaxLength(50);

                entity.Property(e => e.AuthorityName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AuthorityType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MenuFatherId).HasColumnName("MenuFatherID");

                entity.Property(e => e.MenuIcon).HasMaxLength(50);

                entity.Property(e => e.MenuName).HasMaxLength(20);

                entity.Property(e => e.MenuUrl).HasMaxLength(100);
            });

            modelBuilder.Entity<SysDeptInfo>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK_DeptInfo");

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.DeptCreateDate).HasColumnType("datetime");

                entity.Property(e => e.DeptFatherId).HasColumnName("DeptFatherID");

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.DeptRemark).HasMaxLength(200);

                entity.Property(e => e.DeptState).HasMaxLength(50);
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_Log");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Col1).HasMaxLength(500);

                entity.Property(e => e.Col2).HasMaxLength(500);

                entity.Property(e => e.Col3).HasMaxLength(500);

                entity.Property(e => e.Exception).HasMaxLength(1000);

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.LogLevel).HasMaxLength(500);

                entity.Property(e => e.LogPersonId).HasColumnName("LogPersonID");

                entity.Property(e => e.LogPersonName).HasMaxLength(500);

                entity.Property(e => e.LogType).HasMaxLength(10);

                entity.Property(e => e.Message).HasMaxLength(1000);
            });

            modelBuilder.Entity<SysNoticeInfo>(entity =>
            {
                entity.HasKey(e => e.NoticeId)
                    .HasName("PK_Notice");

                entity.Property(e => e.NoticeId).HasColumnName("NoticeID");

                entity.Property(e => e.ContentInfo).HasMaxLength(3000);

                entity.Property(e => e.ContentType).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertPersonNum).HasMaxLength(50);

                entity.Property(e => e.NoticeTitle).HasMaxLength(200);
            });

            modelBuilder.Entity<SysRoleAuthority>(entity =>
            {
                entity.HasKey(e => e.RoleAuthorityId)
                    .HasName("PK_dbo.RoleAuthority");

                entity.Property(e => e.RoleAuthorityId).HasColumnName("RoleAuthorityID");

                entity.Property(e => e.AuthorityId).HasColumnName("AuthorityID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.SysRoleAuthority)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.RoleAuthority_dbo.AuthorityInfo_AuthorityID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SysRoleAuthority)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.RoleAuthority_dbo.RoleInfo_RoleID");
            });

            modelBuilder.Entity<SysRoleInfo>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_dbo.RoleInfo");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.IsDefaultRole)
                    .HasColumnName("isDefaultRole")
                    .HasMaxLength(50);

                entity.Property(e => e.RoleDescribe).HasMaxLength(100);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserAuthorityList).HasMaxLength(1000);

                entity.Property(e => e.UserDeptCtrlChildList).HasMaxLength(1000);

                entity.Property(e => e.UserDeptCtrlList).HasMaxLength(1000);

                entity.Property(e => e.UserDeptId).HasColumnName("UserDeptID");

                entity.Property(e => e.UserDuty).HasMaxLength(10);

                entity.Property(e => e.UserEmail).HasMaxLength(10);

                entity.Property(e => e.UserMobile).HasMaxLength(10);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserNum).HasMaxLength(50);

                entity.Property(e => e.UserPhone).HasMaxLength(10);

                entity.Property(e => e.UserPwd).HasMaxLength(100);

                entity.Property(e => e.UserRemark).HasMaxLength(500);

                entity.Property(e => e.UserRoleList).HasMaxLength(1000);

                entity.Property(e => e.UserState).HasMaxLength(50);
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<WasteMaterials>(entity =>
            {
                entity.Property(e => e.WasteMaterialsId).HasColumnName("WasteMaterialsID");
            });
        }
    }
}
