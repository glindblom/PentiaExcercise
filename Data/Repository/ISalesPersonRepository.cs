using System.Linq;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public interface ISalesPersonRepository
    {
        SalesPerson Get(int id);
        IQueryable<SalesPerson> GetAll();
    }
}