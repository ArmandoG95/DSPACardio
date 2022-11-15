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
    public class InjuriesController : Controller
    {
        private readonly DataContext _context;

        public InjuriesController(DataContext context)
        {
            _context = context;
        }

        // GET: Injuries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Injuries.ToListAsync());
        }

        // GET: Injuries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injury = await _context.Injuries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injury == null)
            {
                return NotFound();
            }

            return View(injury);
        }

        // GET: Injuries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Injuries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccidentDate,AccidentSite,LesionType,BodyPart")] Injury injury)
        {
            if (ModelState.IsValid)
            {
                _context.Add(injury);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(injury);
        }

        // GET: Injuries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injury = await _context.Injuries.FindAsync(id);
            if (injury == null)
            {
                return NotFound();
            }
            return View(injury);
        }

        // POST: Injuries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccidentDate,AccidentSite,LesionType,BodyPart")] Injury injury)
        {
            if (id != injury.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injury);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjuryExists(injury.Id))
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
            return View(injury);
        }

        // GET: Injuries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injury = await _context.Injuries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injury == null)
            {
                return NotFound();
            }

            return View(injury);
        }

        // POST: Injuries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injury = await _context.Injuries.FindAsync(id);
            _context.Injuries.Remove(injury);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjuryExists(int id)
        {
            return _context.Injuries.Any(e => e.Id == id);
        }
    }
}
