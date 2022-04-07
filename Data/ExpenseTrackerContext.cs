using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
   public class ExpenseTrackerContext : DbContext
   {
      public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options) : base(options)
      {

      }
      public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
      public DbSet<ExpenseDetails> ExpenseDetails { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<ExpenseCategory>()
             .HasIndex(ec => new { ec.Category }).IsUnique(true);
         modelBuilder.Entity<ExpenseCategory>().HasData(
               new ExpenseCategory
               {
                  Id = 1,
                  Category = "House Rent"
               },
              new ExpenseCategory
              {
                 Id = 2,
                 Category = "Water Bill"
              },
              new ExpenseCategory
              {
                 Id = 3,
                 Category = "Electric Bill"
              },
              new ExpenseCategory
              {
                 Id = 4,
                 Category = "Groceries"
              },

              new ExpenseCategory
              {
                 Id = 5,
                 Category = "Uber"
              },

              new ExpenseCategory
              {
                 Id = 6,
                 Category = "Medications"
              }

            );
      }

   }
}


