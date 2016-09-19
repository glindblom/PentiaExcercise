using System;
using System.Linq;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public interface ICarPurchaseRepository
    {
        CarPurchase Get(int id);
        IQueryable<CarPurchase> GetAll();
        IQueryable<CarPurchase> Query(Predicate<CarPurchase> predicate);
    }
}