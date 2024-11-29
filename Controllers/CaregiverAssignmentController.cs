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
    public class CaregiverAssignmentController : Controller
    {
        private readonly JKL_Healthcare_Services_DbContext _context;

        public CaregiverAssignmentController(JKL_Healthcare_Services_DbContext context)
        {
            _context = context;
        }

        // GET: CaregiverAssignment
        public async Task<IActionResult> Index()
        {
            var assignments = _context.CaregiverAssignments.Include(c => c.Caregiver).Include(c => c.Patient);
            return View(await assignments.ToListAsync());
        }

        // GET: CaregiverAssignment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caregiverAssignment = await _context.CaregiverAssignments
                .Include(c => c.Caregiver)
                .Include(c => c.Patient)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (caregiverAssignment == null)
            {
                return NotFound();
            }

            return View(caregiverAssignment);
        }

        // GET: CaregiverAssignment/Create
        public IActionResult Create()
        {
            ViewData["CaregiverId"] = new SelectList(_context.Caregivers, "CaregiverId", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Name");
            return View();
        }

        // POST: CaregiverAssignment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,CaregiverId,PatientId,AssignmentNotes")] CaregiverAssignment caregiverAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caregiverAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaregiverId"] = new SelectList(_context.Caregivers, "CaregiverId", "Name", caregiverAssignment.CaregiverId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Name", caregiverAssignment.PatientId);
            return View(caregiverAssignment);
        }

        // GET: CaregiverAssignment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caregiverAssignment = await _context.CaregiverAssignments.FindAsync(id);
            if (caregiverAssignment == null)
            {
                return NotFound();
            }
            ViewData["CaregiverId"] = new SelectList(_context.Caregivers, "CaregiverId", "ContactInfo", caregiverAssignment.CaregiverId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Address", caregiverAssignment.PatientId);
            return View(caregiverAssignment);
        }

        // POST: CaregiverAssignment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId,CaregiverId,PatientId,AssignmentNotes")] CaregiverAssignment caregiverAssignment)
        {
            if (id != caregiverAssignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caregiverAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaregiverAssignmentExists(caregiverAssignment.AssignmentId))
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
            ViewData["CaregiverId"] = new SelectList(_context.Caregivers, "CaregiverId", "ContactInfo", caregiverAssignment.CaregiverId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Address", caregiverAssignment.PatientId);
            return View(caregiverAssignment);
        }

        // GET: CaregiverAssignment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caregiverAssignment = await _context.CaregiverAssignments
                .Include(c => c.Caregiver)
                .Include(c => c.Patient)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (caregiverAssignment == null)
            {
                return NotFound();
            }

            return View(caregiverAssignment);
        }

        // POST: CaregiverAssignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caregiverAssignment = await _context.CaregiverAssignments.FindAsync(id);
            if (caregiverAssignment != null)
            {
                _context.CaregiverAssignments.Remove(caregiverAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaregiverAssignmentExists(int id)
        {
            return _context.CaregiverAssignments.Any(e => e.AssignmentId == id);
        }
    }
}
