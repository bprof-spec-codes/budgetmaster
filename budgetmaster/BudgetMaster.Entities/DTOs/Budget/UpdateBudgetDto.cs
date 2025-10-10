using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Entities.DTOs.Budget
{
    public class UpdateBudgetDto
    {

        public int? OrganizationId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? AmountLimit { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Quarter { get; set; }
        public bool? AlertEnabled { get; set; }
        public int? AlertThresholdPercent { get; set; }
    }
}
