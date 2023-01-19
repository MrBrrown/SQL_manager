using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vika_Automate.sakila
{
    public partial class new_databaseContext : DbContext
    {
        public new_databaseContext()
        {
        }

        public new_databaseContext(DbContextOptions<new_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertising> Advertisings { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Production> Productions { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<RawMaterial> RawMaterials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server = localhost; Database = new_database; Uid = root; Pwd = password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertising>(entity =>
            {
                entity.HasKey(e => e.IdAdvertising)
                    .HasName("PRIMARY");

                entity.ToTable("advertising");

                entity.HasIndex(e => e.IdPartner, "id_partner");

                entity.HasIndex(e => e.IdProduct, "id_product");

                entity.Property(e => e.IdAdvertising).HasColumnName("id_advertising");

                entity.Property(e => e.AdFormat)
                    .HasMaxLength(50)
                    .HasColumnName("ad_format");

                entity.Property(e => e.IdPartner).HasColumnName("id_partner");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Price)
                    .HasPrecision(9)
                    .HasColumnName("price");

                entity.HasOne(d => d.IdPartnerNavigation)
                    .WithMany(p => p.Advertisings)
                    .HasForeignKey(d => d.IdPartner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("advertising_ibfk_1");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Advertisings)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("advertising_ibfk_2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.HasIndex(e => e.IdProduct, "id_product");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.FioEmployee)
                    .HasMaxLength(50)
                    .HasColumnName("fio_employee");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(30)
                    .HasColumnName("job_title");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_ibfk_1");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.IdPartner)
                    .HasName("PRIMARY");

                entity.ToTable("partner");

                entity.Property(e => e.IdPartner).HasColumnName("id_partner");

                entity.Property(e => e.FioPartner)
                    .HasMaxLength(50)
                    .HasColumnName("fio_partner");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.Price)
                    .HasPrecision(6)
                    .HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(40)
                    .HasColumnName("product_name");

                entity.Property(e => e.VendorCode)
                    .HasMaxLength(20)
                    .HasColumnName("vendor_code");
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasKey(e => e.IdProduction)
                    .HasName("PRIMARY");

                entity.ToTable("production");

                entity.HasIndex(e => e.IdProduct, "id_product_fk");

                entity.HasIndex(e => e.IdProvider, "id_provider_fk");

                entity.HasIndex(e => e.IdRawMaterial, "id_raw_material_fk");

                entity.Property(e => e.IdProduction).HasColumnName("id_production");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.IdRawMaterial).HasColumnName("id_raw_material");

                entity.Property(e => e.NameProduction)
                    .HasMaxLength(40)
                    .HasColumnName("name_production");

                entity.Property(e => e.ProductionCity)
                    .HasMaxLength(40)
                    .HasColumnName("production_city");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_product_fk");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_provider_fk");

                entity.HasOne(d => d.IdRawMaterialNavigation)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.IdRawMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_raw_material_fk");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PRIMARY");

                entity.ToTable("provider");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("company_name");

                entity.Property(e => e.FioProvider)
                    .HasMaxLength(50)
                    .HasColumnName("fio_provider");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<RawMaterial>(entity =>
            {
                entity.HasKey(e => e.IdRawMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("raw_material");

                entity.HasIndex(e => e.IdProvider, "id_provider");

                entity.Property(e => e.IdRawMaterial).HasColumnName("id_raw_material");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(40)
                    .HasColumnName("material_name");

                entity.Property(e => e.Price)
                    .HasPrecision(9)
                    .HasColumnName("price");

                entity.Property(e => e.Volume).HasColumnName("volume");

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.RawMaterials)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("raw_material_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
