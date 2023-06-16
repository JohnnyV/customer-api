using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Document
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public string fileName { get; set; }

        public Document() { }
         
    }
}