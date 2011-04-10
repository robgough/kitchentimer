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
using System.Windows.Navigation;
using KitchenTimer.Data;
using KitchenTimer.ViewModels;

namespace KitchenTimer
{
    public partial class MealPage : PhoneApplicationPage
    {
        

        public MealPage()
        {            
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MealPage_Loaded);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                App.MealViewModel = new MealViewModel(index);
                DataContext = App.MealViewModel;
            }
        }

        private void MealPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.MealViewModel.IsDataLoaded)
            {
                App.MealViewModel.LoadData();
            }
        }

        private void AddTimerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri(String.Format("/AddItemPage.xaml?MealId={0}", App.MealViewModel.MealID), UriKind.Relative));

        }
                
    }
}
