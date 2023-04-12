
using BookClub___AfterLife.Windows.Add;
using BookClub___AfterLife.Windows.Delete;
using BookClub___AfterLife.Windows.Pages;
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
        //Таблички
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            Peopple.Visibility = Visibility.Collapsed;
            Author.Visibility = Visibility.Collapsed;
            Genre.Visibility = Visibility.Collapsed;
            Books.Visibility = Visibility.Visible;
            Client.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Collapsed;
            Books.Refresh();
        }
        private void Peopples_Click(object sender, RoutedEventArgs e)
        {
            Author.Visibility = Visibility.Collapsed;
            Genre.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Collapsed;
            Books.Visibility = Visibility.Collapsed;
            Peopple.Visibility = Visibility.Visible;
            Client.Visibility = Visibility.Collapsed;
            Peopple.Refresh();
        }
        private void Genre_Click(object sender, RoutedEventArgs e)
        {
            Genre.Refresh();
            Author.Visibility = Visibility.Collapsed;
            Genre.Visibility = Visibility.Visible;
            Order.Visibility = Visibility.Collapsed;
            Books.Visibility = Visibility.Collapsed;
            Peopple.Visibility = Visibility.Collapsed;
            Client.Visibility = Visibility.Collapsed;
        }
        private void Author_Click(object sender, RoutedEventArgs e)
        {
            Books.Visibility = Visibility.Collapsed;
            Author.Visibility = Visibility.Visible;
            Order.Visibility = Visibility.Collapsed;
            Genre.Visibility = Visibility.Collapsed;
            Client.Visibility = Visibility.Collapsed;
            Author.Refresh();
            Peopple.Visibility = Visibility.Collapsed;
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Books.Visibility = Visibility.Collapsed;
            Author.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Visible;
            Genre.Visibility = Visibility.Collapsed;
            Client.Visibility = Visibility.Collapsed;
            Order.Refresh();
            Peopple.Visibility = Visibility.Collapsed;
        }
        private void Client_Click(object sender, RoutedEventArgs e)
        {
            Books.Visibility = Visibility.Collapsed;
            Author.Visibility = Visibility.Collapsed;
            Order.Visibility = Visibility.Collapsed;
            Genre.Visibility = Visibility.Collapsed;
            Client.Visibility = Visibility.Visible;
            Client.Refresh();
            Peopple.Visibility = Visibility.Collapsed;
        }
        //Окна
        private void Give_Click(object sender, RoutedEventArgs e)
        {

            new Zakaz().Show();
        }
        private void Longer_Click(object sender, RoutedEventArgs e)
        {
            new Longer_b().Show();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new Add_book().Show();
        }
        private void Newbe_Click(object sender, RoutedEventArgs e)
        {
            new Newbe().Show();
        }
        private void NewCli_Click(object sender, RoutedEventArgs e)
        {
            new NewCli().Show();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            new Close_b().Show();
        }
        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            new kill().Show();
        }
        private void Leave_Click(object sender, RoutedEventArgs e)
        {
            new Leave().Show();
        }
        private void Upp_Click(object sender, RoutedEventArgs e)
        {
            new Upp().Show();
        }
        //Верх_Право_Меню
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Extend_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else { WindowState = WindowState.Normal; }
        }

    }
}
