using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PentiaExcercise.Service;
using PentiaExcercise.ViewModels;

namespace PentiaExcercise.ViewComponents
{
    public class CarPurchaseListViewComponent : ViewComponent
    {
        private ICarPurchaseService _carPurchaseService;

        public CarPurchaseListViewComponent(ICarPurchaseService carPurhcaseService)
        {
            _carPurchaseService = carPurhcaseService;
        }

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