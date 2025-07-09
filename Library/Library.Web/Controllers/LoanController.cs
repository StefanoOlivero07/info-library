using Library.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanRepository _repo;

        public LoanController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _repo = new LoanRepository(connectionString);
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Loans";
            return View(_repo.GetAll());
        }
    }
}
