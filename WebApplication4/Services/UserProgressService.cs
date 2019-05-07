using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Services
{
    public class UserProgressService
    {
        UnitOfWork unitOfWork;

        public UserProgressService(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<UserProgress> getAllUsers()
        {
            return unitOfWork.UserProgress.GetAll();
        }

        public int getLessonIdByUserId(string userId)
        {
            foreach (UserProgress u in unitOfWork.UserProgress.GetAll())
            {
                if (u.User_ID.Equals(userId))
                    return u.Id_Lesson_Learned;
            }
            return 0;
        }

        public UserProgress getUserProgressByUserId(string userId)
        {
            foreach (UserProgress u in unitOfWork.UserProgress.GetAll())
            {
                if (u.User_ID.Equals(userId))
                    return u;
            }
            return null;
        }

        public void ChangProgress(string userId, int newLessonId)
        {
            UserProgress user = getUserProgressByUserId(userId);
            if(user == null)
            {
                UserProgress newUser = new UserProgress();
                newUser.Id_Lesson_Learned = newLessonId;
                newUser.User_ID = userId;
                createUser(newUser);
            }
            else
            {
                user.Id_Lesson_Learned = newLessonId;
                updateUser(user);
            }
            
        }
        public void createUser(UserProgress user)
        {
            unitOfWork.UserProgress.Create(user);
            unitOfWork.Save();
        }
        public void updateUser(UserProgress user)
        {
            unitOfWork.UserProgress.Update(user);
            unitOfWork.Save();
        }
    }
}
