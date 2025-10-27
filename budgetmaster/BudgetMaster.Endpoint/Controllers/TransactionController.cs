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
        private readonly TransactionLogic _logic;

        public TransactionController(TransactionLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TransactionFilterDto? filter)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var transactions = await _logic.GetUserTransactionsAsync(userId, filter);
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var transaction = await _logic.GetTransactionByIdAsync(id, userId);
            if (transaction == null)
            {
                return NotFound(new { message = "Transaction not found or you don't have permission to view it" });
            }

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var transaction = await _logic.CreateTransactionAsync(dto, userId);
            if (transaction == null)
            {
                return BadRequest(new { message = "Failed to create transaction" });
            }

            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTransactionDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var transaction = await _logic.UpdateTransactionAsync(id, dto, userId);
            if (transaction == null)
            {
                return NotFound(new { message = "Transaction not found or you don't have permission to update it" });
            }

            return Ok(transaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var deleted = await _logic.DeleteTransactionAsync(id, userId);
            if (!deleted)
            {
                return NotFound(new { message = "Transaction not found or you don't have permission to delete it" });
            }

            return Ok(new { message = "Transaction deleted successfully" });
        }

        [HttpGet("export")]
        public async Task<IActionResult> Export([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            //To-Do sprint 2
            return Ok(new { message = "Export functionality coming in sprint 2" });
        }
    }
}
