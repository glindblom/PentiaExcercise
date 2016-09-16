using System.Linq;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public interface ISalesPersonService
    {
        SalesPersonViewModel Get(int id);
        IQueryable<SalesPersonViewModel> GetAll();
    }
}