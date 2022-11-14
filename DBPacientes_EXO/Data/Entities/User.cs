using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DBPacientes_EXO.Data.Entities
{
    public class User: IdentityUser
    {
        public int ID { get; set; }
        [Required (ErrorMessage= "{0} Es obligatorio.")]
        [MaxLength(50, ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres.")]
        [Display(Name ="Nombre")]
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Neighborhood { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
