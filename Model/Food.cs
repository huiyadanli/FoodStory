using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Food
    {
        public string ID { get; set; }
        public string UploaderID { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Contents { get; set; }
        public string Date { get; set; }

        public Food()
        {
            ID = "";
            UploaderID = "";
            Title = "";
            Cover = "";
            Contents = "";
            Date = "";
        }
    }
}
