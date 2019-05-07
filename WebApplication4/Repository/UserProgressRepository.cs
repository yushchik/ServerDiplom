using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public class UserProgressRepository
    {
        private readonly ApplicationDbContext db;

        public UserProgressRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<UserProgress> GetAll()
        {
            return db.UserProgress;
        }
        public void Update(UserProgress userProgress)
        {
            db.Entry(userProgress).State = EntityState.Modified;
        }
        public void Create(UserProgress user)
        {
            db.UserProgress.Add(user);
        }

    }
}
