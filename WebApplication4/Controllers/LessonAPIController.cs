using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        LessonService qS;
        TestService ts;
        public LessonAPIController(ApplicationDbContext context)
        {
            _context = context;
            qS = new LessonService(context);
            ts = new TestService(context);
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
        [HttpGet("AllLesson/{id_lesson}")]
        public JsonResult Get(int id_lesson)
        {
            return Json(qS.getLessonById(id_lesson));
        }

    }
}