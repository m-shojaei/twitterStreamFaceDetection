using BusinessObjectLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class TwitsDataContext : DbContext
    {
        public TwitsDataContext(DbContextOptions<TwitsDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Twitt> Twitts{ get; set; }
        public DbSet<TwitImage> TwittImages { get; set; }

        //public override int SaveChanges()
        //{
        //    foreach (var history in ChangeTracker.Entries()
        //    .Where(e=>e.Entity is TwitImage && e.State == EntityState.Added)
        //        .Select(e=>e.Entity as TwitImage))
        //    {
        //        history.TwittId = history.
        //    }
        //    return base.SaveChanges();  
        //}
    }
}
