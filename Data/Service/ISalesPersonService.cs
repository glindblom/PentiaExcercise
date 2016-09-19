using System;
using System.Linq;
using PentiaExcercise.Model;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public interface ISalesPersonService
    {
        SalesPersonViewModel Get(int id);
        IQueryable<SalesPersonViewModel> GetAll();
        IQueryable<SalesPersonViewModel> Query(Predicate<SalesPerson> query);
    }
}