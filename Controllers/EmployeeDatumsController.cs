using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabApp.Models;

namespace LabApp.Controllers
{
    public class EmployeeDatumsController : Controller
    {
        private readonly DbLabContext _context;

        public EmployeeDatumsController(DbLabContext context)
        {
            _context = context;
        }

        // GET: EmployeeDatums
        public async Task<IActionResult> Index()
        {
            var dbLabContext = _context.EmployeeData.Include(e => e.Employee);
            return View(await dbLabContext.ToListAsync());
        }

        // GET: EmployeeDatums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDatum = await _context.EmployeeData
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDatum == null)
            {
                return NotFound();
            }

            return View(employeeDatum);
        }

        // GET: EmployeeDatums/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: EmployeeDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Passport,Email,Education,Hobby,EmployeeId")] EmployeeDatum employeeDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeDatum.EmployeeId);
            return View(employeeDatum);
        }

        // GET: EmployeeDatums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDatum = await _context.EmployeeData.FindAsync(id);
            if (employeeDatum == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeDatum.EmployeeId);
            return View(employeeDatum);
        }

        // POST: EmployeeDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Passport,Email,Education,Hobby,EmployeeId")] EmployeeDatum employeeDatum)
        {
            if (id != employeeDatum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDatumExists(employeeDatum.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeDatum.EmployeeId);
            return View(employeeDatum);
        }

        // GET: EmployeeDatums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDatum = await _context.EmployeeData
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDatum == null)
            {
                return NotFound();
            }

            return View(employeeDatum);
        }

        // POST: EmployeeDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDatum = await _context.EmployeeData.FindAsync(id);
            _context.EmployeeData.Remove(employeeDatum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDatumExists(int id)
        {
            return _context.EmployeeData.Any(e => e.Id == id);
        }
    }
}
