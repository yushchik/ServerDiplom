using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Services
{
    public class ResultService
    {
        UnitOfWork unitOfWork;

        public ResultService(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void Save()
        {
            unitOfWork.Save();
        }
        public IEnumerable<Result> getAllLesson()
        {
            return unitOfWork.Result.GetAll();
        }


        public Result getResultById(int id_lesson)
        {
            foreach (Result u in unitOfWork.Result.GetAll())
            {
                if (u.ID_RESULT.Equals(id_lesson))
                    return u;
            }
            return null;
        }

        public void CreateResult(Result result)
        {
            unitOfWork.Result.Create(result);
            unitOfWork.Save();
        }
    }
}
