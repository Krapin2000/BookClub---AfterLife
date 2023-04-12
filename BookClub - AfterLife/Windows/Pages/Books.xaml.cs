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
        public DataTable table = new DataTable();
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        static DB da = new DB();
        public MySqlCommand command = new MySqlCommand("", da.GetConnection());
        public Books()
        {
            InitializeComponent();
            Binding binding = new Binding();
            binding.ElementName = "bname";

        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            command = new MySqlCommand("Select Bo_name as 'Название', Author.Au_name as 'Имя автора', Bo_amount as 'Количество экземпляров', Bo_link as 'Ссылка на картинку', state.st_description as 'Статус' from book,state,author WHERE bo_au_id = author.Au_id and Bo_St_id = state.st_id and Bo_St_id not in(1)", da.GetConnection());
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            adapter.SelectCommand = command;
            da.openConection();
            int con = Tablichka.SelectedItems.Count;
            for (int i = 0; i < con; i++)
            {
                Tablichka.SelectedIndex = i != 0 ? (Tablichka.SelectedIndex + 1) : (Tablichka.SelectedIndex);
                DataRowView rowView = Tablichka.SelectedValue as DataRowView;
                command = new MySqlCommand("UPDATE worker SET Wo_St_id = 2 WHERE Wo_id = @uL", da.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = int.Parse(rowView[0].ToString());

                command.ExecuteNonQuery();
            }
            da.closeConection();
        }

    }
}
