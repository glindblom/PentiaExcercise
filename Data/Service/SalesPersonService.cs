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

        public IQueryable<SalesPersonViewModel> Query(Predicate<SalesPerson> predicate)
        {
            var result = from salesPerson in _salesPersonRepository.GetAll()
                         where predicate(salesPerson)
                         select Mapper.SalesPersonToModel(salesPerson);

            return result;
        }
    }
}