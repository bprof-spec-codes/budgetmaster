
using BudgetMaster.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetMaster.Data
{
    public class BudgetMasterDBContext : DbContext
    {
        #region dbsets
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

        public BudgetMasterDBContext(DbContextOptions<BudgetMasterDBContext> ctx) : base(ctx)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
