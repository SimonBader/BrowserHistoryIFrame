using BrowserHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrowserHistory.Controllers
{
    public class ChildController : Controller
    {
        private static string _firstName;

        // GET: Child
        public ActionResult Index()
        {
            return View(new Person() { FirstName = "Index" });
        }

        //[HttpPost]
        public ActionResult Create(string firstName)
        {
            _firstName = firstName;
            return RedirectToAction("Result");
        }

        public ActionResult Result()
        {
            return View(new Person() { FirstName=_firstName});
        }
    }
}