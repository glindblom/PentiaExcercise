using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Service;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.ViewComponents
{
    /// <summary>
    /// View component to fetch and display a list of CustomerViewModels async
    /// </summary>
    public class CustomerListViewComponent : ViewComponent
    {
        private ICustomerService _customerService;

        public CustomerListViewComponent(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Invokes the async fetch
        /// </summary>
        /// <returns>The view registered to the ViewComponent, at /Views/Shared/Components/{ViewComponent}/Default.cshtml</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }


        private Task<List<CustomerViewModel>> GetItemsAsync()
        {
            return _customerService.GetAll().ToListAsync();
        }
    }
}