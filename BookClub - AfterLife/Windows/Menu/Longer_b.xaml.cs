using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BookClub___AfterLife
{
    /// <summary>
    /// Логика взаимодействия для Longer_b.xaml
    /// </summary>
    public partial class Longer_b : Window
    {
        public Longer_b()
        {
            InitializeComponent();
        }

        private void Longer_Click(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            DataTable worker = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select Bo_id from book where Bo_name = @uL", da.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Or_Bo_id.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MySqlCommand command1 = new MySqlCommand("Select Cl_id from client where Cl_name = @wpai", da.GetConnection());
            command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Or_Cl_id.Text;
            adapter.SelectCommand = command1;
            adapter.Fill(worker);
            if (Check(table, worker))
            {
                command1 = new MySqlCommand("UPDATE orders SET Or_description = @wL where orders.Or_Cl_id = (Select Cl_id from client where Cl_name = @uL LIMIT 1) and orders.Or_Bo_id = (Select Bo_id from book where Bo_name = @wpai LIMIT 1)", da.GetConnection());
                command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Or_Cl_id.Text;
                command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Or_Bo_id.Text;
                command1.Parameters.Add("@wL", MySqlDbType.VarChar).Value = Or_description.Text;
                da.openConection();
                command1.ExecuteNonQuery();
                da.closeConection();
                Close();
            }
        }

        private bool Check(DataTable table, DataTable table1)
        {
            if (table.Rows.Count < 0)
            {
                MessageBox.Show("Нет такой книги");
                return false;
            }
            if (table1.Rows.Count < 0)
            {
                MessageBox.Show("Нет такого клиента");
                return false;
            }
            return true;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
