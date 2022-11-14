namespace DBPacientes_EXO.Data.Entities
{
    public class Patient : User
    {
        public int Id { get; set; }
        public User MyUser { get; set; }




    }
}
