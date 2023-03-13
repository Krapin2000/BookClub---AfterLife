using Avalonia.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1Shink;

namespace BookClub___AfterLife.Windows
{
    /// <summary>
    /// Логика взаимодействия для Genre.xaml
    /// </summary>
    public partial class Genre : Page
    {
        public Genre()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select Ge_name from genre ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Tablichka4.ItemsSource = null;
            Tablichka4.ItemsSource = table.DefaultView;
            
        }
    }
}
