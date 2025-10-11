using BudgetMaster.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Entities.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        public int? OrganizationId { get; set; }
        public int CategoryId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public ExpenseType? ExpenseType { get; set; }
    }
}
