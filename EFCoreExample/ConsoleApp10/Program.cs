using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var context = new Models.TestContext();
            foreach (var p in context.Person)
            {
                Console.WriteLine(p.LastName);
            }
            Console.ReadLine();
        }
    }
}
