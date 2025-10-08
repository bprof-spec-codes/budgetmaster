using BudgetMaster.Data;
using BudgetMaster.Endpoint.Controllers.Common;
using BudgetMaster.Entities.DTOs.Transaction;
using BudgetMaster.Entities.Models;
using BudgetMaster.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BudgetMaster.Endpoint.Controllers
{
    [Route("transaction")]
    public class TransactionController : ApiControllerBase
    {
        TransactionLogic _logic;
        public TransactionController(TransactionLogic logic)
        {
            this._logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TransactionFilterDto filter)
        {

            //logic.method();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            //logic.method();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            //logic.method();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateTransactionDto dto)
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

        [HttpGet("export")]
        public async Task<IActionResult> Export([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            //To-Do sprint 2
            //logic.method();
            return Ok();

        }
    }
}
