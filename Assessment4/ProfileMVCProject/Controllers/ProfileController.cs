using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileMVCProject.Models;
using ProfileMVCProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCProject.Controllers
{
    public class ProfileController : Controller
    {
        private ILogger<ProfileController> _logger;
        private IRepo<Profile> _repo;


        public ProfileController(IRepo<Profile> repo, ILogger<ProfileController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public ActionResult FrontIndex()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<Profile> profiles = _repo.GetAll().ToList();
            return View(profiles);
        }
        public ActionResult Register()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            Profile profile = _repo.Get(id);
            return View(profile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Profile profile)
        {
            _repo.Update(id, profile);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Profile profile = _repo.Get(id);
            return View(profile);
        }
        [HttpPost]
        public IActionResult Delete(Profile profile)
        {
            _repo.Delete(profile);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Profile profile = _repo.Get(id);
            return View(profile);
        }
        [HttpPost]
        public IActionResult Details(Profile profile)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Profile profile)
        {
            try
            {
                _repo.Register(profile);
                TempData["name"] = profile.Name;
                return RedirectToAction("Login");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult Login()
        {
            if (TempData.Count == 0)
                return View();

            Profile profile = new Profile();
            profile.Name = TempData.Peek("name").ToString();
            return View(profile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Profile profile)
        {
            try
            {
                if (_repo.Login(profile))
                    return RedirectToAction("Success");
            }
            catch
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Error");
        }
        public ActionResult Error(Profile profile)
        {
            return View();
        }
        public ActionResult Success(Profile profile)
        {
            return View();
        }
    }
}
