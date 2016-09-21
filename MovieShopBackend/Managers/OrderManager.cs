using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBackend.Contexts;
using MovieShopBackend.Entities;

namespace MovieShopBackend.Managers
{
    internal class OrderManager : IManager<Order>
    {
        public Order Create(Order t)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                db.Orders.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public List<Order> ReadAll()
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                return db.Orders.ToList();
            }
        }

        public Order ReadOne(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                return db.Orders.FirstOrDefault(x => x.Id == id);
            }
        }

        public Order Update(Order t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
