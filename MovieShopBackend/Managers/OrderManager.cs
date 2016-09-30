﻿using System;
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
            using (MovieShopContext db = new MovieShopContext())
            {
                Order old = db.Orders.FirstOrDefault(x => x.Id == t.Id);

                if (old == null)
                {
                    return null;
                }
                old.Movies = t.Movies;
                old.Customer = t.Customer;
                old.Date = t.Date;

                db.Entry(old).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (MovieShopContext db = new MovieShopContext())
            {
                Order delete = db.Orders.FirstOrDefault(x => x.Id == id);

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