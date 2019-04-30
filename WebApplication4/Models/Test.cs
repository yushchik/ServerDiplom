using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Test
    {
        [Key]
        public Int32 ID_TEST { get; set; }
        public string NAME_TEST { get; set; }
        public Int32 ID_LESSON { get; set; }

    }
}
