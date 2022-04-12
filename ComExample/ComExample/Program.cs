using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace ComExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var excel = new ExcellWrapper())
            {
                excel.Open();
                for (var i=1;i<100; i++)
                {
                    excel["A" + i.ToString()] = "Jasio" + i;
                    excel["B" + i.ToString()] = "Fasola" + i;
                }
                excel.Save(@"c:\temp\x.xlsx");
            }
        }
    }
}
