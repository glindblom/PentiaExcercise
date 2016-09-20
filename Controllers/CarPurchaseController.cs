using Microsoft.AspNetCore.Mvc;
using PentiaExcercise.Service;

namespace PentiaExcercise.Controllers
{
    public class CarPurchaseController : Controller
    {
        private ICarPurchaseService _carPurchaseService;

        public CarPurchaseController(ICarPurchaseService carPurchaseService)
        {
            _carPurchaseService = carPurchaseService;
        }

        public IActionResult Index()
        {
            return View(_carPurchaseService.GetAll());
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            searchString += ""; // Ugly way of ensuring the parameter isn't null
            var result = _carPurchaseService.Search(searchString);
            return View("Index", result);
        }
    }
}