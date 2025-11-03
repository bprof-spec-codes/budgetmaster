using BudgetMaster.Endpoint.Controllers.Common;
using BudgetMaster.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMaster.Endpoint.Controllers
{
    [Route("enums")]
    public class EnumController : ApiControllerBase
    {
        [HttpGet("category-types")]
        public IActionResult GetCategoryTypes()
        {
            var categoryTypes = Enum.GetValues(typeof(CategoryType))
                .Cast<CategoryType>()
                .Select(e => new
                {
                    Value = (int)e,
                    Name = e.ToString()
                });
            return Ok(categoryTypes);
        }

        [HttpGet("transaction-types")]
        public IActionResult GetTransactionTypes()
        {
            var transactionTypes = Enum.GetValues(typeof(TransactionType))
                .Cast<TransactionType>()
                .Select(e => new
                {
                    Value = (int)e,
                    Name = e.ToString()
                });
            return Ok(transactionTypes);
        }

        [HttpGet("expense-types")]
        public IActionResult GetExpenseTypes()
        {
            var expenseTypes = Enum.GetValues(typeof(ExpenseType))
                .Cast<ExpenseType>()
                .Select(e => new
                {
                    Value = (int)e,
                    Name = e.ToString()
                });
            return Ok(expenseTypes);
        }

        [HttpGet("employment-types")]
        public IActionResult GetEmploymentTypes()
        {
            var employmentTypes = Enum.GetValues(typeof(EmploymentType))
                .Cast<EmploymentType>()
                .Select(e => new
                {
                    Value = (int)e,
                    Name = e.ToString()
                });
            return Ok(employmentTypes);
        }

        [HttpGet("organization-types")]
        public IActionResult GetOrganizationTypes()
        {
            var organizationTypes = Enum.GetValues(typeof(OrganizationType))
                .Cast<OrganizationType>()
                .Select(e => new
                {
                    Value = (int)e,
                    Name = e.ToString()
                });
            return Ok(organizationTypes);
        }

        [HttpGet("user-types")]
        public IActionResult GetUserTypes()
        {
            var userTypes = Enum.GetValues(typeof(UserType))
                .Cast<UserType>()
                .Select(e => new
                {
                    Value = (int)e,
                    Name = e.ToString()
                });
            return Ok(userTypes);
        }
    }
}
