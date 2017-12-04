using System;

namespace BusinessObjectLayer
{
    public class TwitImage
    {
        public TwitImage()
        {
            Detected = false;
            HasFace = false;
        }
        public long Id { get; set; }
        public long TwittId { get; set; }
        public string Url { get; set; }
        public bool HasFace { get; set; }
        public short MaleCount { get; set; }
        public short FemaleCount { get; set; }
        public bool Detected { get; set; }
        public string Track { get; set; }
        public DateTime AddingDate { get; set; }

    }
}
