using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ass2_PRN221.Models;
namespace Ass2_PRN221.Data
{
    public class Ass2_PRN221Context : DbContext
    {
        public Ass2_PRN221Context (DbContextOptions<Ass2_PRN221Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(sc => new { sc.ProductID, sc.OrderID });

            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(sc => sc.ProductID);


            modelBuilder.Entity<OrderDetail>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(sc => sc.OrderID);
        }
        public DbSet<Ass2_PRN221.Models.Account> Account { get; set; }
        public DbSet<Ass2_PRN221.Models.Supplier> Supplier { get; set; }
        public DbSet<Ass2_PRN221.Models.Product> Product { get; set; }
        public DbSet<Ass2_PRN221.Models.Order> Order { get; set; }
        public DbSet<Ass2_PRN221.Models.Customer> Customer { get; set; }
        public DbSet<Ass2_PRN221.Models.Category> Category { get; set; }
        public DbSet<Ass2_PRN221.Models.OrderDetail> OrderDetail { get; set; }
    }
}
