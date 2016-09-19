using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Service;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.ViewComponents
{
    public class CustomerListViewComponent : ViewComponent
    {
        private ICustomerService _customerService;

        public CustomerListViewComponent(ICustomerService customerService)
        {
            _customerService = customerService;
        }

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