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

namespace BookClub___AfterLife.Windows.Add
{
    /// <summary>
    /// Логика взаимодействия для NewCli.xaml
    /// </summary>
    public partial class NewCli : Window
    {
        public NewCli()
        {
            InitializeComponent();
        }
        public DataTable table = new DataTable();
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        static DB da = new DB();
        public MySqlCommand command = new MySqlCommand("", da.GetConnection());
        private void Add_Cli_Click(object sender, RoutedEventArgs e)
        {
            if (Cl_name.Text.Length !=0&& Cl_phone.Text.Length !=0) {  
                command = new MySqlCommand("INSERT INTO client (Cl_name,Cl_phone,Cl_St_id) VALUES (@wN,@wP,1)", da.GetConnection());
                command.Parameters.Add("@wN", MySqlDbType.VarChar).Value = Cl_name.Text;command.Parameters.Add("@wP", MySqlDbType.VarChar).Value = Cl_phone.Text;
                da.openConection();
                command.ExecuteNonQuery();
                da.closeConection();
                Close(); 
            }
            else { MessageBox.Show("Введите данные"); }
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
