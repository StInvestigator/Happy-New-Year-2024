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
using WpfAnimatedGif;

namespace Happy_New_Year_2024
{
    /// <summary>
    /// Interaction logic for AddDecoration.xaml
    /// </summary>
    public partial class AddDecoration : Window
    {
        public AddDecoration()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(URL_TB.Text))
            {
                MessageBox.Show("Null url text box!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            else
            {
                string url = URL_TB.Text;

            }
        }
    }
}
