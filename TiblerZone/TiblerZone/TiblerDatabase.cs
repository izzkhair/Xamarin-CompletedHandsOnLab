using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using SQLite;
using Xamarin.Forms;

namespace TiblerZone
{
   public class TiblerDatabase
    {
        static object locker = new object();
         SQLiteConnection database;

           
        public TiblerDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<TiblerItem>();
        }

        public IEnumerable<TiblerItem> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<TiblerItem>() select i).ToList();
            }
        }

        public IEnumerable<TiblerItem> GetItemsList()
        {
            lock (locker)
            {
                return database.Query<TiblerItem>("Select * From[TiblerItem] Order By [timeitem]");
            }
        }

        public IEnumerable<TiblerItem> GetItemsLecture()
        {
            lock (locker)
            {
                return database.Query<TiblerItem>("Select * From[TiblerItem] Where [category]='Lecture' Order By [timeitem]");
            }
        }

        public IEnumerable<TiblerItem> GetItemsTask()
        {
            lock (locker)
            {
                return database.Query<TiblerItem>("Select * From[TiblerItem] Where [category]='Task' Order By [timeitem]");
            }
        }

        public IEnumerable<TiblerItem> GetItemsMeeting()
        {
            lock (locker)
            {
                return database.Query<TiblerItem>("Select * From[TiblerItem] Where [category]='Meeting' Order By [timeitem]");
            }
        }

        public IEnumerable<TiblerItem> GetItemsNotDone()
        {
            lock (locker)
            {
                return database.Query<TiblerItem>("Select * From[TiblerItem] Where [Done]=0");
            } 
        }


        public TiblerItem GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<TiblerItem>().FirstOrDefault(x => x.ID == id);
       
            }
        }

        public int SaveItem(TiblerItem item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<TiblerItem>(id);
            }
        }

    }
}
