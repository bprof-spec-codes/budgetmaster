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

        public async Task<TransactionResponseDto?> GetTransactionByIdAsync(int id, string userId)
        {
            return await _context.Transactions
                .AsNoTracking()
                .Where(t => t.Id == id && t.UserId == userId)
                .Select(t => new TransactionResponseDto
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    TransactionDate = DateOnly.FromDateTime(t.TransactionDate),
                    Description = t.Description,
                    TransactionType = t.TransactionType,
                    CategoryType = t.CategoryType,
                    ExpenseType = t.ExpenseType,
                    ReceiptUrl = t.ReceiptUrl,
                    UserName = t.User != null ? t.User.UserName : null,
                    OrganizationName = t.Organization != null ? t.Organization.Name : null,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<TransactionResponseDto>> GetUserTransactionsAsync(string userId, TransactionFilterDto? filter = null)
        {
            var query = _context.Transactions
                .AsNoTracking()
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
            }

            return await query
                .OrderByDescending(t => t.TransactionDate)
                .Select(t => new TransactionResponseDto
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    TransactionDate = DateOnly.FromDateTime(t.TransactionDate),
                    Description = t.Description,
                    TransactionType = t.TransactionType,
                    CategoryType = t.CategoryType,
                    ExpenseType = t.ExpenseType,
                    ReceiptUrl = t.ReceiptUrl,
                    UserName = t.User != null ? t.User.UserName : null,
                    OrganizationName = t.Organization != null ? t.Organization.Name : null,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<TransactionResponseDto?> UpdateTransactionAsync(int id, UpdateTransactionDto dto, string userId)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
            {
                return null;
            }

            transaction.TransactionType = dto.TransactionType;
            transaction.CategoryType = dto.CategoryType;
            transaction.Amount = dto.Amount;
            transaction.TransactionDate = dto.TransactionDate.ToDateTime(TimeOnly.MinValue);

            if (dto.Description != null)
                transaction.Description = dto.Description;

            transaction.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Detach and return DTO
            _context.Entry(transaction).State = EntityState.Detached;

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
