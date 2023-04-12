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
        public DataTable table = new DataTable();
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        static DB da = new DB();
        public MySqlCommand command = new MySqlCommand("", da.GetConnection());
        public Client()
        {
            InitializeComponent();
        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            command = new MySqlCommand("Select DISTINCT Cl_id as 'Номер', Cl_name as 'Имя', Cl_phone as 'Номер', state.st_description as 'Статус' from client,state,position WHERE  client.Cl_St_id = state.st_id and client.Cl_St_id NOT IN (2)", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Tablichka.ItemsSource = null;
            Tablichka.ItemsSource = table.DefaultView;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            adapter.SelectCommand = command;
            da.openConection();
            
            
            int con = Tablichka.SelectedItems.Count;
            for (int i = 0; i < con; i++) {
                Tablichka.SelectedIndex = i!=0? (Tablichka.SelectedIndex+1) :(Tablichka.SelectedIndex = 0);
                DataRowView rowView = Tablichka.SelectedValue as DataRowView;
                MessageBox.Show(rowView[0].ToString());
                command = new MySqlCommand("UPDATE client SET Cl_St_id = 2 WHERE Cl_id = @uL", da.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = rowView[0].ToString();
                command.ExecuteNonQuery();
            }
            da.closeConection();
        }
    }
}
