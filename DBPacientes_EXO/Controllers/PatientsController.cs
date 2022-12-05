using DBPacientes_EXO.Data;
using DBPacientes_EXO.Data.Entities;
using DBPacientes_EXO.Helpers;
using DBPacientes_EXO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DBPacientes_EXO.Controllers
{
    public class PatientsController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;

        //Declaramos constructor para que no reciba datos nulos
        public PatientsController(DataContext datacontext, ICombosHelper combosHelper)
        {
            this.dataContext = datacontext;
            this.combosHelper = combosHelper;
        }

        // GET: Gender
        public async Task<IActionResult> Index()
        {
            return View(await this.dataContext.Patients
                .Include(p => p.Gender)
                .Include(p => p.User)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await this.dataContext.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PatientViewModel
            {
                Genders = this.combosHelper.GetComboGenders()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = new Patient
                {
                    Gender = await this.dataContext.Genders.FindAsync(model.GenderId)
                };
                this.dataContext.Add(patient);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await this.dataContext.Patients
                .Include(p => p.Gender)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientViewModel
            {
                Id = patient.Id,
                Gender = patient.Gender,
                GenderId = patient.Gender.Id,
                Genders = this.combosHelper.GetComboGenders()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientViewModel model)
        {

            if (ModelState.IsValid)
            {
                var patient = new Patient
                {
                    Id = model.Id,
                    Gender = await this.dataContext.Genders.FindAsync(model.GenderId)
                };
                this.dataContext.Update(patient);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await this.dataContext.Patients
                .FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await this.dataContext.Patients.FindAsync(id);
            this.dataContext.Patients.Remove(patient);
            await this.dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return this.dataContext.Patients.Any(e => e.Id == id);
        }
    }
}
