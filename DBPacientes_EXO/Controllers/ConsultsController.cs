using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBPacientes_EXO.Data;
using DBPacientes_EXO.Data.Entities;

namespace DBPacientes_EXO.Controllers
{
    public class ConsultsController : Controller
    {
        private readonly DataContext _context;

        public ConsultsController(DataContext context)
        {
            _context = context;
        }

        // GET: Consults
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consults.ToListAsync());
        }

        // GET: Consults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consult = await _context.Consults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consult == null)
            {
                return NotFound();
            }

            return View(consult);
        }

        // GET: Consults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Consult consult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consult);
        }

        // GET: Consults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consult = await _context.Consults.FindAsync(id);
            if (consult == null)
            {
                return NotFound();
            }
            return View(consult);
        }

        // POST: Consults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Consult consult)
        {
            if (id != consult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultExists(consult.Id))
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
            return View(consult);
        }

        // GET: Consults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consult = await _context.Consults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consult == null)
            {
                return NotFound();
            }

            return View(consult);
        }

        // POST: Consults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consult = await _context.Consults.FindAsync(id);
            _context.Consults.Remove(consult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultExists(int id)
        {
            return _context.Consults.Any(e => e.Id == id);
        }
    }
}
