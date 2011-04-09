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
using KitchenTimer.Model;

namespace KitchenTimer.ViewModels
{
    public class MealItemViewModel : INotifyPropertyChanged
    {
        public MealItem _mealItem = null;

        public void LoadData()
        {
            _mealItem = new MealItem();
            _mealItem.Id = 1;
            _mealItem.Name = "Spaghetti";
            _mealItem.Notes = "This needs to be strained afterwards, will take about a minute.";
            _mealItem.StandingTime = new TimeSpan(0, 1, 0);
            _mealItem.CookingTime = new TimeSpan(0, 12, 0);
            _mealItem.Saved = true;
        }

        public int Id
        {
            get { return _mealItem.Id; }
            set
            {
                _mealItem.Id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _mealItem.Name; }
            set
            {
                _mealItem.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Notes
        {
            get { return _mealItem.Notes; }
            set
            {
                _mealItem.Notes = value;
                NotifyPropertyChanged("Notes");
            }
        }

        public TimeSpan CookingTime
        {
            get { return _mealItem.CookingTime; }
            set
            {
                _mealItem.CookingTime = value;
                NotifyPropertyChanged("CookingTime");
            }
        }

        public TimeSpan StandingTime
        {
            get { return _mealItem.StandingTime; }
            set
            {
                _mealItem.StandingTime = value;
                NotifyPropertyChanged("StandingTime");
            }
        }

        public bool Saved
        {
            get { return _mealItem.Saved; }
            set
            {
                _mealItem.Saved = value;
                NotifyPropertyChanged("Saved");
            }
        }

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
