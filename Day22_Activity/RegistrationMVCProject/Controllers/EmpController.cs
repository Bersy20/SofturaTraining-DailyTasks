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
    public class EmpController : Controller
    {
        private ILogger<EmpController> _logger;
        private IRepo<Employee> _empRepo;


        public EmpController(IRepo<Employee> empRepo, ILogger<EmpController> logger)
        {
            _logger = logger;
            _empRepo = empRepo;
        }
        
        public IActionResult Display()
        {
            List<Employee> employees = _empRepo.GetAll().ToList();
            return View(employees);
        }
        [HttpPost]
        public IActionResult Display(Employee employee)
        {
            return RedirectToAction("Display");
        }

    }
}
