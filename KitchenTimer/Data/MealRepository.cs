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
        //static IsolatedStorageFile isolatedStorageFile;
        //static XDocument doc;
        //static IsolatedStorageFileStream isolatedStorageStream;

        static List<Meal> mealList = new List<Meal>();
        static bool isDataLoaded;

        public static void Load()
        {
            if (!isDataLoaded)
                ReadFromIsolatedStorage();
        }

        public static void Save()
        {
            WriteToIsolatedStorage();
        }

        private static void ReadFromIsolatedStorage()
        {
            //isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
            //isolatedStorageStream = new IsolatedStorageFileStream("meals.xml", FileMode.OpenOrCreate, isolatedStorageFile);

            //if (isolatedStorageStream.Length > 0) // presumably 0 if empty?
            //{

            //}
            isDataLoaded = true;
        }

        private static void WriteToIsolatedStorage()
        {
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
            return mealList.FirstOrDefault(x => x.Id.Equals(id)); //needs error checking
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
              
        public List<Meal> GetAll()
        {            
            return mealList;
        }

        public List<Meal> GetFavourites()
        {
            var meals = from m in mealList
                        where m.Favourite
                        select m;
            return meals.ToList();
        }

        public List<Meal> GetMostRecent(int x)
        {
            var meals = from m in mealList
                        orderby m.LastCooked descending
                        select m;
            return meals.Take(x).ToList();
        }
        
    }
}

