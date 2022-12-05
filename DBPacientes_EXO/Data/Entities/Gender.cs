using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBPacientes_EXO.Data.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        public string PatientGender { get; set; }

        //Fuertemente tipado <> indica que el ICollection es de tipo Gender
        public ICollection<Patient> Patients { get; set; }
    }
}
