using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RegistrationMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMVCProject.Services
{
    public class EmployeeManager : IEmpRepo<Employee>
    {
        private UserContext _context;
        private ILogger<EmployeeManager> _logger;

        public EmployeeManager(UserContext context, ILogger<EmployeeManager> logger)
        {
            _context = context;
            _logger = logger;
        }
       
        public Employee Get(int id)
        {
            try
            {
                Employee employee = _context.Employees.FirstOrDefault(a => a.Emp_Id==id);
                return employee;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                if (_context.Employees.Count() == 0)
                    return null;
                return _context.Employees
                    .Include(e => e.Salaries)
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }      
    }
}
