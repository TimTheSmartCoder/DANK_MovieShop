using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBackend.Contexts;
using MovieShopBackend.Entities;

namespace MovieShopBackend.Managers
{
    class CustomerManager : IManager<Customer>
    {
        public Customer Create(Customer t)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                db.Customers.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public List<Customer> ReadAll()
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                return db.Customers.ToList();                
            }
        }

        public Customer ReadOne(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                return db.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public Customer Update(Customer t)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                Customer old = db.Customers.FirstOrDefault(x => x.Id == t.Id);

                if (old == null)
                {
                    return null;
                }
                old.FirstName = t.FirstName;
                old.LastName = t.LastName;
                old.Address = t.Address;
                old.Email = t.Email;
                old.Order = t.Order;

                db.Entry(old).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                Customer delete = db.Customers.FirstOrDefault(x => x.Id == id);

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
