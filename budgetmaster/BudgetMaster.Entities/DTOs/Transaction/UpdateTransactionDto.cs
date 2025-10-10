using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Entities.DTOs.Transaction
{
    public class UpdateTransactionDto
    {
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
    }
}
