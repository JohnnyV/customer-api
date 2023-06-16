using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Contact
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public string contactType { get; set; }
        public string contactData { get; set; }

        public Contact() { }
         
    }
}