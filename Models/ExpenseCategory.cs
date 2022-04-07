using ExpenseTracker.Attirbutes.ValidationAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
   public class ExpenseCategory
   {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      [Required, Display(Name = "Expense Category")]
      [UniqueValue]
      public string Category { get; set; }

      public IEnumerable<ExpenseDetails> ExpenseDetails { get; set; }
   }
}



