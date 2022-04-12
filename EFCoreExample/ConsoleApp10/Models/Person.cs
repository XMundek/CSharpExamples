using System;
using System.Collections.Generic;

namespace ConsoleApp10.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Age { get; set; }
    }
}
