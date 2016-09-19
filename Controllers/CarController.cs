using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PentiaExcercise.Service;

namespace PentiaExcercise.Controllers
{
    public class CarController : Controller
    {

        private ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View(_carService.Cars().AsEnumerable());
        }
    }
}