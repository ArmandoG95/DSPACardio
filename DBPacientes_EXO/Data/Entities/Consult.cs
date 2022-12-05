using System.Collections.Generic;

namespace DBPacientes_EXO.Data.Entities
{
    public class Consult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Consult Consulta { get; set; }
        public ICollection<Treatment> Tratamientos { get; set; }
    }
}
