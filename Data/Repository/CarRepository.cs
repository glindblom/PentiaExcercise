using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Context;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public class CarRepository : ICarRepository
    {

        private SiteContext _context;

        public CarRepository(SiteContext context)
        {
            _context = context;
        }

        public IQueryable<Car> GetAll()
        {
            return _context.Cars.AsQueryable();
        }

        public Car Get(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.CarId == id);
        }
    }
}