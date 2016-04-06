using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Farvorite
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string FoodID { get; set; }
        public string Date { get; set; }

        public Farvorite()
        {
            ID = "";
            UserID = "";
            FoodID = "";
            Date = "";
        }
    }
}
