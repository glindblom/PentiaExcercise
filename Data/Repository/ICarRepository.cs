using System;
using System.Linq;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public interface ICarRepository
    {
        Car Get(int id);
        IQueryable<Car> GetAll();
    }
}