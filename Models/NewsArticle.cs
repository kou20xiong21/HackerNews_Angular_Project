using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews_Angular_Project.Models
{
    public class NewsArticle
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public string Time { get; set; }

        public string Type { get; set; }

        public string By { get; set; }

        //public int Score { get; set; }
        //public int Descendants { get; set; }

        //public Boolean Dead { get; set; }
        //public Boolean Deleted { get; set; }
    }
}
