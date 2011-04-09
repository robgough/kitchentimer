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
using KitchenTimer.Data;

namespace KitchenTimer.ViewModels
{
    public class MealViewModel : INotifyPropertyChanged
    {
        private Meal _meal;
        MealRepository mealRepository;
        MealItemRepository itemRepository;

        public MealViewModel(int MealId)
        {
            mealRepository = new MealRepository();
            _meal = mealRepository.GetById(MealId);

            MealItems = new ObservableCollection<MealItemViewModel>();
        }
        
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            foreach(var item in itemRepository.GetByIdList(_meal.Items))
            {
                MealItems.Add(new MealItemViewModel(item));
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
