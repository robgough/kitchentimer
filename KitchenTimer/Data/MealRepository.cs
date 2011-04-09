using System;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using KitchenTimer.Model;
using System.IO;


namespace KitchenTimer.Data
{
    public static class MealRepository
    {
        static IsolatedStorageFile isolatedStorageFile;
        static XDocument doc;
        static IsolatedStorageFileStream isolatedStorageStream;

        static List<Meal> mealList = new List<Meal>();
        static bool isDataLoaded;

        //public static MealRepository()
        //{
            //isfData = IsolatedStorageFile.GetUserStoreForApplication();
            //if (isfData.FileExists("Meals.xml"))
            //{
            //    isfStream = new IsolatedStorageFileStream("Meals.xml", System.IO.FileMode.Open, isfData);
            //    doc = XDocument.Load(isfStream);
            //    isfStream.Close();
            //}
            //else
            //{
            //    doc = new XDocument();
            //    isfStream = new IsolatedStorageFileStream("Meals.xml", System.IO.FileMode.CreateNew, isfData);
            //    doc.Save(isfStream);
            //    isfStream.Close();
            //}
        //}

        public static void Load()
        {
            if (!isDataLoaded)
                ReadFromIsolatedStorage();
        }

        public static void Save()
        {
            if (!isDataLoaded)
                ReadFromIsolatedStorage();
        }

        private static void ReadFromIsolatedStorage()
        {
            //isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
            //isolatedStorageStream = new IsolatedStorageFileStream("meals.xml", FileMode.OpenOrCreate, isolatedStorageFile);

            //if (isolatedStorageStream.Length > 0) // presumably 0 if empty?
            //{

            //}

        }

        #region new static version
        public static int AddMeal(Meal meal)
        {
            if (meal.Id < 1) meal.Id = GetNextID();

            mealList.Add(meal);

            return meal.Id;
        }
        public static Meal GetMeal(int id)
        {
            return mealList.First(x => x.Id.Equals(id)); //needs error checking
        }
        // helpers
        private static int GetNextID()
        {
            int output = 0;
            try
            {
                output = mealList.Max(x => x.Id);
            }
            catch { }
            return output + 1;
        }
        #endregion

        //read

        //public Meal GetById(int id)
        //{
        //    var meal = from m in doc.Descendants("Meal")
        //               where (string)m.Attribute("Id") == id.ToString()
        //               select new Meal
        //               {
        //                   Id = (int)m.Attribute("Id"),
        //                   Name = (string)m.Attribute("Name"),
        //                   Favourite = (bool)m.Attribute("Favourite"),
        //                   LastCooked = (DateTime)m.Attribute("LastCooked"),
        //                   Items = (List<int>)m.Descendants("MealItem"),
        //                   Notes = (string)m.Attribute("Notes")
        //               };
        //    return meal.FirstOrDefault();

        //}

        //public List<Meal> GetAll()
        //{
        //    var meals = from m in doc.Descendants("Meal")
        //                select new Meal
        //                {
        //                    Id = (int)m.Attribute("Id"),
        //                    Name = (string)m.Attribute("Name"),
        //                    Favourite = (bool)m.Attribute("Favourite"),
        //                    LastCooked = (DateTime)m.Attribute("LastCooked"),
        //                    Items = (List<int>)m.Descendants("MealItem"),
        //                    Notes = (string)m.Attribute("Notes")
        //                };
        //    return meals.ToList();
        //}

        //public List<Meal> GetFavourites()
        //{
        //    var meals = from m in doc.Descendants("Meal")
        //                where (bool)m.Attribute("Favourite")
        //                select new Meal
        //                {
        //                    Id = (int)m.Attribute("Id"),
        //                    Name = (string)m.Attribute("Name"),
        //                    Favourite = (bool)m.Attribute("Favourite"),
        //                    LastCooked = (DateTime)m.Attribute("LastCooked"),
        //                    Items = (List<int>)m.Descendants("MealItem"),
        //                    Notes = (string)m.Attribute("Notes")
        //                };
        //    return meals.ToList();
        //}

        //public List<Meal> GetMostRecent(int x)
        //{
        //    var meals = from m in doc.Descendants("Meal")
        //                orderby (DateTime)m.Attribute("LastCooked") descending
        //                select new Meal
        //                {
        //                    Id = (int)m.Attribute("Id"),
        //                    Name = (string)m.Attribute("Name"),
        //                    Favourite = (bool)m.Attribute("Favourite"),
        //                    LastCooked = (DateTime)m.Attribute("LastCooked"),
        //                    Items = (List<int>)m.Descendants("MealItem"),
        //                    Notes = (string)m.Attribute("Notes")
        //                };
        //    return meals.Take(x).ToList();
        //}

        //write

        //public int AddMeal(Meal meal)
        //{
        //    int newId = new_record_id();

        //    XElement mealIn = new XElement("Meal",
        //         new XElement("Id", newId),
        //         new XElement("Name", meal.Name),
        //         new XElement("Favourite", meal.Favourite),
        //         new XElement("LastCooked", null),
        //         new XElement("Notes", meal.Notes),
        //         new XElement("Items", new List<int>()));
        //    doc.Root.Add(mealIn);

        //    isfStream.Close();
        //    isfData.DeleteFile("Meals.xml");
        //    isfStream = new IsolatedStorageFileStream("Meals.xml", System.IO.FileMode.Create, isfData);
        //    doc.Save(isfStream);
        //    isfStream.Close();

        //    return newId;
        //}

        //private int new_record_id()
        //{
        //    var meals = from m in doc.Descendants("Meal")
        //                select (int)m.Attribute("Id");
        //    return meals.Last();

        //}

        //public void UpdateMeal(Meal meal)
        //{
        //    doc.Descendants("Meal").Where(x => (int)x.Attribute("Id") == meal.Id).Single().SetAttributeValue("Favourite", meal.Favourite);
        //    doc.Descendants("Meal").Where(x => (int)x.Attribute("Id") == meal.Id).Single().SetAttributeValue("Items", meal.Items);
        //    doc.Descendants("Meal").Where(x => (int)x.Attribute("Id") == meal.Id).Single().SetAttributeValue("Notes", meal.Notes);
        //    isfStream.Close();
        //    isfData.DeleteFile("Meals.xml");
        //    isfStream = new IsolatedStorageFileStream("Meals.xml", System.IO.FileMode.Create, isfData);
        //    doc.Save(isfStream);
        //    isfStream.Close();
        //}
    }
}
