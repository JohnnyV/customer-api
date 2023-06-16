using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Customer
    {
        public int id { get; set; }
        public int TIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer() { }
         
    }
}