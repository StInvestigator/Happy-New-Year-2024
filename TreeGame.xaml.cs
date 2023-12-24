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
                MainCanvas.Children.Add(item.Img);
                Canvas.SetLeft(item.Img, item.x); //set x coordinate of Image
                Canvas.SetTop(item.Img, item.y); //set y coordinate of Image
            }

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("https://static.vecteezy.com/system/resources/previews/011/016/172/original/red-christmas-ball-cutout-free-png.png");
            image.EndInit();
            Toy toy = new Toy(new Image());
            toy.Img.Source = image;
            ToysList.newToy(toy);
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ToysList.selectedToy != null)
            {
                
                var res = Mouse.GetPosition(this);

                res.X -= 25;
                res.Y -= 25;

                ToysList.selectedToy.x = res.X;
                ToysList.selectedToy.y = res.Y;
                Image image = ToysList.selectedToy.Img;
                MainCanvas.Children.Add(image);
                Canvas.SetLeft(image, res.X); //set x coordinate of Image
                Canvas.SetTop(image, res.Y); //set y coordinate of Image
                ToysList.toys.Add(ToysList.selectedToy);
                ToysList.selectedToy = null;

                Toy toy = new Toy(new Image());
                toy.Img.Source = image.Source;
                ToysList.newToy(toy);
            }
        }
    }
}
