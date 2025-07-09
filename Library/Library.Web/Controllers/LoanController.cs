using Library.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanRepository _loanRepo;
        private readonly BookRepository _bookRepo;

        public LoanController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _loanRepo = new LoanRepository(connectionString);
            _bookRepo = new BookRepository(connectionString);
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Loans";
            return View(_bookRepo.GetAll());
        }

        public IActionResult Loan(int id)
        {
            if (_loanRepo.IsBookLoaned(id))
                return View("LoanNotAvailable", id);
            return View();
        }
    }
}
