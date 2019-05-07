using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class UserProgress
    {
        [Key]
        public int ProgressId { get; set; }
        public string User_ID { get; set; }
        public int Id_Lesson_Learned { get; set; }
    }
}
