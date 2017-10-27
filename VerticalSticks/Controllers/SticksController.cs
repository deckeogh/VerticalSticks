using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VerticalSticks.Models;

namespace VerticalSticks.Controllers
{
    public class SticksController : ApiController
    {
        Stick[] sticks = new Stick[]
        {
            new Stick { Id = 1,  StickHeights = "1 2 3 4 5" },
            new Stick { Id = 2,  StickHeights = "3 3 3 4 5" },
            new Stick { Id = 3,  StickHeights = "2 2 3" },
            new Stick { Id = 4,  StickHeights = "10 2 4 4" },
            new Stick { Id = 5,  StickHeights = "10 10 10 5 10" },
            new Stick { Id = 6,  StickHeights = "1 2 3 4 5 6 7" }
        };

        public IEnumerable<Stick> GetAllSticks()
        {
            return sticks;
        }

        public IHttpActionResult GetStick(int id)
        {
            var stick = sticks.FirstOrDefault((p) => p.Id == id);
            string[] Stats = AverageScore(stick.StickHeights);
            stick.AverageScore = Stats[0];
            stick.Permutations = Stats[1];
            if (stick == null)
            {
                return NotFound();
            }
            return Ok(stick);
        }
        static string[] AverageScore(string stickHeights)
        {
            string[] caseList = stickHeights.Split(' ');
            int[] caseIntegers = Array.ConvertAll(caseList, s => int.Parse(s));
            double sumScores = 0;
            string[] stats = { "", "" };
            System.Numerics.BigInteger permutations = 1;
            for (var i = 0; i <= caseIntegers.Length - 1; i++)
            {
                int elementScore = caseIntegers.Count(item => item >= caseIntegers[i]);
                sumScores = sumScores + ((double)(caseIntegers.Length + 1) / (double)(elementScore + 1));
                permutations = permutations * (i + 1);
                stats = new string[] {sumScores.ToString(), permutations.ToString()};
            }
            return stats;
        }
    }
}
