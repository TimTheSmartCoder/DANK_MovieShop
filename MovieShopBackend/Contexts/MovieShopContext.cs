using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBackend.Entities;

namespace MovieShopBackend.Contexts
{
    public class MovieShopContext : DbContext
    {
        public MovieShopContext() : base()
        {
            
        }

        public DbSet<Genre> Genres;
        public DbSet<Movie> Movies;
        public DbSet<Address> Addresses;
        public DbSet<Customer> Customers;
        public DbSet<Order> Orders;
    }
}
