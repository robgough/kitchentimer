﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using KitchenTimer.Model;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace KitchenTimer.Data
{
    public class MealItemRepository
    {
        IsolatedStorageFile isfData;
        XDocument doc;
        IsolatedStorageFileStream isfStream;

        public MealItemRepository()
        {
            isfData = IsolatedStorageFile.GetUserStoreForApplication();
            if (isfData.FileExists("MealItems.xml"))
            {
                isfStream = new IsolatedStorageFileStream("MealItems.xml", System.IO.FileMode.Open, isfData);
                doc = XDocument.Load(isfStream);
                isfStream.Close();
            }
            else
            {
                doc = XDocument.Load("MealItems.xml");
                isfStream = new IsolatedStorageFileStream("MealItems.xml", System.IO.FileMode.CreateNew, isfData);
                doc.Save(isfStream);
                isfStream.Close();
            }
        }

        public MealItem GetById(int id)
        {
            var mealItem = from m in doc.Descendants("MealItem")
                       where (string)m.Attribute("Id") == id.ToString()
                       select new MealItem
                       {
                           Id = (int)m.Attribute("Id"),
                           Name = (string)m.Attribute("Name"),
                            CookingTime = (TimeSpan)m.Attribute("CookingTime"),
                             StandingTime = (TimeSpan)m.Attribute("StandingTime"), Saved = (bool)m.Attribute("Saved")
                       };
            return mealItem.FirstOrDefault();
        }

        public List<MealItem> GetByIdList(List<int> ids)
        {
            var mealItem = from m in doc.Descendants("MealItem")
                           where ids.Contains((int)m.Attribute("Id"))
                           select new MealItem
                           {
                               Id = (int)m.Attribute("Id"),
                               Name = (string)m.Attribute("Name"),
                               CookingTime = (TimeSpan)m.Attribute("CookingTime"),
                               StandingTime = (TimeSpan)m.Attribute("StandingTime"),
                               Saved = (bool)m.Attribute("Saved")
                           };
            return mealItem.ToList();
        }

        public List<MealItem> GetSaved()
        {
            var mealItem = from m in doc.Descendants("MealItem")
                           where (bool)m.Attribute("Saved")
                           select new MealItem
                           {
                               Id = (int)m.Attribute("Id"),
                               Name = (string)m.Attribute("Name"),
                               CookingTime = (TimeSpan)m.Attribute("CookingTime"),
                               StandingTime = (TimeSpan)m.Attribute("StandingTime"),
                               Saved = (bool)m.Attribute("Saved")
                           };
            return mealItem.ToList();
        }

    }
}