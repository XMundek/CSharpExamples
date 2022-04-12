using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PointWPFApp
{
    /// <summary>
    /// Interaction logic for PointPresenter.xaml
    /// </summary>
    public partial class PointPresenter : Window
    {
        private Point p;
        internal PointPresenter(Point p)
        {
            InitializeComponent();
            this.p = p;
            this.DataContext = p;
        }
        public PointPresenter():this(new Point())
        {
            
        }
        //internal void Show(Point p)
        //{
        //    this.p = p;
        //    p.OnChange += s => this.Title = p.y.ToString();
        //    this.Show();
        //}
    }
}
