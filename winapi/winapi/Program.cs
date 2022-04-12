using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace winapi
{
   
    class Program
    {

        [DllImport("user32.dll")]        
        static extern int  GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);


        static string GetText(IntPtr hWnd)
        {
            var s = new StringBuilder(100);
            int c = GetWindowText(hWnd, s,100);
            return s.ToString();
        }



        static void Main(string[] args)
        {

            ProcessTextReader.GetProcessInfo();

            var s = "Ala ma kota";
            s.Reverse();
            int[] a = new int[] { 23, 355, 334, 32342 };
            a.Reverse();
            Console.WriteLine(s);
            Console.WriteLine(a);
            long l = 34234234234234234;            
            var b = l.ToByteArray();
            Console.WriteLine(b[1]);
            b[3]++;
            Console.WriteLine(b.ToLong());


            Console.ReadLine();

        }                   
    }
}
