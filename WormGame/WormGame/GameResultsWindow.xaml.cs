using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;

namespace WormGame
{
    /// <summary>
    /// Interaction logic for GameResults.xaml
    /// </summary>
    public partial class GameResultsWindow : Window
    {
        public GameResultsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //var s = "asdasdas";
            //var q = s.Where(c => c > 'a').OrderBy(c =>c).ToArray();

            using (var db= new WormGameEntities())
            {
                //var query = from r in db.GameResults
                //            where r.Player.StartsWith(txtSearch.Text)
                //            orderby r.Score descending
                //            //select new { r.Id, Gracz=r.Player, Wynik = r.Score };
                //            select r;
           
                var query = db.GameResults.Where(r => r.Player.StartsWith(txtSearch.Text))
                        .OrderByDescending(r => r.Score);
                //.Select(r => r);
                var res = query.ToArray();
                SerializeJson(res);
                Serialize(res);

                lstResults.ItemsSource = res;
            }     

        }
        public void Serialize(GameResults[] res)
        {
           
            var serializer = new XmlSerializer(typeof(GameResults[]));
            using (var tw = File.CreateText(@"c:\temp\gameResults.xml"))
            {
                serializer.Serialize(tw, res);
            }
            using (var tw = File.OpenText(@"c:\temp\gameResults.xml"))
            {
                var res2 = serializer.Deserialize(tw);
            }
        }
        public void SerializeJson(GameResults[] res)
        {

            var serializer = new JsonSerializer();
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
            using (var tw = File.CreateText(@"c:\temp\gameResults.json"))
            {
                serializer.Serialize(tw, res);
            }
            using (var tw = new JsonTextReader(File.OpenText(@"c:\temp\gameResults.json")))
            {
                var res2 = serializer.Deserialize<GameResults[]>(tw);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            using (var db = new WormGameEntities())
            {
               
                var res = (GameResults)((Button)sender).DataContext;
                db.Entry(res).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                Button_Click(null, null);
            }

        }
    }
}
