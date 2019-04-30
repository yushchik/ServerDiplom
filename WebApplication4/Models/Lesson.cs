using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Lesson
    {
        [Key]
        public Int32 ID_LESSON { get; set; }
        public string TITLE_LESSON { get; set; }
        public int ID_SECTION { get; set; }
        public string INFORMATION { get; set; }
        public string VIDEO { get; set; }

    }
}
