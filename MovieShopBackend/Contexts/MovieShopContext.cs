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
            Database.SetInitializer<MovieShopContext>(new DropCreateDatabaseAlways<MovieShopContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Create one-to-one relationship between Customer and Address.
            modelBuilder.Entity<Address>()
                .HasKey(address => address.Id);

            modelBuilder.Entity<Customer>()
                .HasRequired(customer => customer.Address)
                .WithRequiredPrincipal(address => address.Customer);

            //Create one-to-many relationship between Order and Customer.
            modelBuilder.Entity<Order>()
                .HasRequired<Customer>(order => order.Customer)
                .WithMany(customer => customer.Order)
                .HasForeignKey(order => order.CustomerId);

            //Create one-to-many relationship between Movie and Genre.
            modelBuilder.Entity<Movie>()
                .HasRequired<Genre>(movie => movie.Genre)
                .WithMany(genre => genre.Movies)
                .HasForeignKey(movie => movie.GenreId);

            //Create many-to-many relationship between Movie and Orders.
            modelBuilder.Entity<Movie>()
                .HasMany<Order>(movie => movie.Orders)
                .WithMany(order => order.Movies)
                .Map(movieAndOrder =>
                {
                    movieAndOrder.MapLeftKey("MovieRefId");
                    movieAndOrder.MapRightKey("OrderRefId");
                    movieAndOrder.ToTable("MovieAndOrder");
                });

            base.OnModelCreating(modelBuilder);
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
