using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApplication.Models;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
             return View();
        }
        [HttpGet]  
        public ActionResult getDetails(string Category,string Name,string Region,string Color,string Range)
        {
            Car_Search1 c1 = new Car_Search1();
            //s5 = s5.Substring(1);
            List<Car> li = c1.getData(Category,Name,Region,Color,Range);
            return View(li);
        }

        [HttpGet]
        public ActionResult filterAsChoice(string[] para)
        {
            ViewBag.Category = new List<string>
            {
                "Sedan",
                "Hatchback",
                "Coupe",
                "Crossover",
                "SUV",
                "MPV"
            };

            ViewBag.Region = new List<string>
            {
                "North","South","East","West"
            };

            ViewBag.CarName = new List<string>
            {
                "Swift",
                "Swift-Dzire",
                "SX4",
                "Sansad"
            };
            ViewBag.Color = new List<string>
            {
                "Black",
                "Blue",
                "Red",
                "Matt-black",
                "Pink",
                "White"

            };
            ViewBag.Price = new List<string>
            {
                "₹10","₹20","₹30","₹40","₹50"

            };
            List<string> li= new List<string>();
            foreach (var s in para)
            {
                li.Add(s);
            }
            ViewBag.filter = li;
            return View();
        }


    }
}