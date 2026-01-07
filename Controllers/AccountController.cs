using Microsoft.AspNetCore.Mvc;
using SimpleLoginApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLoginApp.Controllers
{
    public class AccountController : Controller
    {
        // Temporary in-memory users
        static List<User> users = new List<User>();

        // Register page
        public IActionResult Register()
        {
            return View();
        }

        // Save registered user
        [HttpPost]
        public IActionResult Register(User user)
        {
            users.Add(user);
            return RedirectToAction("Login");
        }

        // Login page
        public IActionResult Login()
        {
            return View();
        }

        // Validate login
        [HttpPost]
        public IActionResult Login(User user)
        {
            var validUser = users.FirstOrDefault(
                u => u.Username == user.Username && u.Password == user.Password
            );

            if (validUser != null)
            {
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}

