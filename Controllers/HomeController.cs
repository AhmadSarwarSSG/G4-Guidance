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
            ViewBag.Data = UserList;
            foreach(User_Data u in UserList)
            {
                string ss = u.username;
            }
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
        [Route("home/signup")]
        [HttpPost]
        public IActionResult SignUp(string email, string username, string password)
        {
            User_Data user = new User_Data();
            User_Data_Managment managment = new User_Data_Managment();
            user.username = username;
            user.email = email;
            user.password = password;
            if(username!=null&&password!=null&&email!=null)
            {
                managment.insertData(user);
            }
            return View("index");
        }
        [Route("home/Login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            User_Data user = new User_Data();
            User_Data_Managment managment = new User_Data_Managment();
            user.username = username;
            if (username != null && password != null)
            {
                user = managment.authneticate(user);
                if (user != null)
                {
                    if (user.password == password)
                    {
                        ViewBag.User_Data = user;
                        return View("Success", user);
                    }
                }
                return View("Failed");
            }
            return View("index");
        }
    }
}
