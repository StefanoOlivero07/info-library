using Library.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingRepository _repo;

        public BookingController(IConfiguration configuration)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            _repo = new BookingRepository(connStr);
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Bookings";
            var bookings = _repo.GetAll();
            return View(bookings);
        }

        //public IActionResult Add(int idBook)
        //{
            
        //}
    }
}
