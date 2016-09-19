using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Model;

namespace PentiaExcercise.Context
{
    public class SiteContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPurchase> CarPurchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./site.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasMany(c => c.Purchases)
                        .WithOne(cp => cp.Customer)
                        .HasForeignKey(cp => cp.CustomerId);

            modelBuilder.Entity<SalesPerson>()
                        .HasMany(sp => sp.Sales)
                        .WithOne(cp => cp.SalesPerson)
                        .HasForeignKey(cp => cp.SalesPersonId);
        }
    }
}