using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Linq;
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
        public DataTable table = new DataTable();
        public DataTable worker = new DataTable();
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        static DB da = new DB();
        public MySqlCommand command = new MySqlCommand("", da.GetConnection());
        private void Form_Loaded(object sender, RoutedEventArgs e)
        {
            command = new MySqlCommand("Select Cl_name from client ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Or_Cl_id.ItemsSource = null;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Or_Cl_id.Items.Add(table.DefaultView[i][0].ToString());
            }
            command = new MySqlCommand("Select Bo_name from book ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(worker);
            Or_Bo_id.ItemsSource = null;
            for (int i = 0; i < worker.Rows.Count; i++)
            {
                Or_Bo_id.Items.Add(worker.DefaultView[i][0].ToString());
            }
        }
        private void OnDropDownClosed(object sender, EventArgs e)
        {
            Or_description.Items.Clear();
            table.Clear();
            table.Columns.Clear();
            if (Or_Bo_id.Text != "" && Or_Cl_id.Text != "") { 
            command = new MySqlCommand("Select Or_description from client,book,orders where Bo_name = @uL and  Cl_name = @wpai and Cl_id = Or_Cl_id and Bo_id = Or_Bo_id", da.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Or_Bo_id.Text;
            command.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Or_Cl_id.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Or_description.Items.Add(table.DefaultView[i][0].ToString());
            }
            Or_description.SelectedIndex = 0;
            }
        }
        private void Longer_Click(object sender, RoutedEventArgs e)
        {
            command = new MySqlCommand("Select Bo_id from book where Bo_name = @uL", da.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Or_Bo_id.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MySqlCommand command1 = new MySqlCommand("Select Cl_id from client where Cl_name = @wpai", da.GetConnection());
            command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Or_Cl_id.Text;
            adapter.SelectCommand = command1;
            adapter.Fill(worker);
            if (Check(table, worker)&& Or_Cl_id.Text!="" && Or_Bo_id.Text != "" && Or_description.Text != "")
            {
                command1 = new MySqlCommand("UPDATE orders SET Or_description = @wL where orders.Or_Cl_id = (Select Cl_id from client where Cl_name = @uL LIMIT 1) and orders.Or_Bo_id = (Select Bo_id from book where Bo_name = @wpai LIMIT 1)", da.GetConnection());
                command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Or_Cl_id.Text;
                command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Or_Bo_id.Text;
                command1.Parameters.Add("@wL", MySqlDbType.VarChar).Value = Or_DDescription.Text;
                da.openConection();
                command1.ExecuteNonQuery();
                da.closeConection();
                MessageBox.Show("Выполненно");
                Close();
            }
            else { MessageBox.Show("Введите данные"); }
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
