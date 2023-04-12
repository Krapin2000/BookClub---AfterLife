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
using System.Windows.Shapes;
using WpfApp1Shink;

namespace BookClub___AfterLife.Windows.Delete
{
    /// <summary>
    /// Логика взаимодействия для Leave.xaml
    /// </summary>
    public partial class Leave : Window
    {
        public Leave()
        {
            InitializeComponent();
        }

        public DataTable table = new DataTable();

        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        static DB da = new DB();
        public MySqlCommand command = new MySqlCommand("", da.GetConnection());
        private void Form_Loaded(object sender, RoutedEventArgs e)
        {
            command = new MySqlCommand("Select Cl_name from client ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            K_name.ItemsSource = null;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                K_name.Items.Add(table.DefaultView[i][0].ToString());
            }
        }
        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            table = new DataTable();
            command = new MySqlCommand("Select Cl_id from client where Cl_name = @uL", da.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = K_name.Text.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            if (Check(table) && K_name.Text.Length != 0)
            {
                command = new MySqlCommand("UPDATE client SET Wo_St_id = 2 WHERE Cl_name = @uL", da.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = K_name.SelectedItem.ToString();
                adapter.SelectCommand = command;
                da.openConection();
                command.ExecuteNonQuery();
                da.closeConection();
                MessageBox.Show("Выполненно");
                Close();
            }
            else { MessageBox.Show("Введите данные"); }


        }

        private bool Check(DataTable table)
        {
            if (table.Rows.Count < 0)
            {
                MessageBox.Show("Нет такой позиции");
                return false;
            }
            return true;
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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
