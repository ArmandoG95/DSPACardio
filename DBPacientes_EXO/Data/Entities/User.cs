using Microsoft.AspNetCore.Identity;
namespace DBPacientes_EXO.Data.Entities
{
    public class User: IdentityUser
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }

    }
}
