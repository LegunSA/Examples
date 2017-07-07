using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBase.Models
{
    public partial class FileTracer_DataBaseContext : DbContext
    {
        public virtual DbSet<ClientSet> ClientSet { get; set; }
        public virtual DbSet<ManagerSet> ManagerSet { get; set; }
        public virtual DbSet<ProductSet> ProductSet { get; set; }
        public virtual DbSet<ReportSet> ReportSet { get; set; }
        public virtual DbSet<SaleLogSet> SaleLogSet { get; set; }

      //  public FileTracer_DataBaseContext(DbContextOptions<FileTracer_DataBaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Pavilion\SQLExpress;Database=FileTracer.DataBase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientSet>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ManagerSet>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProductSet>(entity =>
            {
                entity.Property(e => e.ProductName).IsRequired();
            });

            modelBuilder.Entity<ReportSet>(entity =>
            {
                entity.HasIndex(e => e.ManagerId)
                    .HasName("IX_FK_ReportManager");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ManagerId).HasColumnName("Manager_Id");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ReportSet)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ReportManager");
            });

            modelBuilder.Entity<SaleLogSet>(entity =>
            {
                entity.HasIndex(e => e.ClientId)
                    .HasName("IX_FK_SaleLogClient");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_FK_ProductSaleLog");

                entity.HasIndex(e => e.ReportId)
                    .HasName("IX_FK_ReportSaleLog");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ReportId).HasColumnName("Report_Id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.SaleLogSet)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SaleLogClient");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleLogSet)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductSaleLog");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.SaleLogSet)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ReportSaleLog");
            });
        }
    }
}