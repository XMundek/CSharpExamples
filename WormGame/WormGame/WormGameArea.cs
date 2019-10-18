using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
namespace WormGame
{
    class WormGameArea:Canvas
    {
        private Game _game;
        private UIElement GetRoot(FrameworkElement item)
        {
            //var ctl = item.Parent is FrameworkElement ? (FrameworkElement)item.Parent : null;
            //var ctl = item.Parent as FrameworkElement;u
            return (item.Parent == null) ? item : GetRoot(item.Parent as FrameworkElement);
        }
        private void OnSizeChanged(object sender,EventArgs e)
        {
            _game.Width = (int)this.ActualWidth;
            _game.Height = (int)this.ActualHeight;
        }
        public void Init()
        {
            _game = this.DataContext as Game;
            if (!(_game != null && Children.Count == 0)) return;
            var root = GetRoot(this);
            if (root != null)
            {
                root.KeyDown += (s, e) => _game.Player.Move(e.Key);
            }
            OnSizeChanged(null, null);
            this.SizeChanged += OnSizeChanged;
            _game.Init();
            var item = new Rectangle { Fill = Brushes.Blue };
            item.SetBinding(_game.Player);

            this.Children.Add(item);
            foreach (var worm in _game.Worms)
            {
                item = new Rectangle() { Fill = Brushes.Red };
                item.SetBinding(worm);
                this.Children.Add(item);
            }

        }

    }
   
}
