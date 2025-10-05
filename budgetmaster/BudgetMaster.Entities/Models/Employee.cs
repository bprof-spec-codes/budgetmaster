using BudgetMaster.Entities.Common;
using BudgetMaster.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMaster.Entities.Models
{
    public class Employee : EntityBase
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        public EmploymentType EmploymentType { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(50)]
        public string TaxId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(7)]
        public string AvatarColor { get; set; } = "#3B82F6";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual Organization Organization { get; set; }

        public virtual AppUser CreatedByUser { get; set; }

        public virtual ICollection<ExpenseAllocation> ExpenseAllocations { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [NotMapped]
        public string EmploymentTypeDisplay => EmploymentType == EmploymentType.Employee ? "Munkavállaló" : "Alvállalkozó";
    }
}
