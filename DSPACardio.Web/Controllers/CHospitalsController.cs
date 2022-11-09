using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DSPACardio.Web.Data;
using DSPACardio.Web.Data.Entities;

namespace DSPACardio.Web.Controllers
{
    public class CHospitalsController : Controller
    {
        private readonly DataContext _context;

        public CHospitalsController(DataContext context)
        {
            _context = context;
        }

        // GET: CHospitals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hospitals.ToListAsync());
        }

        // GET: CHospitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHospital = await _context.Hospitals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cHospital == null)
            {
                return NotFound();
            }

            return View(cHospital);
        }

        // GET: CHospitals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CHospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HospitalName,Adress")] CHospital cHospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cHospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cHospital);
        }

        // GET: CHospitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHospital = await _context.Hospitals.FindAsync(id);
            if (cHospital == null)
            {
                return NotFound();
            }
            return View(cHospital);
        }

        // POST: CHospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HospitalName,Adress")] CHospital cHospital)
        {
            if (id != cHospital.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cHospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CHospitalExists(cHospital.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cHospital);
        }

        // GET: CHospitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cHospital = await _context.Hospitals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cHospital == null)
            {
                return NotFound();
            }

            return View(cHospital);
        }

        // POST: CHospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cHospital = await _context.Hospitals.FindAsync(id);
            _context.Hospitals.Remove(cHospital);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CHospitalExists(int id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }
}
