using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JKL_Healthcare_Services.Data;
using JKL_Healthcare_Services.Models;
using Microsoft.AspNetCore.Authorization;

namespace JKL_Healthcare_Services.Controllers
{
    [Authorize(Roles = "Admin,Caregiver")]

    public class CaregiverController : Controller
    {
        private readonly JKL_Healthcare_Services_DbContext _context;

        public CaregiverController(JKL_Healthcare_Services_DbContext context)
        {
            _context = context;
        }

        // GET: Caregiver
        public async Task<IActionResult> Index()
        {
            return View(await _context.Caregivers.ToListAsync());
        }

        // GET: Caregiver/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caregiver = await _context.Caregivers
                .FirstOrDefaultAsync(m => m.CaregiverId == id);
            if (caregiver == null)
            {
                return NotFound();
            }

            return View(caregiver);
        }

        // GET: Caregiver/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caregiver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaregiverId,Name,ContactInfo,IsAvailable")] Caregiver caregiver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caregiver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caregiver);
        }

        // GET: Caregiver/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caregiver = await _context.Caregivers.FindAsync(id);
            if (caregiver == null)
            {
                return NotFound();
            }
            return View(caregiver);
        }

        // POST: Caregiver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaregiverId,Name,ContactInfo,IsAvailable")] Caregiver caregiver)
        {
            if (id != caregiver.CaregiverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caregiver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaregiverExists(caregiver.CaregiverId))
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
            return View(caregiver);
        }

        // GET: Caregiver/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caregiver = await _context.Caregivers
                .FirstOrDefaultAsync(m => m.CaregiverId == id);
            if (caregiver == null)
            {
                return NotFound();
            }

            return View(caregiver);
        }

        // POST: Caregiver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caregiver = await _context.Caregivers.FindAsync(id);
            if (caregiver != null)
            {
                _context.Caregivers.Remove(caregiver);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaregiverExists(int id)
        {
            return _context.Caregivers.Any(e => e.CaregiverId == id);
        }
    }
}
