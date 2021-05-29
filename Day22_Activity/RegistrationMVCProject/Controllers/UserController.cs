using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistrationMVCProject.Models;
using RegistrationMVCProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMVCProject.Controllers
{
    public class UsersController : Controller
    {
        private ILogger<UsersController> _logger;
        private IRepo<User> _repo;


        public UsersController(IRepo<User> repo, ILogger<UsersController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        // GET: UsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersController/Details/5


        // GET: UsersController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                _repo.Register(user);
                TempData["un"] = user.Username;
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Login
        public ActionResult Login()
        {
            if (TempData.Count == 0)
                return View();

            User user = new User();
            user.Username = TempData.Peek("un").ToString();
            return View(user);
        }

        // POST: UsersController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                if (_repo.Login(user))
                    return RedirectToAction("DisplayMove");
            }
            catch
            {
                return View();
            }
            return View();
        }

        //GET: UsersController/Delete/5
        public IActionResult DisplayMove()
        {
            return RedirectToAction("Display", "Emp");
        }
    }
}
