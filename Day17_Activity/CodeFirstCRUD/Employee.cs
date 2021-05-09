using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstProject
{
    class Employee
    {
        [Key]
        public int EId { get; set; }
        public string EName { get; set; }
        public string DOB { get; set; }
        public string Phone { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
        public override string ToString()
        {
            return String.Format(EId + " " + EName + " " + DOB + " " + Phone + " " + Salary + " " +Department);
        }
    }
}
