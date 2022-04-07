using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
   public class ExpenseCategoriesController : Controller
   {
      private readonly ExpenseTrackerContext _context;

      public ExpenseCategoriesController(ExpenseTrackerContext context)
      {
         _context = context;
      }

      public async Task<IActionResult> Index()
      {
         return View(await _context.ExpenseCategories.ToListAsync());
      }


      // GET: ExpenseCategories/Create
      public IActionResult Create()
      {
         return View();
      }

      // POST: ExpenseCategories/Create

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(ExpenseCategory expenseCategory)
      {
         try
         {
            if (ModelState.IsValid)
            {
               _context.Add(expenseCategory);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
            }
         }
         catch (System.Exception)
         {

            throw;
         }

         return View(expenseCategory);
      }

      // GET: ExpenseCategories/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
         if (expenseCategory == null)
         {
            return NotFound();
         }
         return View(expenseCategory);
      }

      // POST: ExpenseCategories/Edit/5
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, ExpenseCategory expenseCategory)
      {
         if (id != expenseCategory.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               _context.Update(expenseCategory);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!ExpenseCategoryExists(expenseCategory.Id))
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
         return View(expenseCategory);
      }

      // GET: ExpenseCategories/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var expenseCategory = await _context.ExpenseCategories
             .FirstOrDefaultAsync(m => m.Id == id);
         if (expenseCategory == null)
         {
            return NotFound();
         }

         return View(expenseCategory);
      }

      // POST: ExpenseCategories/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
         _context.ExpenseCategories.Remove(expenseCategory);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool ExpenseCategoryExists(int id)
      {
         return _context.ExpenseCategories.Any(e => e.Id == id);
      }
   }
}
