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
        public DataTable table = new DataTable();
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        static DB da = new DB();
        public MySqlCommand command = new MySqlCommand("", da.GetConnection());
        public Genre()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            command = new MySqlCommand("Select Ge_name from genre ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Tablichka4.ItemsSource = null;
            Tablichka4.ItemsSource = table.DefaultView;
            
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            adapter.SelectCommand = command;
            da.openConection();
            int con = Tablichka4.SelectedItems.Count;
            for (int i = 0; i < con; i++)
            {
                Tablichka4.SelectedIndex = i != 0 ? (Tablichka4.SelectedIndex + 1) : (Tablichka4.SelectedIndex);
                DataRowView rowView = Tablichka4.SelectedValue as DataRowView;
                command = new MySqlCommand("UPDATE worker SET Wo_St_id = 2 WHERE Wo_id = @uL", da.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = int.Parse(rowView[0].ToString());

                command.ExecuteNonQuery();
            }
            da.closeConection();
        }
    }
}
