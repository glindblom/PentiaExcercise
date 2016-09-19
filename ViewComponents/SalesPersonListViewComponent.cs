using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Service;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.ViewComponents
{
    public class SalesPersonListViewComponent : ViewComponent
    {
        private ISalesPersonService _salesPersonService;

        public SalesPersonListViewComponent(ISalesPersonService salesPersonService)
        {
            _salesPersonService = salesPersonService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItems();
            return View(items);
        }

        private Task<List<SalesPersonViewModel>> GetItems()
        {
            return _salesPersonService.GetAll().ToListAsync();
        }
    }
}