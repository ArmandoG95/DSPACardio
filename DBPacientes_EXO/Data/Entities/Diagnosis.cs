using System;
using System.Collections.Generic;

namespace DBPacientes_EXO.Data.Entities
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public DateTime datetime { get; set; }

        public ICollection<Diagnosis> Diagnositcos { get; set; }
    }
}
