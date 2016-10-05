using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBackend.Contexts;
using MovieShopBackend.Entities;

namespace MovieShopBackend.Managers
{
    class GenreManager : IManager<Genre>
    {
        public Genre Create(Genre t)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                db.Genres.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public List<Genre> ReadAll()
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                //--- Debug code.
                //SET breakpoint her under -->
                var connection = db.Database.Connection.ToString();
                //--- Debug code.

                return db.Genres.ToList();
            }

        }

        public Genre ReadOne(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                return db.Genres.FirstOrDefault(x => x.Id == id);
            }
        }

        public Genre Update(Genre t)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                Genre old = db.Genres.FirstOrDefault(x => x.Id == t.Id);

                if (old == null)
                {
                    return null;
                }
                old.Name = t.Name;
                db.Entry(old).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                Genre delete = db.Genres.FirstOrDefault(x => x.Id == id);

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
