using BusinessObjectLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer
{
    public class TwittsDataProvider
    {

        private readonly TwitsDataContext _twitsContext;

        public TwittsDataProvider(TwitsDataContext twitsContext)
        {
            _twitsContext = twitsContext;
        }
        public List<Twitt> GetAll(Expression<Func<Twitt, bool>> predicate)
        {
            try
            {
                List<Twitt> list;
                IQueryable<Twitt> dbQuery = _twitsContext.Set<Twitt>();


                list = dbQuery.Where(predicate).ToList();

                return list;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public int Count(Expression<Func<Twitt, bool>> predicate)
        {
            try
            {
                IQueryable<Twitt> dbQuery = _twitsContext.Set<Twitt>();
                return dbQuery.Where(predicate).Count();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public double GetHourlyAverage(string track)
        {
            try
            {
                var avg = _twitsContext.Twitts.Where(t => t.Track.Contains(track)).Select(a => new { a.AddingDate }).GroupBy(t => t.AddingDate.Hour).Average(a => a.Count());

                return avg;
            }
            catch (Exception)
            {

                return 0;
            }

        }
    }
}
