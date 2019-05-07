using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class UserChoice
    {
        [Key]
        public int ChoiceID { get; set; }
        public string ChoiceText { get; set; }
        public Int32 ID_QUESTION { get; set; }
    }
}
