using System;
using System.Linq;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public interface ICarPurchaseService
    {
        CarPurchaseViewModel Get(int id);
        IQueryable<CarPurchaseViewModel> GetAll();
        IQueryable<CarPurchaseViewModel> Query(Func<CarPurchaseViewModel, bool> query);
    }
}