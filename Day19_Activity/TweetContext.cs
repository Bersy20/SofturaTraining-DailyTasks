using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Model
{
    public class TweetContext : DbContext
    {
        private const string connectionString = "Server=LAPTOP-Q1S49BFG;Integrated Security=true;Database=dbTweet";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //OnModelCreating it will save the first info to the table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id=1,
                PostText="Text",
                Category="Info"
            });
        }
    }
}
