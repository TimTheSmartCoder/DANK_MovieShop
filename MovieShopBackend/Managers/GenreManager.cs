using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
