using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBackend.Entities
{
    public class Movie : AbstractEntity
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Trailer { get; set; }
        public Genre Genre { get; set; }
        public List<Order> Orders { get; set; }       
    }
}
