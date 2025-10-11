using BudgetMaster.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Entities.DTOs.Transaction
{
    public class TransactionFilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CategoryId { get; set; }
        public TransactionType? TransactionType { get; set; }
        public ExpenseType? ExpenseType { get; set; }
        public int? Limit { get; set; }
    }
}
