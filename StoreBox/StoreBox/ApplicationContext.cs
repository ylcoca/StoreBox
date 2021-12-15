using Microsoft.EntityFrameworkCore;
using StoreBox.Entities;
using System;

namespace StoreBox
{

    public interface IProjectContext : IDisposable
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductType> ProducType { get; set; }
        int SaveChanges();
    }
    public class ApplicationContext : DbContext, IProjectContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<ProductType> ProducType { get; set; }
    }
}
