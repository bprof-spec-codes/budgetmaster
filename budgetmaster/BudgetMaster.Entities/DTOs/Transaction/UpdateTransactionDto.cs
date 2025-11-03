using BudgetMaster.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Entities.DTOs.Transaction
{
    public class UpdateTransactionDto
    {
        public CategoryType? CategoryType { get; set; }
        public decimal Amount { get; set; }
        public DateOnly TransactionDate { get; set; }
        public string? Description { get; set; }
    }
}
