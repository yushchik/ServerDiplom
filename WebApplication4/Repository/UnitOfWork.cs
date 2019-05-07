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

        private TestRepository testRepository;
        public TestRepository Tests
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        private ResultRepository resultRepository;
        public ResultRepository Result
        {
            get
            {
                if (resultRepository == null)
                    resultRepository = new ResultRepository(db);
                return resultRepository;
            }
        }

        private UserProgressRepository userProgressRepository;
        public UserProgressRepository UserProgress
        {
            get
            {
                if (userProgressRepository == null)
                    userProgressRepository = new UserProgressRepository(db);
                return userProgressRepository;
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
