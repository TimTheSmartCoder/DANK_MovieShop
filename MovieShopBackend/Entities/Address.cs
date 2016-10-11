using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBackend.Entities
{
    public class Address : AbstractEntity
    {
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
