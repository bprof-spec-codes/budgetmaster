using BudgetMaster.Entities.Common;
using BudgetMaster.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Entities.Models
{
    public class Transaction : EntityBase
    {
        public int Amount { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public Boolean Earning { get; set; }
    }
}
