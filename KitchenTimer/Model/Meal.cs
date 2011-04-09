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
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class Meal
    {
        public int Id;

        public string Name;

        public DateTime LastCooked;

        public bool Favourite;

        public List<Timer> Timers;
    }
}
