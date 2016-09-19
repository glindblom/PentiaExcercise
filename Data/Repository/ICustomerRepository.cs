using System;
using System.Linq;
using PentiaExcercise.Model;

namespace PentiaExcercise.Repository
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
        IQueryable<Customer> GetAll(); 
        IQueryable<Customer> Query(Predicate<Customer> predicate);
    }
}