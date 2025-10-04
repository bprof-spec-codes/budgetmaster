using BudgetMaster.Entities.Common;
using BudgetMaster.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace BudgetMaster.Entities.Models
{
    public class Category : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [MaxLength(50)]
        public string Icon { get; set; }

        [MaxLength(7)]
        public string Color { get; set; }

        public bool IsDefault { get; set; } = false;

        public int? OrganizationId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Organization Organization { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }

    }
}
