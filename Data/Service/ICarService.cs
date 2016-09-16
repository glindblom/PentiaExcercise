using System.Linq;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public interface ICarService
    {
        CarViewModel Get(int id);
        IQueryable<CarViewModel> Cars();
    }
}