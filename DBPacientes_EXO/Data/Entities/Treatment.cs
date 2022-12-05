using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBPacientes_EXO.Data.Entities
{
    public class Treatment
    {
        public int Id{ get; set; }
        public string PatientTreatment { get; set; }

        public string ExosqueletonType { get; set; }

        public Diagnosis Diagnosis { get; set; }


    }
}
