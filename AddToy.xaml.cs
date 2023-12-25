using Academy.Domain.Navigation;
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
using System.Windows.Shapes;

namespace Happy_New_Year_2024
{
    /// <summary>
    /// Interaction logic for AddToy.xaml
    /// </summary>
    public partial class AddToy : UserControl
    {
        public AddToy()
        {
            InitializeComponent();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(URL_TB.Text))
            {
                MessageBox.Show("Null url text box!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                try
                {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(URL_TB.Text);
                image.EndInit();
                Toy toy = new Toy(new Image());
                toy.Img.Source = image;
                ToysList.newToy(toy);

                NavigatorObject.Switch(new TreeGame());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    URL_TB.Text = "";
                }
            }
        }
    }
}
