using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Логика взаимодействия для Newbe.xaml
    /// </summary>
    public partial class Newbe : Window
    {
        public Newbe()
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
            command = new MySqlCommand("Select Pa_place from partment ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            command = new MySqlCommand("Select Po_name from position ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(worker);
            Wo_Po_id.ItemsSource = null;
            Wo_Pa_id.ItemsSource = null;
            for (int i = 0; i < worker.Rows.Count; i++)
            {
                Wo_Po_id.Items.Add(worker.DefaultView[i][0].ToString());
            }
            for (int i = 0; i < table.Rows.Count; i++) 
            {
                Wo_Pa_id.Items.Add(table.DefaultView[i][0].ToString());
            }
        }
        private void Add_work_Click(object sender, RoutedEventArgs e)
        {
            if (Wo_name.Text.Length !=0 && Wo_pass.Text.Length != 0 && Wo_login.Text.Length != 0 && Wo_phone.Text.Length != 0 && Wo_Po_id.Text.Length != 0 && Wo_Pa_id.Text.Length != 0)
            {
                table= new DataTable();
                worker = new DataTable();

                command = new MySqlCommand("Select Po_id from position where Po_name = @uL", da.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Wo_Po_id.SelectedItem.ToString();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                
                MySqlCommand command1 = new MySqlCommand("Select Pa_id from partment where Pa_place = @wpai", da.GetConnection());
                command1.Parameters.Add("@wpai", MySqlDbType.VarChar).Value = Wo_Pa_id.SelectedItem.ToString();
                adapter.SelectCommand = command1;
                adapter.Fill(worker);
                
                //command.Parameters.Add("@wN", MySqlDbType.VarChar).Value = Wo_name.Text;
                //command.Parameters.Add("@wP", MySqlDbType.VarChar).Value = Wo_pass.Text;
                //command.Parameters.Add("@wL", MySqlDbType.VarChar).Value = Wo_login.Text;
                //command.Parameters.Add("@wPh", MySqlDbType.VarChar).Value = Wo_phone.Text;

                if (Check(table, worker))
                {
                    int aidishnik1 = int.Parse(table.DefaultView[0][0].ToString());
                    int aidishnik2 = int.Parse(worker.DefaultView[0][0].ToString());
                    //command = new MySqlCommand("INSERT INTO worker (Wo_name,Wo_pass,Wo_login,Wo_Po_id,Wo_Pa_id,Wo_phone) VALUES (@wN,@wP,@wL,@uL,@wpai,@wPh)", da.GetConnection());
                    //adapter.SelectCommand = command;
                    DataTable a = new DataTable();
                    command1 = new MySqlCommand("INSERT INTO worker (Wo_name,Wo_pass,Wo_login,Wo_Po_id,Wo_Pa_id,Wo_phone,Wo_St_id) VALUES (@wN,@wP,@wL,@uL,@wpai,@wPh,1)", da.GetConnection());
                    command1.Parameters.Add("@wN", MySqlDbType.VarChar).Value = Wo_name.Text;
                    command1.Parameters.Add("@wP", MySqlDbType.VarChar).Value = Wo_pass.Text;
                    command1.Parameters.Add("@wL", MySqlDbType.VarChar).Value = Wo_login.Text;
                    command1.Parameters.Add("@wPh", MySqlDbType.VarChar).Value = Wo_phone.Text;
                    command1.Parameters.Add("@uL", MySqlDbType.Int64).Value = aidishnik1;
                    command1.Parameters.Add("@wpai", MySqlDbType.Int64).Value = aidishnik2;
                    da.openConection();
                    command1.ExecuteNonQuery();
                    da.closeConection();
                    Close();
                }
                
            }
            else { MessageBox.Show("Введите данные"); }

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
