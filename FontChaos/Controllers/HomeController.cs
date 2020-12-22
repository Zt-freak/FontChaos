using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FontChaos.Models;

namespace FontChaos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string text)
        {
            string chaosText = "";
            Random rnd = new Random();
            if (text != null)
            {
                foreach (char character in text)
                {
                    int randFont = rnd.Next(1, 4);

                    chaosText += "<span style=\"font-family:";

                    switch (randFont)
                    {
                        case 1:
                            chaosText += "serif";
                            break;
                        case 2:
                            chaosText += "sans-serif";
                            break;
                        case 3:
                            chaosText += "monospace";
                            break;
                    }

                    chaosText += "; color:";

                    int randR = rnd.Next(1, 255);
                    int randG = rnd.Next(1, 255);
                    int randB = rnd.Next(1, 255);

                    chaosText += "rgb(" + randR + "," + randG + "," + randB + ");\">";
                    chaosText += character;
                    chaosText += "</span>";
                }
            }
            ViewBag.ChaosText = chaosText;
            Console.WriteLine("test");
            Console.WriteLine(ViewBag.chaosText);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
