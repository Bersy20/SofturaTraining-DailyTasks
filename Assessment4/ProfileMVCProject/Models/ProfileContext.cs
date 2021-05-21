using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCProject.Models
{
    public class ProfileContext:DbContext
    {
        public ProfileContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Profile> Profiles { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
                new Profile() { Id = 1, Name = "Bersy", Age = 22,Qualification="B.E",IsEmployed="Yes",NoticePeriod="3 yrs",CurrentCTC=25000 });
        }
    }
}
