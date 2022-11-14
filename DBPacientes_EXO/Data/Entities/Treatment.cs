using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBPacientes_EXO.Data.Entities
{
    public class Tratamiento
    {
        public int Id{ get; set; }
        public string Treatment { get; set; }

        public string ExosqueletonType { get; set; }
    }
}
