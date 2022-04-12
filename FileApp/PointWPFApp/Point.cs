using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointWPFApp
{
    delegate void OnChangeDelegate(Point sender);
    class Point
    {
        public event OnChangeDelegate OnChange;
       // public override string ToString()=>
       //     String.Format("Point:({0},{1})", x, y);
        

        public int x;
        private int _y;
        public int y
        {
            get => _y;
            set
            {
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
    }

}
