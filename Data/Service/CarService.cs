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
                         select Mapper.CarToModel(car);
            return result;
        }

        public CarViewModel Get(int id)
        {
            var car = _repository.Get(id);
            return car != null ? Mapper.CarToModel(car) : null;
        }

        public IQueryable<CarViewModel> Search(string searchString)
        {
            searchString = searchString.ToLower();
            Predicate<Car> predicate = car =>
                car.Make.ToLower().Contains(searchString) || 
                car.Model.ToLower().Contains(searchString) || 
                car.Color.ToLower().Contains(searchString) || 
                car.Extras.ToLower().Contains(searchString);

            var result = from car in _repository.GetAll()
                         where predicate(car)
                         select Mapper.CarToModel(car);

            return result;
        }
    }
}