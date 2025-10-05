using BudgetMaster.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace BudgetMaster.Entities.Models
{
    public class Budget : EntityBase
    {
        [Required]
        public string UserId { get; set; }

        public int? OrganizationId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal AmountLimit { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; } = "HUF";

        [Required]
        public int Year { get; set; }

        public int? Month { get; set; }

        public int? Quarter { get; set; }

        public bool AlertEnabled { get; set; } = true;

        public int AlertThresholdPercent { get; set; } = 80;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual AppUser User { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Category Category { get; set; }
    }
}
