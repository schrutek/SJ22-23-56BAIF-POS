using Spg.KaufMyStuff.DomainModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public class RegisterDto
    {
        public Genders Gender { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "DU MUSST EINEN VORNAMEN BESITZEN UND EINGEGEN!")]
        [StringLength(20, ErrorMessage = "Nachname darffF (Vader) maximal 20 Zeichen haben!")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Das Format der E-Mail-Adresse ist falsch!")]
        public string EMail { get; set; } = string.Empty;

        [Range(typeof(DateTime), "2023/04/21", "2023/06/21", ErrorMessage = "Datumsrange falsch!")]
        public DateTime BirthDate { get; set; }
    }
}
