using System;
using System.Linq;
using PentiaExcercise.Model;
using PentiaExcercise.Repository;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public class CarPurchaseService : ICarPurchaseService
    {

        private ICarPurchaseRepository _carPurchaseRepository;

        public CarPurchaseService(ICarPurchaseRepository carPurchaseRepository)
        {
            _carPurchaseRepository = carPurchaseRepository;
        }

        public CarPurchaseViewModel Get(int id)
        {
            var carPurchase = _carPurchaseRepository.Get(id);
            return carPurchase != null ? Mapper.CarPurchaseToModel(carPurchase) : null;
        }

        public IQueryable<CarPurchaseViewModel> GetAll()
        {
            var result = from carPurchase in _carPurchaseRepository.GetAll()
                         select Mapper.CarPurchaseToModel(carPurchase);
            return result;
        }

        public IQueryable<CarPurchaseViewModel> Query(Predicate<CarPurchase> query)
        {
            var result = from carPurchase in _carPurchaseRepository.GetAll()
                         where query(carPurchase)
                         select Mapper.CarPurchaseToModel(carPurchase);

            return result;
        }
    }
}