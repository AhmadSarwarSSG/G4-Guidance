using G4_Guidance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace G4_Guidance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            User_Data_Managment managment = new User_Data_Managment();
            List<User_Data> UserList = managment.getAllUsers();
            ViewBag.List = UserList;
            ViewData["List"] = UserList;
            return View("index", UserList);
        }
        public IActionResult blog()
        {
            return View();
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SignUp(signup su)
        {
            User_Data_Managment managment = new User_Data_Managment();
            if(su.username!=null&&su.password!=null&&su.email!=null)
            {
                if (ModelState.IsValid)
                {
                    managment.insertData(su);
                    return RedirectToAction("index", "home");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
        public IActionResult Login(User_Data user)
        {
            User_Data user2 = new User_Data();
            User_Data_Managment managment = new User_Data_Managment();
            user2.username = user.username;
            if(user.username!=null&&user.password!=null)
            {
                if (ModelState.IsValid)
                {
                    user2 = managment.authneticate(user2);
                    if (user != null)
                    {
                        if (user.password == user2.password)
                        {
                            ViewBag.User_Data = user;
                            return View("Success", user);
                        }
                    }
                    return View("Failed");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
