using System;
using System.Linq;
using PentiaExcercise.Model;
using PentiaExcercise.Repository;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public class CustomerService : ICustomerService
    {

        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerViewModel Get(int id)
        {
            var customer = _customerRepository.Get(id);
            return customer != null ? Mapper.CustomerToModel(customer) : null;
        }

        public IQueryable<CustomerViewModel> GetAll()
        {
            var result = from customer in _customerRepository.GetAll()
                         select Mapper.CustomerToModel(customer);

            return result;
        }

        public IQueryable<CustomerViewModel> Query(Predicate<Customer> predicate)
        {
            var result = from customer in _customerRepository.GetAll()
                         where predicate(customer)
                         select Mapper.CustomerToModel(customer);
            return result;
        }

        public IQueryable<CustomerViewModel> Search(string searchString)
        {
            searchString = searchString.ToLower();
            Predicate<Customer> predicate = customer =>
                    customer.Address.ToLower().Contains(searchString) ||
                    $"{customer.FirstName} {customer.LastName}".ToLower().Contains(searchString);

            var result = from customer in _customerRepository.GetAll()
                         where predicate(customer)
                         select Mapper.CustomerToModel(customer);

            return result;
        }
    }
}