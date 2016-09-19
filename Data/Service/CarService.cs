using System;
using System.Linq;
using PentiaExcercise.Model;
using PentiaExcercise.Repository;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public class CarService : ICarService
    {

        private ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<CarViewModel> Cars()
        {
            var result = from car in _repository.GetAll()
                         select CarToModel(car);
            return result;
        }

        public IQueryable<CarViewModel> Query(Predicate<Car> predicate)
        {
            var result = from car in _repository.GetAll()
                         where predicate(car)
                         select CarToModel(car);
            return result;
        }

        public CarViewModel Get(int id)
        {
            var car = _repository.Get(id);
            return car != null ? CarToModel(car) : null;
        }

        private CarViewModel CarToModel(Car car)
        {
            return new CarViewModel()
            {
                CarId = car.CarId,
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                Extras = car.Extras,
                RecommendedPrice = car.RecommendedPrice
            };
        }
    }
}