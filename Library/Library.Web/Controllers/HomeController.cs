﻿using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return RedirectToAction("Index");
        }
    }
}
