using System;
using System.Linq;
using PentiaExcercise.Model;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public interface ICarService
    {
        CarViewModel Get(int id);
        IQueryable<CarViewModel> Cars();
        IQueryable<CarViewModel> Search(string searchString);
    }
}