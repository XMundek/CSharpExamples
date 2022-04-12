using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Threading
{
    class Program
    {
        static object semathore=new object();
        static object semathore2 = new object();

        static int counter;

        static void TestThreading()
        {
            for (var j = 0; j < 100; j++)
            {
                var i = counter;
                Console.WriteLine(i);
                i++;
                //do something
                Thread.Sleep(10);
                counter = i;
            }
        }
        static void TestThreadingSync()
        {
            for (var j = 0; j < 100; j++)
            {
                lock (semathore)
                {
                    var i = counter;
                    Console.WriteLine(i);
                    i++;
                    //do something
                    Thread.Sleep(10);
                    counter = i;
                }
            }
        }
        
        static async Task TestAsync()
        {
            var t = new Task(TestThreading);
            t.Start();
            //do something
            await t;
        }
        static void Main(string[] args)
        {
            //var t = new Thread[10];
            //for (var i = 0; i < t.Length; i++)
            //{ 
            //    //t[i] = new Thread(TestThreading);
            //    t[i] = new Thread(TestThreadingSync);
            //    t[i].Start();

            //}

            //Console.WriteLine("---------------------");

            //var x = TestAsync();

            //Console.WriteLine("DO SOMEETHING");

            //x.Wait();

            //Console.WriteLine("END");

            //var t = new Task[10];
            //for (var i = 0; i < t.Length; i++)
            //{
            //    t[i] = new Task(TestThreadingSync);
            //    t[i].Start();
            //}

            //Task.WaitAll(t);

            var a = new Action[10];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = TestThreadingSync;
            }
            Parallel.Invoke(a);           
            Console.WriteLine("END");

            Console.ReadLine();
        }
    }
}
