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

namespace WpfDataApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new FileLogEntities();
           // var data = db.Files.Where(c => c.FileName.StartsWith(searchField.Text)).Take(1000);//.ToArray();
            var data1 = from a in db.Files
                   where a.FileName.StartsWith(searchField.Text)
                   select new { a.FileName, a.Size };
            var arr = data1.ToArray();
            //var f = db.Files.First();
            //f.FileName = "3sddfsdfsd";
            //db.Files.Add(new Files());

            //db.SaveChanges();

            listData.ItemsSource = arr;

        }
    }
}
