using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrowserHistory.Models
{
    public class Person
    {
        public Person()
        {
            DateOfBirth = new DateTime(1973, 01, 26);
        }

        public string FirstName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}