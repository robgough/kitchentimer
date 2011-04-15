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
using System.IO.IsolatedStorage;
using KitchenTimer.Model;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace KitchenTimer.Data
{
    public static class MealItemRepository
    {
        #region static version
        static List<MealItem> mealItemList = new List<MealItem>();
        static bool isDataLoaded;

        public static int AddMealItem(MealItem mealItem)
        {
            if (mealItem.Id < 1) mealItem.Id = GetNextID();

            mealItemList.Add(mealItem);

            return mealItem.Id;
        }

        public static MealItem GetMealItem(int id)
        {
            return mealItemList.First(x => x.Id.Equals(id)); //needs error checking
        }

        public static List<MealItem> GetMealListByIdList(List<int> ids)
        {
            return mealItemList.Where(x => ids.Contains(x.Id)).ToList<MealItem>();
        }
        // helpers
        private static int GetNextID()
        {
            int output = 0;
            try
            {
                output = mealItemList.Max(x => x.Id);
            }
            catch { }
            return output + 1;
        }
        #endregion
        //IsolatedStorageFile isfData;
        //XDocument doc;
        //IsolatedStorageFileStream isfStream;

        //public MealItemRepository()
        //{
        //    isfData = IsolatedStorageFile.GetUserStoreForApplication();
        //    if (isfData.FileExists("MealItems.xml"))
        //    {
        //        isfStream = new IsolatedStorageFileStream("MealItems.xml", System.IO.FileMode.Open, isfData);
        //        doc = XDocument.Load(isfStream);
        //        isfStream.Close();
        //    }
        //    else
        //    {
        //        doc = XDocument.Load("MealItems.xml");
        //        isfStream = new IsolatedStorageFileStream("MealItems.xml", System.IO.FileMode.CreateNew, isfData);
        //        doc.Save(isfStream);
        //        isfStream.Close();
        //    }
        //}

        //public MealItem GetById(int id)
        //{
        //    var mealItem = from m in doc.Descendants("MealItem")
        //               where (string)m.Attribute("Id") == id.ToString()
        //               select new MealItem
        //               {
        //                   Id = (int)m.Attribute("Id"),
        //                   Name = (string)m.Attribute("Name"),
        //                    CookingTime = (TimeSpan)m.Attribute("CookingTime"),
        //                     StandingTime = (TimeSpan)m.Attribute("StandingTime"), Saved = (bool)m.Attribute("Saved")
        //               };
        //    return mealItem.FirstOrDefault();
        //}

        //public List<MealItem> GetByIdList(List<int> ids)
        //{
        //    var mealItem = from m in doc.Descendants("MealItem")
        //                   where ids.Contains((int)m.Attribute("Id"))
        //                   select new MealItem
        //                   {
        //                       Id = (int)m.Attribute("Id"),
        //                       Name = (string)m.Attribute("Name"),
        //                       CookingTime = (TimeSpan)m.Attribute("CookingTime"),
        //                       StandingTime = (TimeSpan)m.Attribute("StandingTime"),
        //                       Saved = (bool)m.Attribute("Saved")
        //                   };
        //    return mealItem.ToList();
        //}

        //public List<MealItem> GetSaved()
        //{
        //    var mealItem = from m in doc.Descendants("MealItem")
        //                   where (bool)m.Attribute("Saved")
        //                   select new MealItem
        //                   {
        //                       Id = (int)m.Attribute("Id"),
        //                       Name = (string)m.Attribute("Name"),
        //                       CookingTime = (TimeSpan)m.Attribute("CookingTime"),
        //                       StandingTime = (TimeSpan)m.Attribute("StandingTime"),
        //                       Saved = (bool)m.Attribute("Saved")
        //                   };
        //    return mealItem.ToList();
        //}

        ////write

        //public void AddMealItem(MealItem mealItem)
        //{
        //    int newId = new_record_id();

        //    XElement mealIn = new XElement("MealItem",
        //         new XElement("Id", newId),
        //         new XElement("Name", mealItem.Name),
        //         new XElement("CookingTime", mealItem.CookingTime),
        //         new XElement("StandingTime", mealItem.StandingTime),
        //         new XElement("Notes", mealItem.Notes),
        //         new XElement("Saved", mealItem.Saved));
        //    doc.Root.Add(mealIn);

        //    isfStream.Close();
        //    isfData.DeleteFile("MealItems.xml");
        //    isfStream = new IsolatedStorageFileStream("MealItems.xml", System.IO.FileMode.Create, isfData);
        //    doc.Save(isfStream);
        //    isfStream.Close();
        //}

        //private int new_record_id()
        //{
        //    var mealItems = from m in doc.Descendants("MealItem")
        //                select (int)m.Attribute("Id");
        //    return mealItems.Last();

        //}
    }
}
