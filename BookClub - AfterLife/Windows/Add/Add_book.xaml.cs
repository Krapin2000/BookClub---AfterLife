using Microsoft.Win32;
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
using static System.Net.Mime.MediaTypeNames;

namespace BookClub___AfterLife
{
    /// <summary>
    /// Логика взаимодействия для Add_book.xaml
    /// </summary>
    public partial class Add_book : Window
    {
        public Add_book()
        {
            InitializeComponent();
        }
        public DataTable table = new DataTable();
        public DataTable worker = new DataTable();
        public DataTable worker1 = new DataTable();
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        static DB da = new DB();
        public MySqlCommand command = new MySqlCommand("", da.GetConnection());
        private void Form_Loaded(object sender, RoutedEventArgs e)
        {
            command = new MySqlCommand("Select Pa_place from partment ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            command = new MySqlCommand("Select Ge_name from genre ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(worker);
            Bo_Genre.ItemsSource = null;
            Bo_Pa_id.ItemsSource = null;
            Bo_Au_id.ItemsSource = null;
            for (int i = 0; i < worker.Rows.Count; i++)
            {
                Bo_Genre.Items.Add(worker.DefaultView[i][0].ToString());
            }
            command = new MySqlCommand("Select Au_name from author ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(worker1);
            for (int i = 0; i < worker1.Rows.Count; i++)
            {
                Bo_Au_id.Items.Add(worker1.DefaultView[i][0].ToString());
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Bo_Pa_id.Items.Add(table.DefaultView[i][0].ToString());
            }
        }
        private void Add_work_Click(object sender, RoutedEventArgs e)
        {
            table = new DataTable();
            worker = new DataTable();
            if (Bo_name.Text.Length != 0 && Bo_about.Text.Length != 0 && Bo_link.Text.Length != 0 && Bo_amount.Text.Length != 0 && Bo_Au_id.Text.Length != 0 && Bo_Pa_id.Text.Length != 0)
            {
                command = new MySqlCommand("Select Au_id from author where Au_name = @uL", da.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Bo_Au_id.SelectedItem.ToString();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                MySqlCommand command1 = new MySqlCommand("Select Pa_id from partment where Pa_place = @wpai", da.GetConnection());
                command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Bo_Pa_id.SelectedItem.ToString();
                adapter.SelectCommand = command1;
                adapter.Fill(worker);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                if (Check(table, worker))
                {
                    int aidishnik1 = int.Parse(table.DefaultView[0][0].ToString());
                    int aidishnik2 = int.Parse(worker.DefaultView[0][0].ToString());
                    DataTable a = new DataTable();
                    command1 = new MySqlCommand("INSERT INTO book (Bo_name,Bo_about,Bo_link,Bo_amount,Bo_Pa_id,Bo_Au_id,Bo_St_id) VALUES (@wN,@wP,@wL,@wPh,@wpai,@uL,1)", da.GetConnection());
                    command1.Parameters.Add("@wN", MySqlDbType.VarChar).Value = Bo_name.Text;
                    command1.Parameters.Add("@wP", MySqlDbType.VarChar).Value = Bo_about.Text;
                    command1.Parameters.Add("@wL", MySqlDbType.VarChar).Value = Bo_link.Text;
                    command1.Parameters.Add("@wPh", MySqlDbType.VarChar).Value = Bo_amount.Text;
                    command1.Parameters.Add("@uL", MySqlDbType.Int64).Value = aidishnik1;
                    command1.Parameters.Add("@wpai", MySqlDbType.Int64).Value = aidishnik2;
                    da.openConection();
                    command1.ExecuteNonQuery();
                    da.closeConection();
                    Close();
                }
                else { MessageBox.Show("Введите данные"); }
            }

        }

        private bool Check(DataTable table, DataTable table1)
        {
            if (table.Rows.Count < 0)
            {
                MessageBox.Show("Нет такой позиции");
                return false;
            }
            if (table1.Rows.Count < 0)
            {
                MessageBox.Show("Нет такого отделения");
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
