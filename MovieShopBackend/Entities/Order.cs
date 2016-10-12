﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBackend.Entities
{
    public class Order : AbstractEntity
    {
        public DateTime Date { get; set; }

        public List<Movie> Movies { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
