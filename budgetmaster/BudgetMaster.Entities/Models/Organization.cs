using BudgetMaster.Entities.Common;
using BudgetMaster.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace BudgetMaster.Entities.Models
{
    public class Organization : EntityBase
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string TaxNumber { get; set; }

        public string Address { get; set; }

        [MaxLength(255)]
        public string ContactEmail { get; set; }

        [MaxLength(20)]
        public string ContactPhone { get; set; }

        public OrganizationType OrgType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<AppUser> Users { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Category> CustomCategories { get; set; }
    }
}
