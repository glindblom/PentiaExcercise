using System;
using System.Linq;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public interface ICustomerService
    {
        CustomerViewModel Get(int id);
        IQueryable<CustomerViewModel> GetAll();
        IQueryable<CustomerViewModel> Query(Func<CustomerViewModel, bool> query);
    }
}