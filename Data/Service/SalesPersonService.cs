using System;
using System.Linq;
using PentiaExcercise.Model;
using PentiaExcercise.Repository;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.Service
{
    public class SalesPersonService : ISalesPersonService
    {

        private ISalesPersonRepository _salesPersonRepository;

        public SalesPersonService(ISalesPersonRepository salesPersonRepository)
        {
            _salesPersonRepository = salesPersonRepository;
        }

        public SalesPersonViewModel Get(int id)
        {
            var salesPerson = _salesPersonRepository.Get(id);
            return salesPerson != null ? Mapper.SalesPersonToModel(salesPerson) : null;
        }

        public IQueryable<SalesPersonViewModel> GetAll()
        {
            var result = from salesPerson in _salesPersonRepository.GetAll()
                         select Mapper.SalesPersonToModel(salesPerson);
            
            return result;
        }

        public IQueryable<SalesPersonViewModel> Search(string searchString)
        {
            Predicate<SalesPerson> predicate = salesPerson => salesPerson.Address.ToLower().Contains(searchString.ToLower()) || salesPerson.Name.ToLower().Contains(searchString.ToLower());

            var result = from salesPerson in _salesPersonRepository.Query(predicate)
                         select Mapper.SalesPersonToModel(salesPerson);

            return result;
        }
    }
}