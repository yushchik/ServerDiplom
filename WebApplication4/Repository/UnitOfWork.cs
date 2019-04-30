using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication4.Data;

namespace WebApplication4.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        private UserRepository userTebleRepository;

        public UserRepository Users
        {
            get
            {
                if (userTebleRepository == null)
                    userTebleRepository = new UserRepository(db);
                return userTebleRepository;
            }
        }

        private LessonRepository lessonRepository;
        public LessonRepository Lessons
        {
            get
            {
                if (lessonRepository == null)
                    lessonRepository = new LessonRepository(db);
                return lessonRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
