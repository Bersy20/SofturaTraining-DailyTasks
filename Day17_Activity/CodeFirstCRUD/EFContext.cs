using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstProject
{
    class EFContext:DbContext
    {
        public EFContext()
        { }

        private const string connectionString = "Server=.;Database=SofturaCF;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
