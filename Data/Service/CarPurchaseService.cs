using System;
using System.Linq;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public class CarPurchaseService : ICarPurchaseService
    {
        public CarPurchaseViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CarPurchaseViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CarPurchaseViewModel> Query(Func<CarPurchaseViewModel, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}