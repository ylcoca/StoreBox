using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace StoreBox.Models
{
   /* public interface IStoreBoxDBContext : IDisposable
    {
        public DbSet<Order> Orders();
        public DbSet<ProducType> ProducTypes();
        public DbSet<ProductOrder> ProductOrders();
    }*/

    public partial class StoreBoxDBContext : DbContext
    {
        public StoreBoxDBContext()
        {
        }

        public StoreBoxDBContext(DbContextOptions<StoreBoxDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProducType> ProducTypes { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
            });

            modelBuilder.Entity<ProducType>(entity =>
            {
                entity.HasKey(e => e.ProductTypeID);

                entity.ToTable("ProducType");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductTypeID });

                entity.ToTable("ProductOrder");

                entity.HasIndex(e => e.ProductTypeID, "IX_ProductOrder_ProductTypeID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.ProductTypeID);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
