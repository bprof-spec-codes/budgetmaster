using BudgetMaster.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMaster.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Transactions = new HashSet<Transaction>();
            Budgets = new HashSet<Budget>();
            ManagedEmployees = new HashSet<Employee>();
            Currency = "HUF";
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public UserType UserType { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        public bool IsActive { get; set; }

        public int? OrganizationId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? LastLogin { get; set; }

        public virtual Organization? Organization { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Employee> ManagedEmployees { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
