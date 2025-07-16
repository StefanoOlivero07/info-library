using Library.Core.Models;
using Library.Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Abstractions;

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
            ViewBag.UserSelect = new SelectList(_userRepo.GetAll(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Loan(User model)
        {
            ViewBag.UserId = model.Id;
            model = _userRepo.GetById(model.Id);
            ViewBag.UserName = model.FullName;
            var books = _bookRepo.GetAll();
            return View(books);
        }

        [HttpPost, ActionName("TryLoanBook")]
        public IActionResult Loan(int userId, int bookId)
        {
            var parameters = new Dictionary<string, int>();

            parameters.Add("userId", userId);
            parameters.Add("bookId", bookId);
            if (_loanRepo.IsBookLoaned(bookId))
            {
                ViewBag.Title = "Loan not available";
                return View("LoanNotAvailable", parameters);
            }
            return View();
        }
    }
}
