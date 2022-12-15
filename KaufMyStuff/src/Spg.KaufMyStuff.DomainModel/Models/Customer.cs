using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public Address Address { get; set; }
        public DateTime BirthDate { get; private set; }

        private List<ShoppingCart> _shoppingCarts = new();
        public IReadOnlyList<ShoppingCart> ShoppingCarts => _shoppingCarts;

        protected Customer()
        { }

        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
