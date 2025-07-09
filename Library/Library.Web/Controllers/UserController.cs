using Library.Data.Repos;
using Library.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _repo;

        public UserController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _repo = new UserRepository(connectionString);
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Users";
            return View(_repo.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create user";
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                string s = user.DateOfBirth.ToString();
                _repo.Add(user);
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Create user";
            return View();
        }

        public IActionResult Update(int id)
        {
            var user = _repo.GetById(id);

            if (user == null) return NotFound();

            ViewBag.Title = "Update user";
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(user);
                return RedirectToAction("Index");
            }

            ViewBag.Title = "Update user";
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _repo.GetById(id);
            if (user == null) return NotFound();

            ViewBag.Title = "Delete user";
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
