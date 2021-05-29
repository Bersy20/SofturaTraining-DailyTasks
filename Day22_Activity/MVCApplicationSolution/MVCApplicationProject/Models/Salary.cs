using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplicationProject.Models
{
    public class Salary
    {
        [Key]
        public int Salary_Id { get; set; }
        public string TotalSalary { get; set; }        
        public DateTime date { get; set; }
    }
}
