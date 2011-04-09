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

namespace KitchenTimer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateTime _finish;
        private int _currentMealId;

        public void LoadData()
        {
            // remove the following line
            _currentMealId = 1;
            _finish = DateTime.Now.AddHours(1);
        }

        public DateTime Finish
        {
            get { return _finish; }
            set
            {
                _finish = value;
                NotifyPropertyChanged("Finish");
            }
        }

        public int CurrentMealID
        {
            get { return _currentMealId; }
            set
            {
                _currentMealId = value;
                NotifyPropertyChanged("CurrentMealID");
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
