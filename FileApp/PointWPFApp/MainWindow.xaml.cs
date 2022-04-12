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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point p;
        public MainWindow()
        {
            InitializeComponent();
            p = new Point() { x = 10, y = 20 };
            tx.Text = p.x.ToString();
            ty.Text = p.y.ToString();
            this.DataContext = p;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var f = new PointPresenter(p);
            // f.Show(p);
            f.Show();
            await Task.Delay(10000);
            this.Title = "finished";
        }

        //private void ty_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var txt = sender as TextBox; //(TextBox)sender;
        //    //var txt2 = sender is TextBox ? (TextBox)sender : null;
        //    if (p == null)
        //        return;
        //    if (int.TryParse(ty.Text, out int val))
        //    {
        //        p.y = val;
        //    }
        //    else
        //    {
        //        ty.Text = p.y.ToString();
        //    }
        //}

        private void tx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (p == null)
                return;

            if (int.TryParse(tx.Text, out int val))
            {
                p.x = val;
            }
            else
            {
                tx.Text = p.x.ToString();
            }

        }
    }
}