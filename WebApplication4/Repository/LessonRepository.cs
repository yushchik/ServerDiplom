using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;

namespace WebApplication4.Repository
{
    public class LessonRepository
    {

        private readonly ApplicationDbContext db;

        public LessonRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Lesson> GetAll()
        {
            return db.Lesson;
        }

        public Lesson Get(int id)
        {
            return db.Lesson.Find(id);
        }

        public void Create(Lesson Lesson)
        {
            db.Lesson.Add(Lesson);
        }
    }
}
