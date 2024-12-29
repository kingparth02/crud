using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud.Models
{
    public class Emp
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public string Hobby { get; set; }
        public DateTime doj { get; set; }
    }
}