using DBPacientes_EXO.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DBPacientes_EXO.Models
{
    public class PatientViewModel:Patient
    {
        public int GenderId { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }

    }
}
