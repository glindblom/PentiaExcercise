using System;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Context;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private SiteContext _context;

        public CustomerRepository(SiteContext context)
        {
            _context = context;
        }

        public Customer Get(int id)
        {
            return _context.Customers.Include(c => c.Purchases)
                                     .ThenInclude(cp => cp.SalesPerson)
                                     .ThenInclude(sp => sp.Sales)
                                     .ThenInclude(cp => cp.Car)
                                     .FirstOrDefault(x => x.CustomerId == id);
        }

        public IQueryable<Customer> GetAll()
        {
            return _context.Customers.Include(c => c.Purchases)
                                     .ThenInclude(cp => cp.SalesPerson)
                                     .ThenInclude(sp => sp.Sales)
                                     .ThenInclude(cp => cp.Car)
                                     .AsQueryable();
        }

        public IQueryable<Customer> Query(Predicate<Customer> predicate)
        {
            return GetAll().Where(c => predicate(c));
        }
    }
}