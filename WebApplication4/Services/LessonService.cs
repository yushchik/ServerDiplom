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

        public void saveAnswer(string information, int id, string title, string video)
        {
            Lesson q = unitOfWork.Lessons.Get(id);
            q.TITLE_LESSON = title;
            q.INFORMATION = information;
            q.VIDEO = video;
            unitOfWork.Lessons.Update(q);
            unitOfWork.Save();
        }

        public void createLesson(string information, int id, string title, string video)
        {
            Lesson q = new Lesson();
            q.TITLE_LESSON = title;
            q.INFORMATION = information;
            q.VIDEO = video;
            unitOfWork.Lessons.Create(q);
            unitOfWork.Save();
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

        public String getLessonTitleById(int id_lesson)
        {
            foreach (Lesson u in unitOfWork.Lessons.GetAll())
            {
                if (u.ID_LESSON.Equals(id_lesson))
                    return u.TITLE_LESSON;
            }
            return null;
        }

        public void CreateLesson(Lesson lesson)
        {
            unitOfWork.Lessons.Create(lesson);
            unitOfWork.Save();
        }

        public int nextL(int id_lesson)
        {
            foreach (Lesson u in unitOfWork.Lessons.GetAll())
            {
                if (u.ID_LESSON.Equals(id_lesson))
                    return u.ID_LESSON;               
            }
            return 0;
        }
    }
}
