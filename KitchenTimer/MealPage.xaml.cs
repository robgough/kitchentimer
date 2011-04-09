using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace KitchenTimer
{
    public partial class MealPage : PhoneApplicationPage
    {
        public MealPage()
        {
            InitializeComponent();

            DataContext = App.MealViewModel;
            this.Loaded += new RoutedEventHandler(MealPage_Loaded);
        }

        private void MealPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.MealViewModel.IsDataLoaded)
            {
                App.MealViewModel.LoadData();
            }
        }
    }
}
