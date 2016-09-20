using Microsoft.AspNetCore.Mvc;
using PentiaExcercise.Service;

namespace PentiaExcercise.Controllers
{
    public class SalesPersonController : Controller
    {
        private ISalesPersonService _salesPersonService;

        public SalesPersonController(ISalesPersonService salesPersonService)
        {
            _salesPersonService = salesPersonService;
        }

        public IActionResult Index()
        {
            return View(_salesPersonService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_salesPersonService.Get(id));
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            searchString += ""; // Ugly way of ensuring the parameter isn't null
            return View("Index", _salesPersonService.Search(searchString));
        }
    }
}