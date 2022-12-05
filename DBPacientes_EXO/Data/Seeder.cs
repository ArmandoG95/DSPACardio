

namespace DBPacientes_EXO.Data
{
    using DBPacientes_EXO.Data.Entities;
    using DBPacientes_EXO.Helpers;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Threading.Tasks;
    public class Seeder
    {
        /// <summary>
        /// seeder te ayuda para tener una base de datos alimentada, el seeder es un alimentador,
        /// se dan de alta al usuario adminstrador, un catalogo, o datos importantes con los que va a funcionar
        /// el proceso debe ser asincrona. PARA PROCESOS ASINCRONOS USAMOS Async
        /// </summary>
        /// 

        //campo de solo lectura para usarlo en el objeto
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        //semillero le pasamos una copia de todos los datos
        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            //obtenemos el dataContext
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        //Metodo para alimentar al semillero
        public async Task SeedAsync()
        {
            //Esta propiedad se asegura de que este creada la base de datos y si no existe la CREA
            await this.dataContext.Database.EnsureCreatedAsync();
            //agregamos roles con ayuda de un helper
            //debemos agregar las clases admin y doctor para todo rol creado, se deben crear la una clase, entidad
            await this.userHelper.CheckRoleAsync("Admin");
            //await this.userHelper.CheckRoleAsync("Doctor");
            await this.userHelper.CheckRoleAsync("Patient");
            if (!this.dataContext.Genders.Any())
            {
                //Para agregar un  nuevo paciente
                this.dataContext.Genders.Add(new Gender { PatientGender = "Femenino" });
                this.dataContext.Genders.Add(new Gender { PatientGender = "Masculino" });

                await this.dataContext.SaveChangesAsync();
            }
            if (!this.dataContext.Patients.Any())
            {
                //Para agregar un  nuevo paciente
                // Salva todos estos datos a tu base de datos
                this.dataContext.Patients.Add(new Patient { Nombre = "Armando" });
                await this.dataContext.SaveChangesAsync();
            }
            if (!this.dataContext.Treatments.Any())
            {
                //Para agregar un  nuevo paciente
                this.dataContext.Treatments.Add(new Treatment { ExosqueletonType = "Brazo" , PatientTreatment = "sobadita"});
                


                await this.dataContext.SaveChangesAsync();
            }




        }
    }
}
