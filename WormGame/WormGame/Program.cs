using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WormGame
{
    static class Program
    {
        
        public static string Input()
        {

            var w = new Window() {
                Width = 200, Height = 300, ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowState = WindowState.Normal,
                WindowStyle = WindowStyle.ToolWindow,
                Title = "Login"
            };

            var panel = new StackPanel() { VerticalAlignment = VerticalAlignment.Center };
            var txt = new TextBox() { Height = 30, FontSize=20, Margin=new Thickness(4)};
            var btn = new Button() { Content = "OK" };

            btn.Click += (a, b) => w.Close();               
            panel.Children.Add(txt);
            panel.Children.Add(btn);
            w.Content = panel;
            w.ShowDialog();
            return txt.Text;
        }
        [STAThread]
        public static void Main()
        {
            var res = Input();
            if (!string.IsNullOrEmpty(res))
            {
                var app = new Application();
                var mainForm = new MainWindow();
                mainForm.SetTitle(res);
                app.Run(mainForm);
            }
        }
    }
}
