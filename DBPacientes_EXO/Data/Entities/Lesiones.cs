using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBPacientes_EXO.Data.Entities
{
    public class Lesiones
    {
        public int Id { get; set; }
        public DateTime AccidentDate { get; set; }
        public string AccidentSite { get; set; }

        public string LesionType { get; set; }

        public string BodyPart { get; set; }



    }
}
