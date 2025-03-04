using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShipCreator.Data;
using ShipCreator.Models;

namespace ShipCreator.Controllers
{
    public class ShipController : Controller
    {
        private readonly ShipCreatorContext _context;

        public ShipController(ShipCreatorContext context)
        {
            _context = context;
        }

        // GET: Ship
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ship.ToListAsync());
        }

        // GET: Ship/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ship
                .FirstOrDefaultAsync(m => m.ShipID == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // GET: Ship/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ship/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipID,Name,Type,NauticalMilage,PledgedFaction")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                ship.ShipID = Guid.NewGuid();
                _context.Add(ship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ship);
        }

        // GET: Ship/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ship.FindAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            return View(ship);
        }

        // POST: Ship/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ShipID,Name,Type,NauticalMilage,PledgedFaction")] Ship ship)
        {
            if (id != ship.ShipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipExists(ship.ShipID))
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
            return View(ship);
        }

        // GET: Ship/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ship
                .FirstOrDefaultAsync(m => m.ShipID == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // POST: Ship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ship = await _context.Ship.FindAsync(id);
            if (ship != null)
            {
                _context.Ship.Remove(ship);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipExists(Guid id)
        {
            return _context.Ship.Any(e => e.ShipID == id);
        }
    }
}
