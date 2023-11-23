using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WashingCarDB.DAL;
using WashingCarDB.DAL.Entities;

namespace WashingCarDB.Controllers
{
    public class VehiclesDetailsController : Controller
    {
        private readonly DataBaseContext _context;

        public VehiclesDetailsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: VehiclesDetails
        public async Task<IActionResult> Index()
        {
              return _context.VehiclesDetails != null ? 
                          View(await _context.VehiclesDetails.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.VehiclesDetails'  is null.");
        }

        // GET: VehiclesDetails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // GET: VehiclesDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiclesDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryDate,Id,CreateDate,ModifieDate")] VehicleDetails vehicleDetails)
        {
            if (ModelState.IsValid)
            {
                vehicleDetails.Id = Guid.NewGuid();
                _context.Add(vehicleDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleDetails);
        }

        // GET: VehiclesDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails.FindAsync(id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }
            return View(vehicleDetails);
        }

        // POST: VehiclesDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeliveryDate,Id,CreateDate,ModifieDate")] VehicleDetails vehicleDetails)
        {
            if (id != vehicleDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDetailsExists(vehicleDetails.Id))
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
            return View(vehicleDetails);
        }

        // GET: VehiclesDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // POST: VehiclesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.VehiclesDetails == null)
            {
                return Problem("Entity set 'DataBaseContext.VehiclesDetails'  is null.");
            }
            var vehicleDetails = await _context.VehiclesDetails.FindAsync(id);
            if (vehicleDetails != null)
            {
                _context.VehiclesDetails.Remove(vehicleDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleDetailsExists(Guid id)
        {
          return (_context.VehiclesDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
