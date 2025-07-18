﻿using Library.Core.Models;
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
        private readonly BookingRepository _bookingRepo;

        public LoanController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _loanRepo = new LoanRepository(connectionString);
            _bookRepo = new BookRepository(connectionString);
            _userRepo = new UserRepository(connectionString);
            _bookingRepo = new BookingRepository(connectionString);
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
                ViewBag.IsBookable = !_bookingRepo.IsBookAlreadyBooked(bookId);
                return View("LoanNotAvailable", parameters);
            }
            if (_userRepo.CanLoan(userId))
            {
                var loan = new Loan();
             
                loan.UserId = userId;
                loan.BookId = bookId;
                loan.DateOfLoan = DateTime.Now;
                if (_loanRepo.Add(loan) != -1)
                    return View("LoanConfirmed");
                return ValidationProblem("An error occurred while loaning the book");
            }

            return View("TooMuchLoans");
        }
    }
}
