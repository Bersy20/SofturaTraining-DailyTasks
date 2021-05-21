using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeathersAPIProject.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        [Key]
        public string City { get; set; }
        public float HighTemperature { get; set; }
        public float LowTemperature { get; set; }
        public string Forcast { get; set; }
    }
}
