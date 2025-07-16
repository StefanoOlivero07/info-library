using Library.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingRepository _bookingRepo;
        private readonly BookRepository _bookRepo;

        public BookingController(IConfiguration configuration)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            _bookingRepo = new BookingRepository(connStr);
            _bookRepo = new BookRepository(connStr);
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Bookings";
            return View(_bookRepo.GetBookedBooks());
        }

        public IActionResult Book(int userId, int bookId)
        {
            _bookingRepo.AddBooking(userId, bookId);

            return View();
        }
    }
}
