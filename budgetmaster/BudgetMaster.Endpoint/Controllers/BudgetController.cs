using BudgetMaster.Endpoint.Controllers.Common;
using BudgetMaster.Entities.Enums;
using BudgetMaster.Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BudgetMaster.Endpoint.Controllers
{
    [Route("budget")]
    public class BudgetController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? year, [FromQuery] int? month)
        {
           //logic.method();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBudgetDto dto)
        {
            //logic.method();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBudgetDto dto)
        {
            //logic.method();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //logic.method();
            return Ok();
        }
    }
}
