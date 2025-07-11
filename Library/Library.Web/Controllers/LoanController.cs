using Library.Data.Repos;
using Library.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Web.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanRepository _loanRepo;
        private readonly BookRepository _bookRepo;
        private readonly UserRepository _userRepo;

        public LoanController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _loanRepo = new LoanRepository(connectionString);
            _bookRepo = new BookRepository(connectionString);
            _userRepo = new UserRepository(connectionString);
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Loans";
            return View(_userRepo.GetAll());
        }

        public IActionResult Loan(User user)
        {
            var books = _bookRepo.GetAll();
            ViewBag.UserId = user.Id;
            ViewBag.UserName = user.Name;
            return View(books);
        }
    }
}
