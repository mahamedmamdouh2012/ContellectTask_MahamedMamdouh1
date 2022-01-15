using ContellectTask_MahamedMamdouh.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContellectTask_MahamedMamdouh.Controllers
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
          
                HttpContext.Session.Clear();
           
            return View();
        }


        //Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users Loginuser)
        {
            try
            {
                List<Users> LUsers = new List<Users>()
                 {
                  new Users() {UserName="user1",Password="user1" },
                  new Users() {UserName="user2",Password="user2" }
                };
                var userDetails = LUsers.Where(x => x.UserName == Loginuser.UserName && x.Password == Loginuser.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    TempData["msg"] = "UserName or Password in correct";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    HttpContext.Session.SetString("SessionUserName", Loginuser.UserName);
                    return RedirectToAction("Index", "Contacts");
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
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
    }
}
