using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectTestApp.Extensions;
namespace ObjectTestApp
{
    delegate int ArithmOperator(int a, int b);
    delegate void OnChangeDelegate(Point sender);
    class Point<Tx, Ty>
    {
        public Tx x;
        public Ty y;
        public TRes SomeMethod<TIn, TRes>(TIn input) where TRes : class, new()
                where TIn : System.IO.Stream
        {

            return new TRes();
        }

    }

    class Point
    {
        public static Point operator+(Point a, Point b)
        {
            return new Point() { x = a.x + b.x, y=a.y + b.y };
        }
        public static Point operator +(Point a, int b)
        {
            return new Point() { x = a.x + b, y = a.y + b };
        }
        public static implicit operator int (Point p) => p.x+p.y;
        public static explicit operator Point(int i) => new Point() { x=i,y=i};
        public event OnChangeDelegate OnChange;
        private OnChangeDelegate _onchange2;
        public event OnChangeDelegate onchange2
        {
            add {

                _onchange2 -= value;
                _onchange2 += value;
            }
            remove { onchange2 -= value; }
        }
        ArithmOperator op;
        public int x;
        private int _y;
        public int y
        {
            get => _y;
            set {
                if (_y != value)
                {
                    _y = value;
                    if (OnChange != null)
                        OnChange(this);
                }
            }
        }

        public int z { get; set; }
        public void Move(int newX, int newY)
        {
            x += newX;
            y += newY;
        }
        public int this[int index]
        {
            get => (index == 0) ? x : y;

            set {
                if (index == 0)
                    x = value;
                else
                    y = value;
            }
        }

        public int this[string index]
        {
            get
            {
                return (index == "x") ? x : y;
            }
            set
            {
                if (index == "x")
                    x = value;
                else
                    y = value;
            }
        }
    }


    internal class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Mul(int a, int b) => a * b;

        public void Test(ArithmOperator op)
        {

        }
        delegate int TestDel(int i);
        static void Main(string[] args)
        {

            int[] arrData = new int[] { 3423, 23234, 234, 566, 2, -10, 3, -44, 1212 };
            var query = arrData.Where(a => a > 0).OrderBy(a => a).Select(a => new Point() { x = a });
            var query1 = from a in arrData
                        where a > 0
                        orderby a
                        select new Point { x=a};
            //int sum = arrData.Where(a => a > 0).Sum(a => a);
            arrData[0] = -10;
            foreach (var item in query)
            {
                Console.WriteLine(item.x);
            }




            string ms = "dfsdfsd";
            
            ms.StartsWith("df");
            var ewas =String.Join("", new string[] { "sss", "bb" });

            var ms1 = ObjectTestApp.Extensions.StringExtensions.TestExtension(ms,1);
            var ms2 = ms.TestExtension(12);

            Func<int> f1 = () => 2;
            System.Collections.Generic.Dictionary<string,int> dict = new Dictionary<string,int>();
            dict.Add("s", 232);
            int fd = dict["s"];
            
            object o = 2;
            object o1 = o;
            int i = (int)o;
            System.Collections.Hashtable h=new System.Collections.Hashtable();
            h.Add("s", 2);
            int hi = (int)h["s"];
            int[] axx = new int[20];
            axx = new int[40];
            
            System.Collections.ArrayList arrList;
            System.Collections.Generic.List<int> arrList2;
            //arrList2.Add(22);

             var pg = new Point<int, int>();
            pg.x = 10;
            var sb = pg.SomeMethod<System.IO.FileStream, StringBuilder>(
                new System.IO.FileStream("dd",System.IO.FileMode.Append));
            var pd = new Point<double,double>();
            pd.x = 10.232;



            var p = new Point()
            {
                x = 10,
                y = 20
            };
            p.y = 30;
            var p20 = p + p;
            var p21 = p + 20;
            Point p22 = (Point)33;
            int pxxx = p22;

            p.OnChange -= P_OnChange;

            p.OnChange += P_OnChange;
            p.OnChange += x => Console.WriteLine("xxxsfsdfsdfsd");
            p.OnChange += P_OnChange;
            
            p.y = 40;
            p.OnChange -= P_OnChange;
            p.OnChange -= P_OnChange;
            p.OnChange -= P_OnChange;

            p.y = 50;


            ArithmOperator op = Add;
            op += Mul;
            ArithmOperator op1 = delegate (int a, int b)
            {
                return 2 * a + b;
            };

            ArithmOperator op2 = (a, b) =>
            {
                return 2 * a + b;
            };

          //  ArithmOperator op2 = (a, b) => 2 * a + b;


            TestDel d = x => 2 * x;
            Action f = () => Console.WriteLine("ASdas");


            var res = op1(2, 45);
            //op = new ArithmOperator(Add);
            //int d = op.Invoke(2, 34);
            int c = op(2, 5);
            

            int[] t = new int[2];
            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            hash["ddd"] = 20;

            Point point = new Point();
            point.x = 220;
            point.y = 334;
            point[0] = 33;
            point["x"] = 222;

                
        }

        private static void P_OnChange(Point sender)
        {
            Console.Write("Point changed " + sender.y);
        }
    }
}
