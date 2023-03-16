using Spg.KaufMyStuff.DomainModel.Enumerations;
using Spg.KaufMyStuff.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public enum GendersDto
    {
        Male = 0,
        Female = 1,
        Other = 2
    }

    public class CreateCustomerDto
    {
        public GendersDto Gender { get; set; }
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Sie müssen das eingeben, Bitte!!")]
        [StringLength(30, MinimumLength = 2)]
        [RegularExpression("^[A-Z][a-z]!")]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress()]
        public string EMail { get; set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public AddressDto? Address { get; set; }
    }
}
