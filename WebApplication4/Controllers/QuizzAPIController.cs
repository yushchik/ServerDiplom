using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        LessonService qS;
        TestService ts;
        public QuizzAPIController(ApplicationDbContext context)
        {
            _context = context;
            qS = new LessonService(context);
            ts = new TestService(context);
        }

        [HttpGet]
        public JsonResult QuizTest([FromHeader]int lessonId)
        {
            //QuizVM quizSelected = (QuizVM) TempData["SelectedQuiz"] ;
            IQueryable<QuestionVM> questions = null;
            int testID = ts.getTestIdById(lessonId);
            if (testID != 0)
            {
                questions = _context.Question.Where(q => q.ID_TEST == testID)
                   .Select(q => new QuestionVM
                   {
                       QuestionID = q.ID_QUESTION,
                       QuestionText = q.TITLE_QUESTION,
                       Choices = _context.Answer.Where(c => c.ID_QUESTION == q.ID_QUESTION).Select(c => new ChoiceVM
                       {
                           ChoiceID = c.ID_ANSWER,
                           ChoiceText = c.ANSWER
                       }).ToList()

                   }).AsQueryable();
               // ViewData["TestTitle"] = sendFlag.QuizName;
              //  TempData["SigmaData"] = questions.Count();
                
                // TestId = sendFlag.QuizID;
            }

            return Json(questions);
        }
    }
}