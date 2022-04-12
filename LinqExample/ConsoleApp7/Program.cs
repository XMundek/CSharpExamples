using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person[] a = new Person[]
            {
                 new Person(){LastName = "Fasola", FirstName="Jasio", City="WAW"},
                 new Person(){LastName = "Pigwa", FirstName="Gienia", City="KRK"},
                 new Person(){LastName = "Kalosz", FirstName="Jan", City="WAW"},
            };
            Person[] a1 = new Person[]
            {
                 new Person(){LastName = "Fasola1", FirstName="Jasio1", City="WAW"},
                 new Person(){LastName = "Pigwa1", FirstName="Gienia1", City="KRK"},
                 new Person(){LastName = "Kalosz1", FirstName="Jan1", City="WAW"},
            };

            var q = from i in a                   
                    group i by i.City into z
                    select new {City=z.Key, Count = z.Count() };

            var q2 = from i in a
                     join g in q on i.City equals g.City
                     select new { i.LastName, i.FirstName, i.City, g.Count };
            
           //foreach (var i in q2)
           // {
           //     Console.WriteLine(i.City);
           // }
            var res = q.ToArray();
            var res2 = a.Where(p => p.LastName.StartsWith("F")).OrderBy(p=>p.LastName).ThenBy(p=>p.FirstName).ToArray();
           
        }
    }
}
