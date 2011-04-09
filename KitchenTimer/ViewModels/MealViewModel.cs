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

namespace KitchenTimer.ViewModels
{
    public class MealViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MealItemViewModel> Timers { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
