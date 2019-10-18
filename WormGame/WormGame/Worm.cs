using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace WormGame
{
    public class Worm : GameObject
    {
        protected override bool SetProperty(ref int value, int newValue, string propertyName)
        {
            if (!base.SetProperty(ref value, newValue, propertyName)) return false;
            _game.CheckPlayerPosition(this);
            return true;

        }
        public Worm(Game game, int y, int height) : base(game)
        {
            _y = y;
            _height = height;
        }
        private int _direction = 1;
        private Timer _timer;
        private object _lockObject = new object();
        public int Speed { get; set; }
        private void Move()
        {
            var x = _x + _direction * _game.Speed;
            if ((x < 0) || (x + _width > _game.Width))
                _direction = -_direction;
            else
                X = x;
           
        }
        public void Start()
        {
            lock (_lockObject)
            {
                if (_timer == null)
                {
                    _timer = new Timer(Speed * 5);
                    _timer.Elapsed += (s, e) => Move();
                    //_timer.Elapsed += _timer_Elapsed;
                    _timer.Start();
                }
            }
        }
        public void Stop()
        {
            //lock (_lockObject)
            //{
                if (_timer == null) return;
                _timer.Stop();
                _timer = null;
            //}
        }

        //private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Move();
        //}
    }
}