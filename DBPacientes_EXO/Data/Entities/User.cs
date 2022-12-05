using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DBPacientes_EXO.Data.Entities
{
    public class User: IdentityUser
    {
        
        [Required (ErrorMessage= "{0} Es obligatorio.")]
        [MaxLength(50, ErrorMessage ="El Nombre {0} no puede tener mas de {1} caracteres.")]
        [Display(Name ="Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} Es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El Apellido {0} no puede tener mas de {1} caracteres.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Neighborhood { get; set; }
        [MaxLength(10, ErrorMessage = "")]
        [Display(Name = "Numero de Telefono")]
        public override string PhoneNumber { get; set; }
        public override string Email { get; set; }

        public string FullName => $"{FirstName}{LastName}";

    }
}
