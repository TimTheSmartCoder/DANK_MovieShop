using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopBackend.Entities
{
    public class Customer : AbstractEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Address Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public List<Order> Order { get; set; }
    }
}
