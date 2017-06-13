using BrowserHistory.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BrowserHistory.Controllers
{
    public class ChildController : Controller
    {
        private const string _cookieName = "UserSettings";
        private const string _cookieKey = "cookieKey";
        private const string _cookieVal = "cookieVal";

        public ChildController()
        {
        }

        public ActionResult Index()
        {
            CreateCookie();
            return RedirectToAction("Start");
        }

        public ActionResult Start()
        {
            if(IsCookieExpired())
            {
                return RedirectToAction("Error");
            }

            return View(new Person() { FirstName = "Start" });
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            ExpireCookie();
            return RedirectToAction("Result", new RouteValueDictionary { { "isRedirected", "false" }, { "firstName", person.FirstName } });
        }

        public ActionResult Result(string firstName = null, bool isRedirected = false)
        {
            if(isRedirected)
            {
                return RedirectToAction("About");
            }

            return View(new Person() { FirstName= firstName });
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        private void CreateCookie()
        {
            HttpCookie myCookie = new HttpCookie(_cookieName);
            myCookie.Expires = DateTime.Now.AddDays(+1d);
            myCookie[_cookieKey] = _cookieVal;
            Trace.WriteLine(string.Format("CreateCookie {0}: val: {1} expire: {2}", myCookie.Name, myCookie.Value, myCookie.Expires.ToString()));
            Response.SetCookie(myCookie);
        }

        private bool IsCookieExpired()
        {
            var myCookie = Request.Cookies[_cookieName];
            if (myCookie != null)
            {
                Trace.WriteLine(string.Format("IsCookieExpired {0}: val: {1} expire: {2}", myCookie.Name, myCookie.Value, myCookie.Expires.ToString()));
                return myCookie.Values[_cookieKey] != _cookieVal;
                // return myCookie.Expires < DateTime.Now;
            }

            return true;
         }

        private void ExpireCookie()
        {
            if (Request.Cookies[_cookieName] != null)
            {
                HttpCookie myCookie = new HttpCookie(_cookieName);
                myCookie.Values[_cookieKey] = "blabla";
                //myCookie.Expires = DateTime.Now.AddDays(-1d);
                Trace.WriteLine(string.Format("ExpireCookie {0}: val: {1} expire: {2}", myCookie.Name, myCookie.Value, myCookie.Expires.ToString()));
                Response.SetCookie(myCookie);
            }
        }
    }
}