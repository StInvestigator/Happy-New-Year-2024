using Academy.Domain.Navigation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Happy_New_Year_2024
{
    /// <summary>
    /// Interaction logic for TreeGame.xaml
    /// </summary>
    public partial class TreeGame : UserControl
    {
        List<bool> secret = new List<bool>();
        public TreeGame()
        {
            InitializeComponent();

            foreach (var item in ToysList.toys)
            {
                Image image = new Image();
                image.Source = item.Img.Source;
                image.Width = item.Img.Width;
                image.Height = item.Img.Height;
                MainCanvas.Children.Add(image);
                Canvas.SetLeft(image, item.x); //set x coordinate of Image
                Canvas.SetTop(image, item.y); //set y coordinate of Image
            }

            if(ToysList.selectedToy==null) setDefaultToy();

            selectedLoad();
        }
        void selectedLoad()
        {
            SideCanvas.Children.Clear();
            if (ToysList.selectedToy != null)
            {
                Image img = new Image();
                img.Source = ToysList.selectedToy.Img.Source;
                img.Width = 125;
                img.Height = 125;
                SideCanvas.Children.Add(img);
            }
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ToysList.selectedToy != null)
            {
                
                var res = Mouse.GetPosition(this);

                spawnTheToy(res.X-25, res.Y-25);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ToysList.toys.Clear();
            MainCanvas.Children.Clear();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new AddToy());
        }
        private void setDefaultToy()
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("https://static.vecteezy.com/system/resources/previews/011/016/172/original/red-christmas-ball-cutout-free-png.png");
            image.EndInit();
            Toy toy = new Toy(new Image());
            toy.Img.Source = image;
            ToysList.newToy(toy);
        }
        private void setSecretToy()
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("https://cdn-icons-png.flaticon.com/512/3692/3692220.png");
            image.EndInit();
            Toy toy = new Toy(new Image());
            toy.Img.Source = image;
            ToysList.newToy(toy);
        }
        private void spawnTheToy(double x, double y)
        {

            if (x >= 750 && y <= 320 && Santa.Visibility == Visibility.Visible)
            {
                Santa.Visibility = Visibility.Hidden;
                setSecretToy();
                selectedLoad();
            }
            else if(x <= 650 || y<=400)
            {
                ToysList.selectedToy.x = x;
                ToysList.selectedToy.y = y;
                Image image = ToysList.selectedToy.Img;
                MainCanvas.Children.Add(image);
                Canvas.SetLeft(image, x); //set x coordinate of Image
                Canvas.SetTop(image, y); //set y coordinate of Image
                ToysList.toys.Add(ToysList.selectedToy);

                Toy toy = new Toy(new Image());
                toy.Img.Source = image.Source;
                ToysList.newToy(toy);
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && (secret.Count == 0 || secret.Count == 3))
            {
                secret.Add(true);
            }
            else if (e.Key == Key.Right && (secret.Count == 1 || secret.Count == 2))
            {
                secret.Add(true);
            }
            else if (e.Key == Key.Up && (secret.Count == 4))
            {
                secret.Add(true);
            }
            else if (e.Key == Key.Down && (secret.Count == 5))
            {
                secret.Add(true);
            }
            else
            {
                secret.Clear();
            }
            if (secret.Count == 6)
            {
                Santa.Visibility = Visibility.Visible;
            }
        }
    }
}
