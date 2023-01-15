
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp1Shink;

namespace BookClub___AfterLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            new Window1().ShowDialog();
            InitializeComponent();
        }

        private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            
            var windowPosition = Mouse.GetPosition(this);
            var screenPosition = this.PointToScreen(windowPosition);

            Status.Text = string.Format("{0}", windowPosition);
        }

       
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            new Upp().ShowDialog(); 
        }
        private void Newbe_Click(object sender, RoutedEventArgs e)
        {
            new Newbe().Show();
        }
        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            new kill().ShowDialog();
        }
        private void Add_Click (object sender, RoutedEventArgs e)
        {
            new Add_book().ShowDialog();
        }
        private void Take_Click(object sender, RoutedEventArgs e)
        {
            new Window2().Show();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            new Close_b().Show();
        }
        private void Longer_Click(object sender, RoutedEventArgs e)
        {
            new Longer_b().Show();
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            new Zakaz().Show();
        }
        private void MenuBook_Click(object sender, RoutedEventArgs e)
        {
            Peopple.Opacity = 0;
            Books.Opacity = 100;
        }
        private void MenuPeopple_Click(object sender, RoutedEventArgs e)
        {
            Books.Opacity = 0;
            Peopple.Opacity = 100;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
