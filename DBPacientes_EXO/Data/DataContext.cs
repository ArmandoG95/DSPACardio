using DBPacientes_EXO.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DBPacientes_EXO.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Injury> Injuries { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Consult> Consults { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
