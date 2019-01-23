using lab11_MyFirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab11_MyFirstMVCApp.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int beginYear,int endYear)
        {
            return RedirectToAction("Results", new { beginYear, endYear });
        }

        [HttpGet]
        public IActionResult Results(int beginYear, int endYear)
        {
           
            return View(TimePerson.GetPersons(beginYear,endYear));
        }


    }
}
