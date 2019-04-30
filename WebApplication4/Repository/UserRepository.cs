using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext db;
        //private readonly SignInManager<User> _signInManager;
        //private readonly UserManager<User> _userManager;

        //public UserRepository(UserManager<User> userManager,
        //    SignInManager<User> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        public UserRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }
        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        //public User Get(int id)
        //{
        //    return _userManager.Users
        //        Find(id);
        ////}

        //public async Task CreateAsync(User user)
        //{
        //    //var user = new User { UserName = Input.Email, Email = Input.Email, SURNAME = Input.SURNAME };
        //    var result = await _userManager.CreateAsync(user);
        //}

        //public void Update(User user)
        //{
        //    db.Entry(user).State = EntityState.Modified;
        //}

        //public void Delete(int id)
        //{
        //    User user = db.User.Find(id);
        //    if (user != null)
        //        db.User.Remove(user);
        //}

    }
}
