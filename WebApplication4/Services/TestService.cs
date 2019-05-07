using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Services
{
    public class TestService
    {

        UnitOfWork unitOfWork;

        public TestService(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }


        public Test getTestById(int id_lesson)
        {
            foreach (Test u in unitOfWork.Tests.GetAll())
            {
                if (u.ID_LESSON.Equals(id_lesson))
                    return u;
            }
            return null;
        }

        public Test getLessonIdByTestId(string testName)
        {
            foreach (Test u in unitOfWork.Tests.GetAll())
            {
                if (u.NAME_TEST.Equals(testName))
                    return u;
            }
            return null;
        }

        public int getLessonIdByTestId2(int testID)
        {
            foreach (Test u in unitOfWork.Tests.GetAll())
            {
                if (u.ID_TEST.Equals(testID))
                    return u.ID_LESSON;
            }
            return 0;
        }
    }
}
