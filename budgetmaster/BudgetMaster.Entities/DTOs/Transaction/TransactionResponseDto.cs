using BudgetMaster.Entities.Enums;

namespace BudgetMaster.Entities.DTOs.Transaction
{
    public class TransactionResponseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateOnly TransactionDate { get; set; }
        public string? Description { get; set; }
        public TransactionType TransactionType { get; set; }
        public CategoryType? CategoryType { get; set; }
        public ExpenseType? ExpenseType { get; set; }
        public string? ReceiptUrl { get; set; }

        // Related entity data (only what we want to expose)
        public string? UserName { get; set; }
        public string? OrganizationName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
