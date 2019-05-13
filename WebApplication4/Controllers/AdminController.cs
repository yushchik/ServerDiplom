using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class AdminController : Controller
    {
        UserService uS;
        LessonService lS;
        UserProgressService upS;
        TestService tS;
        ResultService rS;

        //public UserAPIController(ApplicationDbContext context)
        //{
        //    uS = new UserService(context);

        //}
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<UserAPIController> _logger;
        private readonly UserManager<User> _userManager;

        public AdminController(
            SignInManager<User> signInManager,
            ILogger<UserAPIController> logger,
            ApplicationDbContext context,
            UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            uS = new UserService(context);
            lS = new LessonService(context);
            tS = new TestService(context);
            rS = new ResultService(context);
            upS = new UserProgressService(context);
            _userManager = userManager;
        } 


        public IActionResult Index()
        {
            List<User> finalResultQuiz = new List<User>();
            finalResultQuiz = uS.getAllUsers().ToList();
            List<UsersForAdmin>  usersForAdmins = new List<UsersForAdmin>();
            
            for (int i = 0; i < finalResultQuiz.Count; i++)
            {
                UsersForAdmin users = new UsersForAdmin();
                users.Email = finalResultQuiz.ElementAt(i).Email;
                users.SURNAME = finalResultQuiz.ElementAt(i).SURNAME;
                users.NAME = finalResultQuiz.ElementAt(i).NAME;
                users.CITY = finalResultQuiz.ElementAt(i).CITY;
                users.BIRTHDAY = finalResultQuiz.ElementAt(i).BIRTHDAY;
                users.TITLELESSON = lS.getLessonTitleById(upS.getLessonIdByUserId(uS.getUserId(users.Email)));
                usersForAdmins.Add(users);
            }
            
            return View("Index", usersForAdmins);
        }


        public IActionResult Results()
        {
            List<Test> tests = new List<Test>();
            tests = tS.getAllTests().ToList();
            List<Result> testsResults = new List<Result>();
            testsResults = rS.getAllLesson().ToList();
            List<TestsResults> results = new List<TestsResults>();

            for (int i = 0; i < tests.Count; i++)
            {

                TestsResults testsresults = new TestsResults();
                List<Result> testsResults2 = new List<Result>();
                testsResults2 = rS.getResultByTest(tests.ElementAt(i).ID_TEST);
                int successfullyPass = 0, failsToPass = 0;
                double percent;
                for (int j = 0; j < testsResults2.Count; j++)
                {

                    if (testsResults2.ElementAt(j).RESULT >= 50)
                    {
                        successfullyPass++;
                    }
                    else
                    {
                        failsToPass++;
                    }

                }
                double testcount = testsResults2.Count;
                double count = successfullyPass;
                if (count != 0)
                {
                    percent = successfullyPass / testcount * 100;
                }
                else
                {
                    percent = 0;
                }
                testsresults.NAME_TEST = tS.getTestNameById(tests.ElementAt(i).ID_TEST);
                testsresults.allPassed = testsResults2.Count;
                testsresults.successfullyPass = successfullyPass;
                testsresults.failsToPass = failsToPass;
                testsresults.percent = percent;
                results.Add(testsresults);
            }
            return View("Results", results);
        }
    }
}