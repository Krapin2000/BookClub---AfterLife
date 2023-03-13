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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1Shink;

namespace BookClub___AfterLife.Windows.Pages
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();
        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select DISTINCT Cl_name as 'Имя', Cl_phone as 'Номер', state.st_description as 'Статус' from client,state,position WHERE  client.Cl_St_id = state.st_id and client.Cl_St_id NOT IN (2)", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Tablichka.ItemsSource = null;
            Tablichka.ItemsSource = table.DefaultView;

        }
    }
}
