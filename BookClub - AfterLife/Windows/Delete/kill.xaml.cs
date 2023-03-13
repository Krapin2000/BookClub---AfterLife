using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для kill.xaml
    /// </summary>
    public partial class kill : Window
    {
        public kill()
        {
            InitializeComponent();
        }
        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select Wo_id from worker where Wo_name = @uL", da.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = K_name.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            if (Check(table))
            {
                command = new MySqlCommand("UPDATE worker SET Wo_St_id = 2 WHERE Wo_name = @uL", da.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = K_name.Text;
                adapter.SelectCommand = command;
                da.openConection();
                command.ExecuteNonQuery();
                da.closeConection();
                Close();
            }


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
