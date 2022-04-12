using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    delegate int ArithOperatorDelegate(int a, int b);

    public delegate void OnChangeDelegate(Point sender);
    public delegate void OnBeforeChangeDelegate(Point sender, int NewValue, ref bool Cancel);

    public class Point {
        int _x,_y;
        public int y { get => _y; set => _y = value; }
        public string s => y.ToString();

        private OnChangeDelegate _onchangex;
        public event OnChangeDelegate onChangeX
        {
            add { _onchangex += value; }
            remove { _onchangex -= value; }
        }
        public event OnBeforeChangeDelegate onBeforeChangeX;
        public int x
        {
            get { return _x; }
            set
            {

                if (_x != value)
                {
                    var cancel = false;
                    if (onBeforeChangeX != null)
                    {
                        onBeforeChangeX(this, value, ref cancel);
                        if (cancel) return;
                    }
                    _x = value;      
                    if (_onChangeX != null)
                        _onChangeX(this);
                }
            }
        }
    }
    class Listener
    {
        public string name;
        public void onchange2(Point p)
        {
            Console.WriteLine(name + "changed2" + p.x.ToString());
        }
    }
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static void Calc(ArithOperatorDelegate op)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(op(a,b));
        }
        public static void onchange(Point p)
        {
            Console.WriteLine("changed" + p.x.ToString());
        }
        public static void onbeforechange(Point p, int v,ref bool cancel)
        {
            if (!cancel)
                cancel = (v < 0);
        }
        static void Main(string[] args)
        {

        //    var p = new Point() { x = 10 };
        //    var l1 = new Listener() { name = "L1" };
        //    var l2 = new Listener() { name = "L2" };

        //    p.onChangeX += onchange;
        //    p.onBeforeChangeX += onbeforechange;
        //    p.x = -1;

        //    p.onChangeX += l1.onchange2;
        //    p.onChangeX += l2.onchange2;
        //    p.x = 30;


            Func<int,int> d =  delegate (int a)
            {
                return 2*a;
            };

            Func<int,int> d2 =a=>2*a;
            System.Linq.Expressions.Expression<Func<int, int>> e = a => 2 * a;
          

            Calc(d);
            Console.ReadLine();
        }
    }
}
