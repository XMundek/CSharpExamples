using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WormGame
{
    public class Player:GameObject 
    {
        public Player(Game game) : base(game)
        {
            SetStartPosition();
        }
        public void SetStartPosition()
        {
            X = _game.Width / 2 - _width / 2;
            Y = _game.Height  - _height ;
        }
        public void Move (Key key)
        {
            if (_game.Lifes == 0 || _game.TimeLeft<=0) return;
            var x = X;
            var y = Y;
            var step = 2;
            switch (key)
            {
                case Key.Right:
                    x += step;
                    if (x > _game.Width - _width)
                        x = _game.Width - _width;
                    X = x;
                    break;
                case Key.Left:
                    x -= step;
                    if (x < 0)
                        x = 0;
                    X = x;
                    break;
                case Key.Up:
                    y -= step;
                    if (y > 0)
                        Y = y;
                    else
                    {
                        _game.WinPlayer();
                    }
                    break;
                case Key.Down:
                    y += step;
                    if (y > _game.Height - _height)
                        y = _game.Height - _height;
                    Y = y;
                    break;
            }

        }
    }
}
