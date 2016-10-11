using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopBackend.Entities;

namespace MovieShopBackend.TestCode
{
    public class EntityTestRelationShip
    {
        public EntityTestRelationShip()
        {
            IManager<Customer> customerManager = new ManagerFacade().GetCustomerManager();

            Customer customer = new Customer()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "mail@test.dk",
                Address = new Address() { }
            };

            customerManager.Create(customer);

            Customer c = customerManager.ReadOne(0);

            return;
        }
    }
}
