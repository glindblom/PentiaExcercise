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
        private ICarService _carService;
        private ICustomerService _customerService;
        private ISalesPersonService _salesPersonService;

        public CarPurchaseService(ICarPurchaseRepository carPurchaseRepository, ICarService carService, ICustomerService customerService, ISalesPersonService salesPersonService)
        {
            _carPurchaseRepository = carPurchaseRepository;
            _carService = carService;
            _customerService = customerService;
            _salesPersonService = salesPersonService;
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

        public IQueryable<CarPurchaseViewModel> Search(string searchString)
        {
            searchString = searchString.ToLower();
            Predicate<CarPurchase> predicate = carPurchase =>
                    carPurchase.Customer.FirstName.ToLower().Contains(searchString) || carPurchase.Customer.LastName.ToLower().Contains(searchString) ||
                    carPurchase.SalesPerson.Name.ToLower().Contains(searchString) || carPurchase.Car.Make.ToLower().Contains(searchString) ||
                    carPurchase.Car.Model.ToLower().Contains(searchString);


            var result = from carPurchase in _carPurchaseRepository.GetAll()
                         where predicate(carPurchase)
                         select Mapper.CarPurchaseToModel(carPurchase);

            return result;
        }
    }
}