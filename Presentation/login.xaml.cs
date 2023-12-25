using Academy.Domain.Navigation;
using System.Windows;
using System.Windows.Controls;

namespace Happy_New_Year_2024
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : UserControl
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new TreeGame());
        }
    }
}
