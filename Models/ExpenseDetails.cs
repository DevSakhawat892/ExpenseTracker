using Product.Attirbutes.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
   public class ExpenseDetails
   {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      [ForeignKey("ExpenseCategory")]
      //[DisplayColumn(dis("Category"))]
      public int CategoryId { get; set; }

      [Required(ErrorMessage = "Select Today"), Display(Name = "Expense Date")]
      [DataType(DataType.Date), Today, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
      public DateTime ExpenseDate { get; set; }
      public decimal ExpenseAmount { get; set; }

      public virtual ExpenseCategory ExpenseCategory { get; set; }
   }
}
