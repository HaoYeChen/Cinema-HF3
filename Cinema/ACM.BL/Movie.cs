using System;

namespace ACM.BL
{
    public class Movie
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public int runtime { get; set; }
        public string description { get; set; }
        public DateTime releasedate { get; set; }

        public string MovieName
        {
            get
            {
                return title;   
            }
        }
    }
}
