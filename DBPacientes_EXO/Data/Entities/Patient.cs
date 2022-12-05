namespace DBPacientes_EXO.Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public User User { get; set; }

        public Gender Gender { get; set; }


    }
}
