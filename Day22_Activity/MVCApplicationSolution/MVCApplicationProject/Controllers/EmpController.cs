using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApplicationProject.Models;
using MVCApplicationProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplicationProject.Controllers
{
    public class EmpController : Controller
    {
        private ILogger<EmpController> _logger;
        private IRepo<Employee> _empRepo;


        public EmpController(IRepo<Employee> empRepo, ILogger<EmpController> logger)
        {
            _logger = logger;
            _empRepo = empRepo;
        }
        public ActionResult Register()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Employee employee)
        {
            try
            {
                _empRepo.Register(employee);
                TempData["un"] = employee.Name;
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

            Employee employee = new Employee();
            employee.Name = TempData.Peek("un").ToString();
            return View(employee);
        }
        public IActionResult Display(int id)
        {
            Employee employees = _empRepo.Get(id);
            return View(employees);
        }
        [HttpPost]
        public IActionResult Display(Employee employee)
        {
            return RedirectToAction("Display");
        }

    }
}
