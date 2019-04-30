using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Question
    {
        [Key]
        public Int32 ID_QUESTION { get; set; }
        public Int32 ID_TEST { get; set; }
        public string TITLE_QUESTION { get; set; }
        public Int32 COST { get; set; }

    }
}
