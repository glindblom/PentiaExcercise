using System;
using System.Linq;
using PentiaExcercise.Model;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public interface ICustomerService
    {
        CustomerViewModel Get(int id);
        IQueryable<CustomerViewModel> GetAll();
        IQueryable<CustomerViewModel> Search(string searchString);
    }
}