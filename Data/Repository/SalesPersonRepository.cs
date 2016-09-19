using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Context;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public class SalesPersonRepository : ISalesPersonRepository
    {

        private SiteContext _context;

        public SalesPersonRepository(SiteContext context)
        {
            _context = context;
        }

        public SalesPerson Get(int id)
        {
            return _context.SalesPersons.Include(sp => sp.Sales)
                            .ThenInclude(cp => cp.Customer)
                            .ThenInclude(c => c.Purchases)
                            .ThenInclude(cp => cp.Car)
                            .FirstOrDefault(x => x.SalesPersonId == id);
        }

        public IQueryable<SalesPerson> GetAll()
        {
            return _context.SalesPersons.Include(sp => sp.Sales)
                                        .ThenInclude(cp => cp.Customer)
                                        .ThenInclude(c => c.Purchases)
                                        .ThenInclude(cp => cp.Car)
                                        .AsQueryable();
        }

        public IQueryable<SalesPerson> Query(Predicate<SalesPerson> predicate)
        {
            return GetAll().Where(sp => predicate(sp));
        }
    }
}