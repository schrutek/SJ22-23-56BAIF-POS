using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Customer : EntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        //public string Address { get; set; }
        public string City { get; set; } = string.Empty;

        private List<ShoppingCart> _shoppingCarts = new();
        public IReadOnlyList<ShoppingCart> ShoppingCarts => _shoppingCarts;

        public Customer(string firstName, string lastName, string email, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
        }
    }
}
