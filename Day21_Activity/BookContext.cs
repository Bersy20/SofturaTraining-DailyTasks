using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApplication.Models
{
   
        public class BookContext : DbContext
        {
            public BookContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Book> Books { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Book>().HasData(
                    new Book() { Id = 1, Title = "Fairy Tales", Price = 98, Author_Id=101 });
            }

        }
    
}
