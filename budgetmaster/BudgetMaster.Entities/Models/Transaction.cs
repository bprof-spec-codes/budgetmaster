using BudgetMaster.Entities.Common;
using BudgetMaster.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace BudgetMaster.Entities.Models
{
    public class Transaction : EntityBase
    {

        public Transaction()
        {
            ExpenseAllocations = new HashSet<ExpenseAllocation>();
            Currency = "HUF";
            TransactionDate = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Description = string.Empty;
            Notes = string.Empty;
            ReceiptUrl = string.Empty;
        }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public int? OrganizationId { get; set; }

        public CategoryType? CategoryType { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; } = "HUF";

        [Required]
        public DateTime TransactionDate { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string Notes { get; set; }

        public ExpenseType? ExpenseType { get; set; }

        [MaxLength(500)]
        public string ReceiptUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual AppUser? User { get; set; }

        public virtual Organization? Organization { get; set; }

        public virtual ICollection<ExpenseAllocation> ExpenseAllocations { get; set; }
    }
}
