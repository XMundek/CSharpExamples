using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapi
{
    static class UnsafeExtensions
    {
        public unsafe static void Reverse(this string s)
        {            
            fixed (char* c = s)
            {
                for (char* p1 = c, p2 = c + s.Length-1; p1 < p2; p1++, p2--)
                {
                    char tmp = *p1;
                    *p1 = *p2;
                    *p2 = tmp;
                }
            }
        }

        public unsafe static void Reverse(this int[] s)
        {
            fixed (int* c = s)
            {
                for (int* p1 = c, p2 = c + s.Length-1; p1 < p2; p1++, p2--)
                {
                    int tmp = *p1;
                    *p1 = *p2;
                    *p2 = tmp;
                }
            }
        }
        public unsafe static long ToLong(this byte[] b)
        {
            if (b == null || b.Length < 8)
                throw new ArgumentOutOfRangeException();
            fixed (byte* p = b)
            {
                return *(long*)p;
            }
        }
        public unsafe static byte[] ToByteArray(this long b)
        {
            var arr = new byte[8];
            fixed (byte* p = arr)
            {
                *(long*)p = b;
            }
            return arr;
        }

    }
}
