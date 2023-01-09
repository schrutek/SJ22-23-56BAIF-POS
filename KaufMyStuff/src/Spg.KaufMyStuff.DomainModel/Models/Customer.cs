using Spg.KaufMyStuff.DomainModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Customer : EntityBase
    {
        public Genders Gender { get; set; }
        public long CustomerNumber { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public DateTime RegistrationDateTime { get; private set; }
        public Address? Address { get; set; } = default!;
        public string? PhoneNumber { get; set; }

        private List<ShoppingCart> _shoppingCarts = new();
        public virtual IReadOnlyList<ShoppingCart> ShoppingCarts => _shoppingCarts;

        protected Customer()
        { }
        public Customer(Genders gender,
            long customerNumber,
            string firstName,
            string lastName,
            string eMail,
            DateTime birthDate,
            DateTime registrationDateTime)
        {
            Gender = gender;
            CustomerNumber = customerNumber;
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            BirthDate = birthDate;
            RegistrationDateTime = registrationDateTime;
        }
    }
}
