using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class User: IdentityUser
    {
        
        public string SURNAME { get; set; }
        public string NAME { get; set; }
        public string CITY { get; set; }
        public string BIRTHDAY { get; set; }
    }
}
