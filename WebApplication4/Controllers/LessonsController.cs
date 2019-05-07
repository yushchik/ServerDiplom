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
            ts = new TestService(context);
        }

        //// GET: Lessons
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Lesson.ToListAsync());
        //}

        LessonService qS;
        TestService ts;

        public IActionResult Index()
        {
            return View("Index", qS.getAllLesson());
        }

        public ActionResult ShowLesson(int id)
        {
            return View("LessonPage", qS.getLessonById(id));
        }
        
        public IActionResult StartTest(int id)
        {
            QuizVM quizSelected = _context.Tests.Where(q => q.ID_LESSON == id).Select(q => new QuizVM
            {
                QuizID = q.ID_TEST,
                QuizName = q.NAME_TEST,

            }).FirstOrDefault();

            if (quizSelected != null)
            {
                //TempData["SelectedQuiz"] = quizSelected;
                //id_Test = quizSelected.QuizID;
                return RedirectToAction("QuizTest", "Quizz", quizSelected);
            }
            return View("LessonPage", qS.getLessonById(id));
            // return RedirectToAction("SelectQuizz",, ts.getTestById(id));
        }

    }
}
