using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace TiblerZone
{
    public class TiblerItem
    {
        public TiblerItem()
        {
        }

        // SQLite attributes

        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public DateTime timeitem { get; set; }

       public String color { get; set; }

       public string category { get; set; }

        public string Module { get; set; }
        public string Description { get; set; }
        // TODO: add this field to the user-interface

        public string stringDate { get; set; }
   
    }
}
