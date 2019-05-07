using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public class TestRepository
    {
        private readonly ApplicationDbContext db;

        public TestRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Test> GetAll()
        {
            return db.Tests;
        }
      

        public Test Get(int id)
        {
            return db.Tests.Find(id);
        }
    }
}
