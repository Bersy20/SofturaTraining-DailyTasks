using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplicationProject.Models
{
    public class User
    {
       
        public int UserId { get; set; }
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
