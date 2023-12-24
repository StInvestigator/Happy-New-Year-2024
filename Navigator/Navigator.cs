﻿using Happy_New_Year_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Academy.Domain.Navigation
{
    public class NavigatorObject
    {
        public static MainWindow? pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher?.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher?.Navigate(newPage, state);
        }
    }
}
