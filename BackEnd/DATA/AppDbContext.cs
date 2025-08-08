using Backend.Models;
using BackEndProyectoFinalIso610.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
        public DbSet<ProductLine> productlines { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Office> offices { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Payment> payments { get; set; }

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
