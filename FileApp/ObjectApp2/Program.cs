using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClassLibrary;
namespace ObjectApp2
{
    class C : B
    {
        void T()
        {
            this.z = 20;
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            B b = new B();
            b.T1();
            b.T2();
            A a = b;
            a.T1();
            a.T2();
            b.Test();
            ((IDisposable)b).Dispose();
            Console.WriteLine(b);
            Console.ReadLine();
            using (B b2 = new B())
            {

            }
            foreach (var i in "dfsdfsd")
            {

            }
            // b.z = 22;

        }
    }
}
