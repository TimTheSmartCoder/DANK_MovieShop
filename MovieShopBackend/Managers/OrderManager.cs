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
    class OrderManager : AbstractManager<Order>
    {
        protected override List<Order> ReadAll(MovieShopContext movieShopContext)
        {
            return movieShopContext.Set<Order>()
                .Include(x => x.Customer)
                .Include(x => x.Movies)
                .ToList();
        }

        protected override Order ReadOne(int id, MovieShopContext movieShopContext)
        {
            return movieShopContext.Set<Order>()
                .Include(x => x.Customer)
                .Include(x => x.Movies)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
