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
using System.Xml.Linq;
using WpfApp1Shink;

namespace BookClub___AfterLife
{
    /// <summary>
    /// Логика взаимодействия для Close_b.xaml
    /// </summary>
    public partial class Close_b : Window
    {
        public Close_b()
        {
            InitializeComponent();
        }

        private void Close_b_Click(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            DataTable worker = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select Cl_id from client where Cl_name = @uL", da.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Cl_name.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MySqlCommand command1 = new MySqlCommand("Select Bo_id from book where Bo_name = @wpai", da.GetConnection());
            command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Bo_name.Text;
            adapter.SelectCommand = command1;
            adapter.Fill(worker);

            if (Check(table, worker))
            {
                command1 = new MySqlCommand("DELETE FROM orders where Or_Cl_id = (Select Cl_id from client where Cl_name = @uL LIMIT 1) and Or_Bo_id = (Select Bo_id from book where Bo_name = @wpai LIMIT 1)", da.GetConnection());
                command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Cl_name.Text;
                command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Bo_name.Text;
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
