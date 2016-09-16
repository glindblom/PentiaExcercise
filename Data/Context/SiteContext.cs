using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Model;

namespace PentiaExcercise.Context
{
    public class SiteContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPurchase> CarPurchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./site.db");
        }
    }
}