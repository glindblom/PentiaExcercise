using System;
using System.Linq;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public class CustomerService : ICustomerService
    {
        public CustomerViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomerViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomerViewModel> Query(Func<CustomerViewModel, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}