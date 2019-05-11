using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Repository;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class UserService
    {
        UnitOfWork unitOfWork;

        public UserService(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<User> getAllUsers()
        {
            return unitOfWork.Users.GetAll();
        }

        public User getUserByLogin(string userLogin)
        {
            foreach (User u in unitOfWork.Users.GetAll())
            {
                if (u.UserName.Equals(userLogin))
                    return u;
            }
            return null;
        }

        public String getUserId(string userNane)
        {
            foreach (User u in unitOfWork.Users.GetAll())
            {
                if (u.UserName.Equals(userNane))
                    return u.Id;
            }
            return "";
        }
        public User getUser(string userNane)
        {
            foreach (User u in unitOfWork.Users.GetAll())
            {
                if (u.UserName.Equals(userNane))
                    return u;
            }
            return null;
        }
        public void ChangePassword(string password, string userLogin)
        {
            User user = getUserByLogin(userLogin);
            user.PasswordHash = password;
            updateUser(user);
        }
        public void Save()
        {
            unitOfWork.Save();
        }
        public void updateUser(User user)
        {
            unitOfWork.Users.Update(user);
        }

        //    public bool checkExistLogAndEmail(string login, string email)//оставил и такую, вдруг пригодится)
        //    {
        //        foreach (User u in unitOfWork.Users.GetAll())
        //        {
        //            if (u.UserName.Equals(login) || u.Email.Equals(email))
        //                return false;
        //        }
        //        return true;
        //    }

        //    public bool checkExistEmail(string email)
        //    {
        //        foreach (User u in unitOfWork.Users.GetAll())
        //        {
        //            if (u.Email.Equals(email))
        //                return false;
        //        }
        //        return true;
        //    }

        //    public bool checkExistLogin(string login)
        //    {
        //        foreach (User u in unitOfWork.Users.GetAll())
        //        {
        //            if (u.UserName.Equals(login))
        //                return false;
        //        }
        //        return true;
        //    }

        //    public User getUserByLogin(string userLogin)
        //    {
        //        foreach (User u in unitOfWork.Users.GetAll())
        //        {
        //            if (u.UserName.Equals(userLogin))
        //                return u;
        //        }
        //        return null;
        //    }

        //    public void ChangePassword(string password, string userLogin)
        //    {
        //        User user = getUserByLogin(userLogin);
        //        user.PasswordHash = password;
        //        updateUser(user);
        //    }

        //    //public void deleteUser(int id)
        //    //{
        //    //    unitOfWork.Users.Delete(id);
        //    //    unitOfWork.Save();
        //    //}
        //    //public User getUserById(int id)
        //    //{
        //    //    return unitOfWork.Users.Get(id);
        //    //}

        //    public void updateUser(User user)
        //    {
        //        unitOfWork.Users.Update(user);
        //    }



        //    public void createUser(User user)
        //    {
        //        unitOfWork.Users.CreateAsync(user);
        //        unitOfWork.Save();
        //    }

        //    public bool checkExistUser(string login, string password)
        //    {
        //        foreach (User user in unitOfWork.Users.GetAll())
        //        {
        //            if (user.UserName.Equals(login) && user.PasswordHash.Equals(password))
        //                return true;
        //        }
        //        return false;
        //    }
        //}
    }
}
