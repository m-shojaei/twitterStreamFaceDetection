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
    public class TwittsImageDataProvider
    {

        private readonly TwitsDataContext _twitsContext;

        public TwittsImageDataProvider(TwitsDataContext twitsContext)
        {
            _twitsContext = twitsContext;
        }
        public List<TwitImage> GetAll(Expression<Func<TwitImage, bool>> predicate)
        {
            try
            {
                IQueryable<TwitImage> dbQuery = _twitsContext.Set<TwitImage>();
                var res = dbQuery.Where(predicate).ToList();
                return res;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public List<TwitImage> getLastN(Expression<Func<TwitImage, bool>> predicate, int count)
        {
            try
            {
                IQueryable<TwitImage> dbQuery = _twitsContext.Set<TwitImage>();
                var res = dbQuery.OrderByDescending(i => i.Id).Where(predicate).Take(count).ToList();
                return res;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public List<TwitImage> getFirsttN(Expression<Func<TwitImage, bool>> predicate, int count)
        {
            try
            {
                IQueryable<TwitImage> dbQuery = _twitsContext.Set<TwitImage>();
                var res = dbQuery.OrderBy(i => i.Id).Where(predicate).Take(count).ToList();
                return res;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public int Add(TwitImage twitImage)
        {
            _twitsContext.Add(twitImage);
            return _twitsContext.SaveChanges();
        }

        public void Update(List<TwitImage> items)
        {
            try
            {
                foreach (var item in items)
                {
                    _twitsContext.Set<TwitImage>().Attach(item);
                    _twitsContext.Entry(item).State = EntityState.Modified;
                }

                _twitsContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Rolls back the underlying store transaction.
            }

        }

        public double GetHourlyGenderAverage(string track,string gender)
        {
            try
            {
                #region old
                //var xxzcxzc = (from a in _twitsContext.twitImage.Where(r => r.track.Contains(track) && r.hasFace)
                //               join b in _twitsContext.twitt on a.TwittId equals b.Id
                //               where a.TwittId == b.Id
                //               select new
                //               {
                //                   b.addingDate,
                //                   a.maleCount,
                //                   a.femaleCount,
                //               }).GroupBy(x => x.addingDate.Hour, a =>  (int)a.maleCount ,resultSelector:(a,s)=> new { hour =a,maleCount =  s.Sum()});  
                #endregion
                double res = 0;

                if (gender=="male")
                {
                    res = _twitsContext.TwittImages.Where(t => t.Track.Contains(track) && t.HasFace && t.MaleCount > 0).Select(a => new { a.AddingDate }).GroupBy(t => t.AddingDate.Hour).Average(a => a.Count());
                }
                else
                {
                    res = _twitsContext.TwittImages.Where(t => t.Track.Contains(track) && t.HasFace && t.FemaleCount > 0).Select(a => new { a.AddingDate }).GroupBy(t => t.AddingDate.Hour).Average(a => a.Count());
                }

                return res;

            }
            catch (Exception ex)
            {

                return 0;
            }

        }
    }
}
