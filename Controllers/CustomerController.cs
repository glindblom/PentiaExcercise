using Microsoft.AspNetCore.Mvc;
using PentiaExcercise.Service;

namespace PentiaExcercise.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View(_customerService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_customerService.Get(id));
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            searchString += ""; // Ugly way of ensuring the parameter isn't null
            var result = _customerService.Search(searchString);
            return View("Index", result);
        }
    }
}