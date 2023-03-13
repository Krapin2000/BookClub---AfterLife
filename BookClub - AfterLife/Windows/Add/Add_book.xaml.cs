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

        private void Add_work_Click(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            DataTable worker = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select Au_name from author where Au_id = @uL", da.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.Int64).Value = Bo_Au_id.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MySqlCommand command1 = new MySqlCommand("Select Pa_place from partment where Pa_id = @wpai", da.GetConnection());
            command1.Parameters.Add("@wpai", MySqlDbType.Int64).Value = Bo_Pa_id.Text;
            adapter.SelectCommand = command1;
            adapter.Fill(worker);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            if (Check(table, worker))
            {
                DataTable a = new DataTable();
                command1 = new MySqlCommand("INSERT INTO book (Bo_name,Bo_about,Bo_link,Bo_amount,Bo_Pa_id,Bo_Au_id,Bo_St_id) VALUES (@wN,@wP,@wL,@wPh,@wpai,@uL,1)", da.GetConnection());
                command1.Parameters.Add("@wN", MySqlDbType.VarChar).Value = Bo_name.Text;
                command1.Parameters.Add("@wP", MySqlDbType.VarChar).Value = Bo_about.Text;
                command1.Parameters.Add("@wL", MySqlDbType.VarChar).Value = Bo_link.Text;
                command1.Parameters.Add("@wPh", MySqlDbType.VarChar).Value = Bo_amount.Text;
                command1.Parameters.Add("@uL", MySqlDbType.Int64).Value = Bo_Au_id.Text;
                command1.Parameters.Add("@wpai", MySqlDbType.Int64).Value = Bo_Pa_id.Text;
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
