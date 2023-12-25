using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_New_Year_2024
{
    static class ToysList
    {
        public static Toy selectedToy = null;
        public static List<Toy> toys = new List<Toy>();
        public static void newToy(Toy toy)
        {
            selectedToy = toy;
        }
    }
}
