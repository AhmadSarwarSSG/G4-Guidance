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

        public PartialViewResult UserData(){
            return PartialView("_MyPartial");
        }
        public IActionResult Index()
        {
            User_Data_Managment managment = new User_Data_Managment();
            List<User_Data> UserList = managment.getAllUsers();
            ViewBag.List = UserList;
            ViewData["List"] = UserList;
            return View("index", UserList);
        }
        public IActionResult FindUniversity()
        {
            return View();
        }
        public IActionResult Playlist()
        {
            return View();
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
            var context = new G4GuidanceContext();
            LoginInfo info = new LoginInfo();
            if(su.username!=null&&su.password!=null&&su.email!=null)
            {
                if (ModelState.IsValid)
                {
                    info.Username = su.username;
                    info.Email = su.email;
                    info.Password = su.password;
                    context.LoginInfo.Add(info);
                    context.SaveChanges();
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
            var context = new G4GuidanceContext();
            var queryy = context.LoginInfo.Where(u => u.Username == user.username);
            if(user.username!=null&&user.password!=null)
            {
                if (ModelState.IsValid)
                {
                    if (queryy.First().Password==user.password)
                    {
                        ViewBag.User_Data = user;
                        return View("Success", user);
                    }
                    else
                    {
                        return View("Failed");
                    }
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
