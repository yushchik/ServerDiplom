using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Answer
    {
        [Key]
        public Int32 ID_ANSWER { get; set; }
        public Int32 ID_QUESTION { get; set; }
        public string ANSWER { get; set; }
        public Int32 ISTRUE_ANSWER { get; set; }

    }
}
