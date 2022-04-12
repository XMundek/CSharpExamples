using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace winapi
{
    class ProcessTextReader
    {
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);
        static string GetText(IntPtr hWnd)
        {
            var s = new StringBuilder(100);
            int c = GetWindowText(hWnd, s, 100);
            return s.ToString();
        }



        public static void GetProcessInfo()
        {
            var c = System.Diagnostics.Process.GetProcesses()
                .Where(p => p.MainWindowHandle != IntPtr.Zero)
                .Select(p => new { p.ProcessName, Text = GetText(p.MainWindowHandle) });
            foreach (var i in c)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

        }
    }
}
