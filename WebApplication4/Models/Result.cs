using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Result
    {
        [Key]
        public Int32 ID_RESULT { get; set; }
        public string ID_USER { get; set; }
        public Int32 ID_TEST { get; set; }
        public double RESULT { get; set; }
        public DateTime RESULT_DATE { get; set; }

    }
}
