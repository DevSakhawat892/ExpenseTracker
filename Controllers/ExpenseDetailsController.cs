using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
   public class ExpenseDetailsController : Controller
   {
      private readonly ExpenseTrackerContext _context;

      public ExpenseDetailsController(ExpenseTrackerContext context)
      {
         _context = context;
      }


      public async Task<IActionResult> Index(DateTime? StartDate, DateTime? EndDate)
      {
         var expenseTrackerContext = _context.ExpenseDetails.Include(e => e.ExpenseCategory);
         if (StartDate.HasValue && EndDate.HasValue)
         {
            return View(expenseTrackerContext.Where(ed => ed.ExpenseDate >= StartDate && ed.ExpenseDate <= EndDate).AsEnumerable());
         }
         return View(await expenseTrackerContext.ToListAsync());
      }


      // GET: ExpenseDetails/Create
      public IActionResult Create()
      {
         ViewData["CategoryId"] = new SelectList(_context.ExpenseCategories, "Id", "Category");
         return View();
      }

      // POST: ExpenseDetails/Create
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(ExpenseDetails expenseDetails)
      {
         if (ModelState.IsValid)
         {
            _context.Add(expenseDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         ViewData["CategoryId"] = new SelectList(_context.ExpenseCategories, "Id", "Category", expenseDetails.CategoryId);
         return View(expenseDetails);
      }

      // GET: ExpenseDetails/Edit/
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var expenseDetails = await _context.ExpenseDetails.FindAsync(id);
         if (expenseDetails == null)
         {
            return NotFound();
         }
         ViewData["CategoryId"] = new SelectList(_context.ExpenseCategories, "Id", "Category", expenseDetails.CategoryId);
         return View(expenseDetails);
      }

      // POST: ExpenseDetails/Edit/
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, ExpenseDetails expenseDetails)
      {
         if (id != expenseDetails.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               _context.Update(expenseDetails);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!ExpenseDetailsExists(expenseDetails.Id))
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
         ViewData["CategoryId"] = new SelectList(_context.ExpenseCategories, "Id", "Category", expenseDetails.CategoryId);
         return View(expenseDetails);
      }

      // GET: ExpenseDetails/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var expenseDetails = await _context.ExpenseDetails
             .Include(e => e.ExpenseCategory)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (expenseDetails == null)
         {
            return NotFound();
         }

         return View(expenseDetails);
      }

      // POST: ExpenseDetails/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         var expenseDetails = await _context.ExpenseDetails.FindAsync(id);
         _context.ExpenseDetails.Remove(expenseDetails);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool ExpenseDetailsExists(int id)
      {
         return _context.ExpenseDetails.Any(e => e.Id == id);
      }
   }
}
