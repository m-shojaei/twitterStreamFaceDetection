using System;
using System.Collections.Generic;

namespace BusinessObjectLayer
{
    public class Twitt
    {
        public Twitt()
        {
            Images = new List<TwitImage>();
            HasImage = false;
        }
        public long Id { get; set; }
        public DateTime AddingDate { get; set; }
        public string Text { get; set; }
        public string Track { get; set; }
        public bool HasImage { get; set; }
        public List<TwitImage> Images { get; set; }
    }

}
