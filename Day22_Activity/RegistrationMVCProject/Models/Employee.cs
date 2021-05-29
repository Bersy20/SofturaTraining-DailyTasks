using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationMVCProject.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }      
        public string Name { get; set; }       
        public string Age { get; set; }      
        public List<Salary> Salaries { get; set; }
    }
}
