using Academy.Domain.Navigation;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
    /// Interaction logic for TreeGame.xaml
    /// </summary>
    public partial class TreeGame : UserControl
    {
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
        private void spawnTheToy(double x, double y)
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
}
