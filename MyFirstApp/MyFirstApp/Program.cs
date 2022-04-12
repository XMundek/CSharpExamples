using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Int32 a = ReadInt("a value");
            System.Int32 b = ReadInt();
            int c = a + b;
            String x = "1";
            string y = "130";
            string z = x + y;
            char cx = 'a';
            bool f = true;
            DateTime dt = DateTime.Now;
            Console.WriteLine(c);
            Console.WriteLine(z);
            Console.WriteLine(dt);

            if (a > b  || x=="a" )
            {
                Console.WriteLine("wieksze");
            }
            else if (a == b)
            {

            }
            else
            {
                Console.WriteLine("mniejsze");
            }

            for (int i = a; i > 0; i--)
            {
                Console.WriteLine("iteracja" + i);
            }

            int j =0;
            while (j < a)
            {
                j++;
                Console.WriteLine("iteracja while" + j);
            }
            do
            {
                j++;
                Console.WriteLine("iteracja do while" + j);
            } while (j < a);

            int[] arr = new int[] { 324, 325, 34553 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("for arr" + arr[i]);
                arr[i]++;
            }
            foreach (int i  in arr)
            {
                Console.WriteLine("foreach arr" + i);              
            }
            switch (a)
            {
                case 1:
                    Console.WriteLine("jeden");
                    break;
                case 2:
                    Console.WriteLine("dwa");
                    break;
                default:
                    Console.WriteLine("dzfdsfsdf");
                    break;


            }
            Console.ReadLine();

        }
        static int ReadInt(string name="integer value")
        {
            Console.WriteLine("input " + name);
            return int.Parse(Console.ReadLine());
        }
    }
}
