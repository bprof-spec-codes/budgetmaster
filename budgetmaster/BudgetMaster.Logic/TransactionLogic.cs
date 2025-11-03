using BudgetMaster.Data;
using BudgetMaster.Entities.DTOs.Transaction;
using BudgetMaster.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace BudgetMaster.Logic
{
    public class TransactionLogic
    {
        private readonly BudgetMasterDBContext _context;

        public TransactionLogic(BudgetMasterDBContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> CreateTransactionAsync(CreateTransactionDto dto, string userId)
        {
            // Get user's organization ID
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return null;
            }

            var transaction = new Transaction
            {
                UserId = userId,
                OrganizationId = user.OrganizationId,
                CategoryType = dto.CategoryType,
                TransactionType = dto.TransactionType,
                Amount = dto.Amount,
                Currency = "HUF",
                TransactionDate = dto.TransactionDate.ToDateTime(TimeOnly.MinValue),
                Description = dto.Description ?? string.Empty,
                Notes = string.Empty,
                ExpenseType = null
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            // Detach to prevent lazy loading
            _context.Entry(transaction).State = EntityState.Detached;

            return transaction;
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id, string userId)
        {
            return await _context.Transactions
                .Include(t => t.ExpenseAllocations)
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        public async Task<List<Transaction>> GetUserTransactionsAsync(string userId, TransactionFilterDto? filter = null)
        {
            var query = _context.Transactions
                .Where(t => t.UserId == userId);

            if (filter != null)
            {
                if (filter.StartDate.HasValue)
                {
                    query = query.Where(t => t.TransactionDate >= filter.StartDate.Value);
                }

                if (filter.EndDate.HasValue)
                {
                    query = query.Where(t => t.TransactionDate <= filter.EndDate.Value);
                }

                if (filter.CategoryType.HasValue)
                {
                    query = query.Where(t => t.CategoryType == filter.CategoryType.Value);
                }

                if (filter.TransactionType.HasValue)
                {
                    query = query.Where(t => t.TransactionType == filter.TransactionType.Value);
                }

                if (filter.ExpenseType.HasValue)
                {
                    query = query.Where(t => t.ExpenseType == filter.ExpenseType.Value);
                }

                if (filter.Limit.HasValue && filter.Limit.Value > 0)
                {
                    query = query.Take(filter.Limit.Value);
                }
            }

            return await query.OrderByDescending(t => t.TransactionDate).ToListAsync();
        }

        public async Task<Transaction?> UpdateTransactionAsync(int id, UpdateTransactionDto dto, string userId)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
            {
                return null;
            }

            transaction.CategoryType = dto.CategoryType;
            transaction.Amount = dto.Amount;
            transaction.TransactionDate = dto.TransactionDate.ToDateTime(TimeOnly.MinValue);

            if (dto.Description != null)
                transaction.Description = dto.Description;

            transaction.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await GetTransactionByIdAsync(id, userId);
        }

        public async Task<bool> DeleteTransactionAsync(int id, string userId)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
            {
                return false;
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
