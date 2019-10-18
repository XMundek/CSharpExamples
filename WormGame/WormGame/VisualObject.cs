using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormGame
{
    public class VisualObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected int _width;
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value, nameof(Width));
        }
        protected int _height;
        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value, nameof(Height));
        }
        protected virtual bool SetProperty(ref int value, int newValue, string propertyName)
        {
            if (value == newValue) return false;
            value = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
