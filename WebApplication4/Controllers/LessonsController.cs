using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonsController(ApplicationDbContext context)
        {
            _context = context;
            qS = new LessonService(context);
        }

        //// GET: Lessons
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Lesson.ToListAsync());
        //}

        LessonService qS;
      

        public IActionResult Index()
        {
            return View("Index", qS.getAllLesson());
        }

        public IActionResult ShowLesson(int id)
        {
            return View("LessonPage", qS.getLessonById(id));
        }
    }
}
