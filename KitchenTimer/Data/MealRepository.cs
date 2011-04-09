using System;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using KitchenTimer.Model;


namespace KitchenTimer.Data
{
    public class MealRepository
    {
        IsolatedStorageFile isfData; 
        XDocument doc;
        IsolatedStorageFileStream isfStream;

        public MealRepository()
        {
            isfData = IsolatedStorageFile.GetUserStoreForApplication();
            if(isfData.FileExists("Meals.xml"))
            {
                isfStream = new IsolatedStorageFileStream("Meals.xml", System.IO.FileMode.Open, isfData);
                doc = XDocument.Load(isfStream);
                isfStream.Close();
            }
            else
            {
                doc = XDocument.Load("Meals.xml");
                isfStream = new IsolatedStorageFileStream("Meals.xml", System.IO.FileMode.CreateNew, isfData);
                doc.Save(isfStream);
                isfStream.Close();
            }
        }

        public Meal GetById(int id)
        {
            var meal = from m in doc.Descendants("Meal")
                       where (string)m.Attribute("Id") == id.ToString()
                       select new Meal { Id = (int)m.Attribute("Id"),
                       Name = (string)m.Attribute("Name"),
                       Favourite = (bool)m.Attribute("Favourite"),
                     LastCooked = (DateTime)m.Attribute("LastCooked"),
                     Items = (List<int>)m.Descendants("MealItem"),
                      Notes = (string)m.Attribute("Notes")
                       };
            return meal.FirstOrDefault();

        }

        public List<Meal> GetAll()
        {
            var meals = from m in doc.Descendants("Meal")
                       select new Meal
                       {
                           Id = (int)m.Attribute("Id"),
                           Name = (string)m.Attribute("Name"),
                           Favourite = (bool)m.Attribute("Favourite"),
                           LastCooked = (DateTime)m.Attribute("LastCooked"),
                           Items = (List<int>)m.Descendants("MealItem"),
                           Notes = (string)m.Attribute("Notes")
                       };
            return meals.ToList();
        }

        public List<Meal> GetFavourites()
        {
            var meals = from m in doc.Descendants("Meal")
                        where (bool)m.Attribute("Favourite")
                        select new Meal
                        {
                            Id = (int)m.Attribute("Id"),
                            Name = (string)m.Attribute("Name"),
                            Favourite = (bool)m.Attribute("Favourite"),
                            LastCooked = (DateTime)m.Attribute("LastCooked"),
                            Items = (List<int>)m.Descendants("MealItem"),
                            Notes = (string)m.Attribute("Notes")
                        };
            return meals.ToList();
        }

        public List<Meal> GetMostRecent(int x)
        {
            var meals = from m in doc.Descendants("Meal")
                        orderby (DateTime)m.Attribute("LastCooked") descending
                        select new Meal
                        {
                            Id = (int)m.Attribute("Id"),
                            Name = (string)m.Attribute("Name"),
                            Favourite = (bool)m.Attribute("Favourite"),
                            LastCooked = (DateTime)m.Attribute("LastCooked"),
                            Items = (List<int>)m.Descendants("MealItem"),
                            Notes = (string)m.Attribute("Notes")
                        };
            return meals.Take(x).ToList();
        }
    }
}
