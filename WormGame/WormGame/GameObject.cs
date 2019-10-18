using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormGame
{
    public class GameObject:VisualObject
    {
        protected int _x;
        public int X
        {
            get => _x;
            set => SetProperty(ref _x, value, nameof(X));
        }
        protected int _y;
        public int Y
        {
            get => _y;
            set => SetProperty(ref _y, value, nameof(Y));
        }
        public int X2 => _x + _width;
        public int Y2 => _y + _height;
        protected Game _game;
        public GameObject(Game game)
        {
            _game = game;
            _width = 80;
            _height = 40;
        }
    }
}
