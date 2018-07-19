using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GPSLocator.Models;

namespace GPSLocator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(ServiceScheduler.ScheduledTasks);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "GPS Locator";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ServiceDetails(string Id)
        {
            var service = ServiceScheduler.ScheduledTasks.First(i => i.ServiceId == Id);
            return View(service);
        }
    }
}
