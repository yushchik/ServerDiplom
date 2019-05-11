using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonAPIController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        LessonService qS;
        TestService ts;
        UserService uS;
        UserProgressService upS;
        public LessonAPIController(ApplicationDbContext context,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _context = context;
            qS = new LessonService(context);
            ts = new TestService(context);
            uS = new UserService(context);
            upS = new UserProgressService(context);
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Список всех уроков
        // GET: api/<controller>
        [HttpGet("AllLesson")]
        public JsonResult Get()
        {
            return Json(qS.getAllLesson());
        }

        // получить конкретный урок
        // GET: api/<controller>
        [HttpGet("OneLesson")]
        public JsonResult Get([FromHeader]int id_lesson)
        {
            return Json(qS.getLessonById(id_lesson));
        }

        [HttpGet("Progress")]
        public JsonResult Get([FromHeader]String userName)
        {
           // qS.getAllLesson();
           // String userName = User.Identity.Name;
            String userID = uS.getUserId(userName);
            return Json(upS.getLessonIdByUserId(userID));
        }

        [HttpGet("HasATest")]
        public JsonResult Get([FromHeader]double id)
        {

            int idT = (int)id;
            Test test = ts.getTestById(idT);
            if (test == null)
            {
                return Json("0");
            }
            else
            {
                return Json("1");
            }

        }

    }
}