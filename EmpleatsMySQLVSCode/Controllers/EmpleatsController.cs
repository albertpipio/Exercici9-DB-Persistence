using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpleatsSQLVSCode.Data;
using EmpleatsSQLVSCode.Models;

namespace EmpleatsSQLVSCode.Controllers
{
    public class EmpleatsController : Controller
    {
        private readonly EmpleatContext _context;

        public EmpleatsController(EmpleatContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string empleatPosition, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> positionQuery = from e in _context.Empleat
                                            orderby e.Position
                                            select e.Position;

            var empleats = from e in _context.Empleat
                         select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                empleats = empleats.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(empleatPosition))
            {
                empleats = empleats.Where(x => x.Position == empleatPosition);
            }

            var empleatPositionVM = new EmpleatPositionViewModel
            {
                Position = new SelectList(await positionQuery.Distinct().ToListAsync()),
                Empleats = await empleats.ToListAsync()
            };

            return View(empleatPositionVM);
        }

        // GET: Empleats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleat = await _context.Empleat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleat == null)
            {
                return NotFound();
            }

            return View(empleat);
        }

        // GET: Empleats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Position,Salary")] Empleat empleat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleat);
        }

        // GET: Empleats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleat = await _context.Empleat.FindAsync(id);
            if (empleat == null)
            {
                return NotFound();
            }
            return View(empleat);
        }

        // POST: Empleats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Position,Salary")] Empleat empleat)
        {
            if (id != empleat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleatExists(empleat.Id))
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
            return View(empleat);
        }

        // GET: Empleats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleat = await _context.Empleat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleat == null)
            {
                return NotFound();
            }

            return View(empleat);
        }

        // POST: Empleats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleat = await _context.Empleat.FindAsync(id);
            _context.Empleat.Remove(empleat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleatExists(int id)
        {
            return _context.Empleat.Any(e => e.Id == id);
        }
    }
}
