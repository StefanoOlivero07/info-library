using Library.Data.Repos;
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

        public IActionResult Loan(int id)
        {
            if (_loanRepo.IsBookLoaned(id))
            {
                ViewBag.Title = "Loan is not available";
                ViewBag.SelectUser = new SelectList(_userRepo.GetAll(), "Id", "Name - Surname");
                return View("LoanNotAvailable");
            }
            
            return View();
        }
    }
}
