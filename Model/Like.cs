using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Like
    {
        public string ID { get; set; }
        public string Liker { get; set; }
        public string FoodID { get; set; }
        public string Date { get; set; }

        public Like()
        {
            ID = "";
            Liker = "";
            FoodID = "";
            Date = "";
        }
    }
}
