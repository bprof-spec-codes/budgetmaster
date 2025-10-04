using BudgetMaster.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace BudgetMaster.Entities.Models
{
    public class ExpenseAllocation : EntityBase
    {
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public decimal AllocatedAmount { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual Transaction Transaction { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
