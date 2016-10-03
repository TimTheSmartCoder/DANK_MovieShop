using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBackend.Entities
{
    public class Movie : AbstractEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public string Trailer { get; set; }

        public Genre Genre { get; set; }

        public List<Order> Orders { get; set; }       
    }
}
