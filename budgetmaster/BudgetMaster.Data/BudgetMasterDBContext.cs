using BudgetMaster.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetMaster.Data
{ 
    public class BudgetMasterDBContext :  IdentityDbContext<AppUser>
    {
        #region dbsets
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ExpenseAllocation> ExpenseAllocations { get; set; }

        #endregion

        public BudgetMasterDBContext(DbContextOptions<BudgetMasterDBContext> options)
       : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.OrganizationId);

            modelBuilder.Entity<Organization>()
                .HasIndex(o => o.TaxNumber)
                .IsUnique();

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.UserId);

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.OrganizationId);

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.TransactionDate);

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.CategoryId);

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.TransactionType);

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => t.ExpenseType);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryType);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.OrganizationId);

            modelBuilder.Entity<Category>()
                .HasIndex(c => new { c.Name, c.OrganizationId, c.CategoryType })
                .IsUnique();

            modelBuilder.Entity<Budget>()
                .HasIndex(b => b.UserId);

            modelBuilder.Entity<Budget>()
                .HasIndex(b => b.OrganizationId);

            modelBuilder.Entity<Budget>()
                .HasIndex(b => new { b.Year, b.Month, b.Quarter });

            modelBuilder.Entity<Budget>()
                .HasIndex(b => new { b.UserId, b.CategoryId, b.Year, b.Month, b.Quarter })
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.OrganizationId);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.IsActive);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmploymentType);

            modelBuilder.Entity<ExpenseAllocation>()
                .HasIndex(ea => ea.TransactionId);

            modelBuilder.Entity<ExpenseAllocation>()
                .HasIndex(ea => ea.EmployeeId);

            modelBuilder.Entity<ExpenseAllocation>()
                .HasIndex(ea => new { ea.TransactionId, ea.EmployeeId })
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Organization)
                .WithMany(o => o.Users)
                .HasForeignKey(u => u.OrganizationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Organization)
                .WithMany(o => o.Transactions)
                .HasForeignKey(t => t.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Organization)
                .WithMany(o => o.Budgets)
                .HasForeignKey(b => b.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.ManagedEmployees)
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExpenseAllocation>()
                .HasOne(ea => ea.Transaction)
                .WithMany(t => t.ExpenseAllocations)
                .HasForeignKey(ea => ea.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExpenseAllocation>()
                .HasOne(ea => ea.Employee)
                .WithMany(e => e.ExpenseAllocations)
                .HasForeignKey(ea => ea.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.CustomCategories)
                .HasForeignKey(c => c.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.UserType)
                .HasConversion<string>();

            modelBuilder.Entity<Organization>()
                .Property(o => o.OrgType)
                .HasConversion<string>();

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryType)
                .HasConversion<string>();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.TransactionType)
                .HasConversion<string>();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.ExpenseType)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmploymentType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
