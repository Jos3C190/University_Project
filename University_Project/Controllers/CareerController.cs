using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University_Project.Models;

namespace University_Project.Controllers
{
    public class CareerController : Controller
    {
        private readonly UniversityDbContext _context;

        public CareerController(UniversityDbContext context)
        {
            _context = context;
        }

        // GET: Career
        public async Task<IActionResult> Index()
        {
            return View(await _context.Careers.ToListAsync());
        }

        // GET: Career/Details/?
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers
                .FirstOrDefaultAsync(m => m.CareerId == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // GET: Career/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Career/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CareerId,CareerName,IsActive,Created,CreatedBy,Edited,EditedBy")] Career career)
        {
            if (ModelState.IsValid)
            {
                _context.Add(career);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }

        // GET: Career/Edit/?
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }
            return View(career);
        }

        // POST: Career/Edit/?
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CareerId,CareerName,IsActive,Created,CreatedBy,Edited,EditedBy")] Career career)
        {
            if (id != career.CareerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(career);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerExists(career.CareerId))
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
            return View(career);
        }

        // GET: Career/Delete/?
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers
                .FirstOrDefaultAsync(m => m.CareerId == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // POST: Career/Delete/?
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var career = await _context.Careers.FindAsync(id);
            if (career != null)
            {
                _context.Careers.Remove(career);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerExists(int id)
        {
            return _context.Careers.Any(e => e.CareerId == id);
        }
    }
}
