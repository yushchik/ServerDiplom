using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public class ResultRepository
    {
        private readonly ApplicationDbContext db;

        public ResultRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Result> GetAll()
        {
            return db.Result;
        }

        public Result Get(int id)
        {
            return db.Result.Find(id);
        }

        public void Create(Result result)
        {
            db.Result.Add(result);
        }
    }
}
