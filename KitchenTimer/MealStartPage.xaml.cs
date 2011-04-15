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
using KitchenTimer.Model;
using KitchenTimer.Data;

namespace KitchenTimer
{
    public partial class MealStartPage : PhoneApplicationPage
    {
        public MealStartPage()
        {
            InitializeComponent();
        }

        public string MealName { get; set; }
        public bool Favourite { get; set; }
        public string Notes { get; set; }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Meal meal = new Meal();
            meal.Name = textName.Text;
            meal.Favourite = Favourite;
            meal.Notes = Notes;

            int id = MealRepository.AddMeal(meal);

            NavigationService.Navigate(new System.Uri(String.Format("/MealPage.xaml?selectedItem={0}", id), UriKind.Relative));
        }
    }
}