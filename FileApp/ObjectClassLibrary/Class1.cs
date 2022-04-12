using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClassLibrary
{
    public interface ITest
    {
        void Test();
        void Test2();
    }

    public abstract class A
    {
        private int x;
        protected int y;
        internal protected int z;
        public void T1()
        {
            Console.WriteLine("AT1");
        }
        public virtual void T2()
        {
            Console.WriteLine("AT2");
        }
        public abstract void T3();
        public override string ToString()
        {
            return "ala ma kota";
        }
    }
    public class B:A, ITest,IDisposable
    {
        public void T()
        {

        }
        public void T1()
        {
            Console.WriteLine("BT1");
        }
        public override void T2()
        {
            Console.WriteLine("BT2");
        }
        public override void T3()
        {
            Console.WriteLine("BT3");
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        public void Test2()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
