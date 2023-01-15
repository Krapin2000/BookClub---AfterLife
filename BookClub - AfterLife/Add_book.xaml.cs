using Microsoft.Win32;
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
using System.Windows.Shapes;
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
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
          

            OpenFileDialog qweqw = new OpenFileDialog();
            if (qweqw.ShowDialog() == true) 
            {
                Oblojka.Source = BitmapFrame.Create(new Uri(qweqw.FileName));

            }
            
                
        }
    }
}
