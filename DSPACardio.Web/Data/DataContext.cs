using DSPACardio.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DSPACardio.Web.Data
{
    public class DataContext : IdentityDbContext<CUser>
    {
        //DB set de tipo paciente
        public DbSet<CPatient>  Patients { get; set; }
        public DbSet<CDoctor> Doctors { get; set; }
        public DbSet<CHospital> Hospitals { get; set; }



        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
            //ORM Mapeo de objetos relaciones (Object relational map)
        }

    }
}
