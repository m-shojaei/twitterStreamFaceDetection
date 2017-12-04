using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class TwittService
    {
        private readonly TwittsDataProvider _TwittsDataProvider;
        public TwittService(TwittsDataProvider TwittsDataProvider)
        {
            _TwittsDataProvider = TwittsDataProvider;
        }

        public int getLastHourTweetsCount(string track)
        {
            var oneHourBefore = DateTime.Now - TimeSpan.FromMinutes(60);
            int count = _TwittsDataProvider.Count(s => s.Track == track && s.AddingDate > oneHourBefore);
            return count;
        }

       public double GetHourlyAverage(string track)
        {
            var res= _TwittsDataProvider.GetHourlyAverage(track);
            return (int)res;
        }
    }
}
