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
            Predicate<Car> predicate = car => car.Make.ToLower().Contains(searchString.ToLower())
                                                || car.Model.ToLower().Contains(searchString.ToLower())
                                                || car.Color.ToLower().Contains(searchString.ToLower())
                                                || car.Extras.ToLower().Contains(searchString.ToLower());

            var result = from car in _repository.Query(predicate)
                         select Mapper.CarToModel(car);

            return result;
        }
    }
}