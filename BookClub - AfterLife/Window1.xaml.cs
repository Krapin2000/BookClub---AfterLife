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

namespace WpfApp1Shink
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select * from worker where Wo_login = @uL", da.GetConnection());
            command.Parameters.Add("@uL",MySqlDbType.VarChar).Value= Login1.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count>0)
            {
                MessageBox.Show("Всё ок");
                Close();
            }
            else { MessageBox.Show("Неправильный пароль"); }
        }
    }
}
