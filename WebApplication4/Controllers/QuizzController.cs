using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class QuizzController : Controller
    {
        int count;
        int testID, QuesId, LessonId;

        public ApplicationDbContext dbContext;
        LessonService qS;
        ResultService rS;
        UserService uS;
        TestService tS;
        UserManager<User> _userManager;
        SignInManager<User> _SignInManager;

        public QuizzController(
                  ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> SignInManager)
        {
            dbContext = context;
            qS = new LessonService(context);
            rS = new ResultService(context);
            uS = new UserService(context);
            tS = new TestService(context);
            _userManager = userManager;
            _SignInManager = SignInManager;
        }
      
        // GET: Quizz
        public ActionResult Index()
        {
            return RedirectToAction("SelectQuizz");
        }

        [HttpGet]
        public ActionResult GetUser()
        {
            return View();
        }

       

        [HttpGet]
        public ActionResult SelectQuizz()
        {
            QuizVM quiz = new QuizVM();
            quiz.ListOfQuizz = dbContext.Tests.Select(q => new SelectListItem
            {
                Text = q.NAME_TEST,
                Value = q.ID_TEST.ToString()

            }).ToList();

            return View(quiz);
        }
      
        [HttpPost]
        public ActionResult SelectQuizz(QuizVM quiz)
        {
            QuizVM quizSelected = dbContext.Tests.Where(q => q.ID_TEST == quiz.QuizID).Select(q => new QuizVM
            {
                QuizID = q.ID_TEST,
                QuizName = q.NAME_TEST,

            }).FirstOrDefault();

            if (quizSelected != null)
            {
                //TempData["SelectedQuiz"] = quizSelected;
                //id_Test = quizSelected.QuizID;
                return RedirectToAction("QuizTest", quizSelected);
            }

            return View();
        }

        [HttpGet]
        public ActionResult QuizTest(QuizVM sendFlag)
        {
            //QuizVM quizSelected = (QuizVM) TempData["SelectedQuiz"] ;
            IQueryable<QuestionVM> questions = null;

            if (sendFlag != null)
            {
                questions = dbContext.Question.Where(q => q.ID_TEST == sendFlag.QuizID)
                   .Select(q => new QuestionVM
                   {
                       QuestionID = q.ID_QUESTION,
                       QuestionText = q.TITLE_QUESTION,
                       Choices = dbContext.Answer.Where(c => c.ID_QUESTION == q.ID_QUESTION).Select(c => new ChoiceVM
                       {
                           ChoiceID = c.ID_ANSWER,
                           ChoiceText = c.ANSWER
                       }).ToList()

                   }).AsQueryable();
                ViewData["TestTitle"] = sendFlag.QuizName;
               // TestId = sendFlag.QuizID;
            }

            return View(questions);
        }

        [HttpPost]
        public ActionResult QuizTest(List<QuizAnswersVM> resultQuiz)
        {
            List<QuizAnswersVM> finalResultQuiz = new List<QuizAnswersVM>();

            foreach (QuizAnswersVM answser in resultQuiz)
            {
                QuizAnswersVM result = dbContext.Answer.Where(a => a.ID_QUESTION == answser.QuestionID).Select(a => new QuizAnswersVM
                {          
                    QuestionID = a.ID_QUESTION,
                    AnswerQ = a.ANSWER,
                    isCorrect = (answser.AnswerQ.ToLower().Equals(a.ANSWER.ToLower()))

                }).FirstOrDefault();

                finalResultQuiz.Add(result);
            }
            
            for(int i = 0; i < finalResultQuiz.Count; i++) { 
                if(finalResultQuiz.ElementAt(i).isCorrect == true)
                    {
                       count++;
                    QuesId = finalResultQuiz.ElementAt(i).QuestionID;
                    }
                    else 
                    {
                    QuesId = finalResultQuiz.ElementAt(i).QuestionID;
                } 
            }
            double correcCount = count;
            double allCount = finalResultQuiz.Count;
            double proc = correcCount / allCount * 100;

            String userName = User.Identity.Name;
            foreach (Question u in dbContext.Question)
            {
                if (u.ID_QUESTION.Equals(QuesId))
                    testID = u.ID_TEST;
               
            }
            //Result Result = dbContext.Tests.Where(a => a.ID_TEST == TestId)
            //    .Select(a => new Result
            //    {
            //        ID_USER = uS.getUserId(userName),
            //        ID_TEST = a.ID_TEST,
            //        RESULT = count3,
            //        RESULT_DATE = DateTime.Now
            //    }).FirstOrDefault();
            Result Result = new Result
            {
                ID_USER = uS.getUserId(userName),
                ID_TEST = testID,
                RESULT = proc,
                RESULT_DATE = DateTime.Now
            };
            rS.CreateResult(Result);
            //if(proc >= 10)
            //{
            //    int nextLes = testID + 1;
            //    //var result1 = new LessonsController(dbContext).ShowLesson(nextLes);
            //    //return result1;
            //    return RedirectToAction("LessonPage", "Lessons", tS.getLessonIdByTestId(nextLes));
            //}
            
            return Json(new { result = finalResultQuiz });


        }
        
        public IActionResult ShowNextLesson(string testName)
        {
            Test test = tS.getLessonIdByTestId(testName);
            int nextLes = test.ID_LESSON + 1;
            return RedirectToAction("ShowLesson", "Lessons", new { id = nextLes });
        }



    }
}