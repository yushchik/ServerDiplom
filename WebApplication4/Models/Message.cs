using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Message
    {
        [Key]
        public string messageCode { get; set; }
        public string userId { get; set; }
    }
}
