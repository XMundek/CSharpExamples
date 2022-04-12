using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTestApp.Extensions
{
    public static class StringExtensions
    {
        public static string TestExtension(this string input, int i) => "X" + input;
    }
}
