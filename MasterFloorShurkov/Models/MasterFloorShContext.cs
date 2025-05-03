using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterFloorShurkov.Models;

public partial class MasterFloorShContext : DbContext
{
    public MasterFloorShContext()
    {
    }

    public MasterFloorShContext(DbContextOptions<MasterFloorShContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KPNCLK8\\SQLEXPRESS;Database=MasterFloorSh;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.IdmaterialType);

            entity.ToTable("Material_type");

            entity.Property(e => e.IdmaterialType)
                .ValueGeneratedNever()
                .HasColumnName("IDMaterialType");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Idpartner);

            entity.Property(e => e.Idpartner)
                .HasColumnName("IDPartner");
            entity.Property(e => e.Address).HasMaxLength(550);
            entity.Property(e => e.Director).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.IdpartnerType).HasColumnName("IDPartnerType");
            entity.Property(e => e.Inn)
                .HasMaxLength(50)
                .HasColumnName("INN");
            entity.Property(e => e.NameOrganization).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);

            entity.HasOne(d => d.IdpartnerTypeNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdpartnerType)
                .HasConstraintName("FK_Partners_Partner_type");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.IdpartnerProduct);

            entity.ToTable("Partner_products");

            entity.Property(e => e.IdpartnerProduct)
                .ValueGeneratedNever()
                .HasColumnName("IDPartnerProduct");
            entity.Property(e => e.Idpartner).HasColumnName("IDPartner");

            entity.HasOne(d => d.ArticulNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.Articul)
                .HasConstraintName("FK_Partner_products_Products");

            entity.HasOne(d => d.IdpartnerNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.Idpartner)
                .HasConstraintName("FK_Partner_products_Partners");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.IdpartnerType);

            entity.ToTable("Partner_type");

            entity.Property(e => e.IdpartnerType)
                .ValueGeneratedNever()
                .HasColumnName("IDPartnerType");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Articul);

            entity.Property(e => e.Articul).ValueGeneratedNever();
            entity.Property(e => e.IdmaterialType).HasColumnName("IDMaterialType");
            entity.Property(e => e.IdproductType).HasColumnName("IDProductType");
            entity.Property(e => e.NameProduct).HasMaxLength(250);

            entity.HasOne(d => d.IdmaterialTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdmaterialType)
                .HasConstraintName("FK_Products_Material_type");

            entity.HasOne(d => d.IdproductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdproductType)
                .HasConstraintName("FK_Products_Product_type");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IdproductType);

            entity.ToTable("Product_type");

            entity.Property(e => e.IdproductType)
                .ValueGeneratedNever()
                .HasColumnName("IDProductType");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
