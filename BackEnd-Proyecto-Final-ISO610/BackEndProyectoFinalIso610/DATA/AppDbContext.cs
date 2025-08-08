using Backend.Models;
using BackEndProyectoFinalIso610.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductCode);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderNumber);
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderNumber, od.ProductCode });
            modelBuilder.Entity<ProductLine>().HasKey(pl => pl.ProductLineName);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeNumber);
            modelBuilder.Entity<Office>().HasKey(o => o.OfficeCode);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerNumber);
            modelBuilder.Entity<Payment>().HasKey(p => new { p.CustomerNumber, p.CheckNumber });

            base.OnModelCreating(modelBuilder);
        }
    }
}
