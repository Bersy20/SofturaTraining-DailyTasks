using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeathersAPIProject.Models
{
    public class WeatherContext:DbContext
    {
        public WeatherContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Weather> Weathers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>().HasData(
                new Weather() { Date = DateTime.Today, City = "Hosur", HighTemperature = 36, LowTemperature = 21, Forcast = "Rains" });
        }
    }
}
