using BudgetMaster.Data;
using BudgetMaster.Endpoint.Controllers.Common;
using BudgetMaster.Entities.DTOs.Employee;
using BudgetMaster.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BudgetMaster.Endpoint.Controllers
{
    [Route("employee")]
    public class EmployeeController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] long? organizationId)
        {
            //logic.method();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            //logic.method();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateEmployeeDto dto)
        {
            //logic.method();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            //logic.method();
            return Ok();
        }
    }
}
