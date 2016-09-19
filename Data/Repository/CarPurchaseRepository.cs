using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Context;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public class CarPurchaseRepository : ICarPurchaseRepository
    {

        private SiteContext _context;

        public CarPurchaseRepository(SiteContext context)
        {
            _context = context;
        }

        public CarPurchase Get(int id)
        {
            return _context.CarPurchases.Include(cp => cp.Car)
                                        .Include(cp => cp.Customer)
                                        .Include(cp => cp.SalesPerson)
                                        .FirstOrDefault(x => x.CarPurchaseId == id);
        }

        public IQueryable<CarPurchase> GetAll()
        {
            return _context.CarPurchases.Include(cp => cp.Car)
                                        .Include(cp => cp.SalesPerson)
                                        .Include(cp => cp.Customer);
        }

        public IQueryable<CarPurchase> Query(Predicate<CarPurchase> predicate)
        {
            return GetAll().Where(cp => predicate(cp));
        }
    }
}