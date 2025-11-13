using Microsoft.AspNetCore.Mvc;

namespace SportsStoreWebApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.content = "Hello";
            return View();
        }
        public IActionResult Welcome(string name = "guest")
        {
            return Content($"Hello, {name}!");
        }
    }
}
