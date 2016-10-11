using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieShopBackend.Contexts;
using MovieShopBackend.Entities;

namespace MovieShopBackend.Managers
{
    class MovieManager : AbstractManager<Movie>
    {
        protected override List<Movie> ReadAll(MovieShopContext movieShopContext)
        {
            return movieShopContext.Set<Movie>()
                .Include(x => x.Genre)
                .Include(x => x.Orders)
                .ToList();
        }

        protected override Movie ReadOne(int id, MovieShopContext movieShopContext)
        {
            return movieShopContext.Set<Movie>()
                .Include(x => x.Genre)
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
