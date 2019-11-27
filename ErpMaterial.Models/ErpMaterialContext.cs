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
        public virtual DbSet<WasteMaterials> WasteMaterials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ErpMaterial;Integrated Security=True",
                    b => b.UseRowNumberForPaging());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.MaterialCount)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MaterialDesc).HasMaxLength(500);

                entity.Property(e => e.OutStockTime)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProjectName).HasMaxLength(500);

                entity.Property(e => e.ReturnDate)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StorageTime)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TransferTime)
                    .HasMaxLength(10)
                    .IsFixedLength();

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

            modelBuilder.Entity<WasteMaterials>(entity =>
            {
                entity.Property(e => e.WasteMaterialsId).HasColumnName("WasteMaterialsID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
