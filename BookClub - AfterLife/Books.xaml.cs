using System;
using System.Collections.Generic;
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
using MySql.Data.MySqlClient;
using System.Windows.Shapes;
using System.Data;
using WpfApp1Shink;
using MySqlX.XDevAPI.Relational;
using System.Data.SqlClient;

namespace BookClub___AfterLife
{
    /// <summary>
    /// Логика взаимодействия для Books.xaml
    /// </summary>
    public partial class Books : Page
    {
        public Books()
        {
            InitializeComponent();
            Binding binding = new Binding();
            binding.ElementName = "bname";

        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            DB da = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select Bo_name as 'Название', Author.Au_name as 'Имя автора', Bo_amount as 'Количество экземпляров', Bo_link as 'Ссылка на картинку' from book,author WHERE bo_au_id = author.Au_id ", da.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Tablichka.ItemsSource = null;
            Tablichka.ItemsSource = table.DefaultView;
            //adapter.InsertCommand.Parameters.Add(new SqlParameter("@Bo_name", "Bo_name"));
            //adapter.InsertCommand.Parameters.Add(new SqlParameter("@Bo_amount", "Bo_amount"));
            //adapter.InsertCommand.Parameters.Add(new SqlParameter("@Bo_link", "Bo_link"));
            //adapter.InsertCommand.Parameters.Add(new SqlParameter("@Bo_Au_id", "Bo_Au_id"));
            //adapter.Fill(table);
            //Tablichka.ItemsSource = table.DefaultView;

            //List<GridClassBook> result = new List<GridClassBook>(3);
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    result.Add(new GridClassBook(table.Rows[0].Field<int>(table.Columns[0].Caption), table.Rows[1].Field<string>(table.Columns[1].Caption), table.Rows[2].Field<string>(table.Columns[2].Caption), table.Rows[3].Field<string>(table.Columns[3].Caption)));
            //}
            //Tablichka.ItemsSource = result;
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }
    }
}
