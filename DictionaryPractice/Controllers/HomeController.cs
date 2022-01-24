using DictionaryPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DictionaryPractice.Controllers
{
    //client makes a request 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult WordCount(string text)
        {
            var counts = GetCounts(text);
            var vm = new CountsViewModel {Counts = counts };
            return View(vm);
        }


        private Dictionary<char, int> GetCounts(string text)
        {
            Dictionary<char, int> counts = new();
            foreach (char character in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                counts.Add(character, 0);
            }

            foreach (char character in text.ToUpper())
            {
                if (counts.ContainsKey(character))
                {   
                    counts[character]++;
                }
            }

            return counts;
        }
    }
}
