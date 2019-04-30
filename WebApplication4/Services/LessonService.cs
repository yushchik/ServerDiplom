using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Services
{
    public class LessonService
    {
        UnitOfWork unitOfWork;

        public LessonService(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void Save()
        {
            unitOfWork.Save();
        }
        public IEnumerable<Lesson> getAllLesson()
        {
            return unitOfWork.Lessons.GetAll();
        }


        public Lesson getLessonById(int id_lesson)
        {
            foreach (Lesson u in unitOfWork.Lessons.GetAll())
            {
                if (u.ID_LESSON.Equals(id_lesson))
                    return u;
            }
            return null;
        }

        public void CreateLesson(Lesson lesson)
        {

            unitOfWork.Lessons.Create(lesson);
            unitOfWork.Save();
        }
    }
}
