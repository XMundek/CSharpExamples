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

namespace WormGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        Game _game;
        public void SetTitle(string login)
        {
            Title = "Hi " + login;
            _game.LoginName = login;
        }
        public MainWindow()
        {
            
            InitializeComponent();
            this.DataContext = _game = new Game();
            _game.EndGame += (sender, status) => 
                this.Dispatcher.Invoke(()=>
                  MessageBox.Show(sender.StatusMessage, this.Title,
                    MessageBoxButton.OK, MessageBoxImage.Exclamation)
               );
        }

        private void CmdCommand_Click(object sender, RoutedEventArgs e)
        {
            if (_game.IsRunning)
                _game.Stop();
            else
            {
                gameArea.Init();
                _game.Start();
            }
        }

        private void CmdNewGame_Click(object sender, RoutedEventArgs e)
        {
            gameArea.Init();
            _game.NewGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new WormGameEntities())
            {
                var result = new GameResults()
                {
                    Player = _game.LoginName,
                    Score = _game.Points,
                    DT = DateTime.Now
                };
                db.GameResults.Add(result);
                db.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new GameResultsWindow().Show();
        }
    }
}
