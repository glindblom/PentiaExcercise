using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Service;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.ViewComponents
{
    /// <summary>
    /// View component to fetch and display a list of CarPurchaseViewModels async
    /// </summary>
    public class CarPurchaseListViewComponent : ViewComponent
    {
        private ICarPurchaseService _carPurchaseService;

        public CarPurchaseListViewComponent(ICarPurchaseService carPurhcaseService)
        {
            _carPurchaseService = carPurhcaseService;
        }

        /// <summary>
        /// /// Invokes the async fetch
        /// </summary>
        /// <returns>The view registered to the ViewComponent, at /Views/Shared/Components/{ViewComponent}/Default.cshtml</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItems();
            return View(items);
        }     

        private Task<List<CarPurchaseViewModel>> GetItems()
        {
            return _carPurchaseService.GetAll().ToListAsync();
        }
    }
}