using ExpenseTracker.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExpenseTracker.Attirbutes.ValidationAttributes
{
   public class UniqueValueAttribute : ValidationAttribute
   {
      protected override ValidationResult IsValid(
          object value, ValidationContext validationContext)
      {
         var _context = (ExpenseTrackerContext)validationContext.GetService(typeof(ExpenseTrackerContext));
         var entity = _context.ExpenseCategories.SingleOrDefault(ec => ec.Category == value.ToString());

         if (entity != null)
         {
            return new ValidationResult(GetErrorMessage(value.ToString()));
         }
         return ValidationResult.Success;
      }

      public string GetErrorMessage(string category)
      {
         return $"Category {category} is already in use.";
      }
   }
}
