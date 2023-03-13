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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1Shink;

namespace BookClub___AfterLife
{
    /// <summary>
    /// Логика взаимодействия для People.xaml
    /// </summary>
    public partial class People : Page
    {
        public People()
        {
            InitializeComponent();
        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select Wo_name as 'Имя', position.Po_name as 'Должность', partment.Pa_place as 'Место работы', state.st_description as 'Статус' from worker,partment,state,position WHERE Wo_Pa_id = partment.Pa_id and Wo_St_id = state.st_id and Wo_Po_id = position.Po_id and worker.Wo_St_id NOT IN (2) ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Tablichka.ItemsSource = null;
            Tablichka.ItemsSource = table.DefaultView;

        }
    }
}
