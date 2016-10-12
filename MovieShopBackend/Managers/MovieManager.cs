using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBackend.Contexts;
using MovieShopBackend.Entities;
using System.Data.Entity;

namespace MovieShopBackend.Managers
{

    class MovieManager : IManager<Movie>
    {
    
        public Movie Create(Movie t)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                db.Movies.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public List<Movie> ReadAll()
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                return db.Movies.Include(x => x.Genre).ToList();
            }
        }

        public Movie ReadOne(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                return db.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
            }
        }

        public Movie Update(Movie t)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                Movie old = db.Movies.FirstOrDefault(x => x.Id == t.Id);

                if (old == null)
                {
                    return null;
                }
                old.Genre = t.Genre;
                old.ImageUrl = t.ImageUrl;
                old.Orders = t.Orders;
                old.Price = t.Price;
                old.Title = t.Title;
                old.Trailer = t.Trailer;
                old.Year = t.Year;

                db.Entry(old).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                Movie delete = db.Movies.FirstOrDefault(x => x.Id == id);

                if (delete == null)
                {
                    return false;
                }
                db.Entry(delete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                return true;
            }
        }
    }
}
