using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class TestsResults
    {
        public string NAME_TEST { get; set; }
        public int successfullyPass { get; set; }
        public int failsToPass { get; set; }
        public int allPassed { get; set; }
        public double percent { get; set; }
    }
}
