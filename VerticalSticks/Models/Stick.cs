using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerticalSticks.Models
{
    public class Stick
    {
        public int Id { get; set; }
        public string StickHeights { get; set; }
        public string AverageScore { get; set; }
        public string Permutations { get; set; }
    }
}