using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public IActionResult Home()
        {
            ViewBag.Title = "Home";
            return View("Index");
        }
    }
}
