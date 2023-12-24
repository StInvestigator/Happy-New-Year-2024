using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Happy_New_Year_2024
{
    public class Toy
    {
        public double x {  get; set; }
        public double y { get; set; }
        public Image Img { get; set; }
        public Toy(Image img)
        {
            this.x = 0;
            this.y = 0;
            Img = img;
            Img.Width = 50;
            Img.Height = 50;
        }
    }
}
