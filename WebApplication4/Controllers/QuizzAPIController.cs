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
        int count;
        public int testID, QuesId, LessonId;
        int allCount;
        LessonService qS;
        TestService ts;
        
        ResultService rS;
        UserService uS;
       
        UserProgressService upS;
        public QuizzAPIController(ApplicationDbContext context)
        {
            _context = context;
            qS = new LessonService(context);
            ts = new TestService(context);
            rS = new ResultService(context);
            uS = new UserService(context);
        }

        [HttpGet]
        public JsonResult QuizTest([FromHeader]int lessonId)
        {
            //QuizVM quizSelected = (QuizVM) TempData["SelectedQuiz"] ;
            IQueryable<QuestionVMA> questions = null;
            int testID = ts.getTestIdById(lessonId);
            if (testID != 0)
            {
                questions = _context.Question.Where(q => q.ID_TEST == testID)
                   .Select(q => new QuestionVMA
                   {
                       QuestionID = q.ID_QUESTION,
                       QuestionText = q.TITLE_QUESTION,
                       Choices = _context.Answer.Where(c => c.ID_QUESTION == q.ID_QUESTION).Select(c => new ChoiceVMA
                       {
                           ChoiceID = c.ID_ANSWER,
                           ChoiceText = c.ANSWER,
                           isTrue = c.ISTRUE_ANSWER
                       }).ToList()

                   }).AsQueryable();
               // ViewData["TestTitle"] = sendFlag.QuizName;
              //  TempData["SigmaData"] = questions.Count();
                
                // TestId = sendFlag.QuizID;
            }

            return Json(questions);
        }

        [HttpPost]
        public JsonResult QuizTest([FromBody]List<QuizAnswersVM> resultQuiz)
        {
            List<QuizAnswersVM> finalResultQuiz = new List<QuizAnswersVM>();

            foreach (QuizAnswersVM answser in resultQuiz)
            {

                QuizAnswersVM result = _context.Answer.Where(a => a.ID_QUESTION == answser.QuestionID).Select(a => new QuizAnswersVM
                {
                    QuestionID = a.ID_QUESTION,
                    AnswerQ = a.ANSWER,
                    isCorrect = (answser.AnswerQ.ToLower().Equals(a.ANSWER.ToLower()))

                }).FirstOrDefault();

                finalResultQuiz.Add(result);
            }

            for (int i = 0; i < finalResultQuiz.Count; i++)
            {
                if (finalResultQuiz.ElementAt(i).isCorrect == true)
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


            String userName = User.Identity.Name;
            foreach (Question u in _context.Question)
            {
                if (u.ID_QUESTION.Equals(QuesId))
                    testID = u.ID_TEST;

            }
           IQueryable<QuestionVM> questions = _context.Question.Where(q => q.ID_TEST == testID)
                  .Select(q => new QuestionVM
                  {
                      QuestionID = q.ID_QUESTION,
                  }).AsQueryable();
            allCount = questions.Count(); /*(int)TempData["SigmaData"]; *///finalResultQuiz.Count;
            double proc = correcCount / allCount * 100;
            Result Result = new Result
            {
                ID_USER = uS.getUserId(userName),
                ID_TEST = testID,
                RESULT = (float)proc,
                RESULT_DATE2 = DateTime.Now
            };
            rS.CreateResult(Result);
            if (proc >= 50)
            {
                UserProgress user = upS.getUserProgressByUserId(uS.getUserId(userName));
                if (user == null)
                {
                    upS.ChangProgress(uS.getUserId(userName), ts.getLessonIdByTestId2(testID));
                }
                else
                {
                    if (user.Id_Lesson_Learned < ts.getLessonIdByTestId2(testID))
                    {
                        upS.ChangProgress(uS.getUserId(userName), ts.getLessonIdByTestId2(testID));
                    }
                }
            }
            else
            {

            }

            return Json(finalResultQuiz);


        }
    }
}