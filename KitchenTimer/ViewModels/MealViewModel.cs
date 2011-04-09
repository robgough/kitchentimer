using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using KitchenTimer.Model;

namespace KitchenTimer.ViewModels
{
    public class MealViewModel : INotifyPropertyChanged
    {
        private Meal _meal;

        public MealViewModel()
        {
            MealItems = new ObservableCollection<MealItemViewModel>();
        }
        
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            // do your magic here!
            // get meal
            // foreach mealitem id in meal.mealitems
            // grab and populate MealItems
            _meal = new Meal();
            _meal.Id = 1;
            _meal.Favourite = true;
            _meal.LastCooked = DateTime.Now.AddDays(-7);
            _meal.Name = "Spaghetti Bolegnaise";

            for (int i = 0; i < 5; i++)
            {
                MealItemViewModel mealItem = new MealItemViewModel();
                mealItem.Id = i;
                mealItem.Name = String.Format("Test {0}", i);
                mealItem.Notes = "lorem ipsum, here are some notes. Ooh yah.";
                mealItem.Saved = false;
                mealItem.StandingTime = TimeSpan.FromMinutes(1);
                mealItem.CookingTime = TimeSpan.FromMinutes(12);
                MealItems.Add(mealItem);
            }

            IsDataLoaded = true;
        }

        public int MealID
        { 
            get { return _meal.Id; }
            set
            {
                _meal.Id = value;
                NotifyPropertyChanged("MealID");
            }
        }

        public string Name
        {
            get { return _meal.Name; }
            set
            {
                _meal.Name = value;
                NotifyPropertyChanged("Name");
            }
        }


        public DateTime LastCooked
        {
            get { return _meal.LastCooked; }
            set
            {
                _meal.LastCooked = value;
                NotifyPropertyChanged("LastCooked");
            }
        }


        public bool Favourite
        {
            get { return _meal.Favourite; }
            set
            {
                _meal.Favourite = value;
                NotifyPropertyChanged("Favourite");
            }
        }
        
        public ObservableCollection<MealItemViewModel> MealItems { get; private set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
