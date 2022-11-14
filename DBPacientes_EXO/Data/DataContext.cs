using DBPacientes_EXO.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DBPacientes_EXO.Data
{
    public class DataContext: IdentityDbContext <CUser>
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
    }
}
