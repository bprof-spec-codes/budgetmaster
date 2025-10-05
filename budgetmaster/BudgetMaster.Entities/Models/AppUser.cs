using BudgetMaster.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMaster.Entities.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; } = "HUF";

        public bool IsActive { get; set; } = true;

        public int? OrganizationId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }
        public virtual Organization Organization { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Employee> ManagedEmployees { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
