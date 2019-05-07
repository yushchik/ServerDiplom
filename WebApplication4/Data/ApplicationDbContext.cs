using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<UserChoice> UserChoices { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public ApplicationDbContext()
        {

        }

     

    }
}
