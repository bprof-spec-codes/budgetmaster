using BudgetMaster.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Entities.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public int OrganizationId { get; set; }
        public string CreatedByUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string? Position { get; set; }
        public string? TaxId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
