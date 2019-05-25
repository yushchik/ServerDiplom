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
            uS = new UserService(context);
            upS = new UserProgressService(context);
        }

        //// GET: Lessons
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Lesson.ToListAsync());
        //}

        LessonService qS;
        TestService ts;
        UserService uS;
        UserProgressService upS;

        public IActionResult Index()
        {
            qS.getAllLesson();
            String userName = User.Identity.Name;
            String userID = uS.getUserId(userName);
            ViewData["Progress"] = upS.getLessonIdByUserId(userID);
            return View("Index", qS.getAllLesson());
        }

        public ActionResult ShowLesson(int id)
        {
            Test test = ts.getTestById(id);
            if(test == null)
            {
                ViewData["Test"] = 0;
                return View("LessonPage", qS.getLessonById(id));
            }
            else
            {
                ViewData["Test"] = 1;
                return View("LessonPage", qS.getLessonById(id));
            }
            
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

        public IActionResult ShowNextLesson(int lessonId)
        {
            String userName = User.Identity.Name;
            UserProgress user =  upS.getUserProgressByUserId(uS.getUserId(userName));
            if (user == null)
            {
                upS.ChangProgress(uS.getUserId(userName), lessonId);
            }
            else
            {
                if (user.Id_Lesson_Learned < lessonId)
                {
                    upS.ChangProgress(uS.getUserId(userName), lessonId);
                }
            }

            int nextLes = lessonId + 1;
            Lesson lesson = qS.getLessonById(nextLes);
            if (lesson == null)
            {
                User User = uS.getUser(userName);
                
                return View("Final", User);
            }
            else
            {
                return RedirectToAction("ShowLesson", "Lessons", new { id = nextLes });
            }
        }

    }
}
