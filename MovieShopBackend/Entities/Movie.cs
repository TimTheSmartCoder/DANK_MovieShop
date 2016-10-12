﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBackend.Entities
{
    public class Movie : AbstractEntity
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string Trailer { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public List<Order> Orders { get; set; }
    }
}
