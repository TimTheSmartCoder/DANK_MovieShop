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
            Database.SetInitializer<MovieShopContext>(new DropCreateDatabaseIfModelChanges<MovieShopContext>());
        }

        /// <summary>
        /// Creating and naming the tubles that wil be awailable in the database
        /// </summary>
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
