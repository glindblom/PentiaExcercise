using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Service;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.ViewComponents
{
    /// <summary>
    /// View component to fetch and display a list of SalesPersonViewModels
    /// </summary>
    public class SalesPersonListViewComponent : ViewComponent
    {
        private ISalesPersonService _salesPersonService;

        public SalesPersonListViewComponent(ISalesPersonService salesPersonService)
        {
            _salesPersonService = salesPersonService;
        }

        /// <summary>
        /// Invokes the async fetch
        /// </summary>
        /// <returns>The view registered to the ViewComponent, at /Views/Shared/Components/{ViewComponent}/Default.cshtml</returns>
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