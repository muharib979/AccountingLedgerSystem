

using Core.Application.Interfaces.Accounts;
using AccountingLedgerSystem.Infrastructure.Persistence.Context;
using Core.Domain.Entities.Account;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAccount(Account account)
        {

            var newId = new SqlParameter("@NewId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            string sql = "EXEC SP_CreateAccount @Name = @Name, @Type = @Type, @NewId = @NewId OUTPUT";

            await _context.Database.ExecuteSqlRawAsync(
                sql,
                new SqlParameter("@Name", account.Name),
                new SqlParameter("@Type", account.Type),
                newId
            );

            return (int)newId.Value;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            {
                return await _context.Accounts
                    .FromSqlRaw("EXEC SP_GetAllAccounts")
                    .ToListAsync();
            }
        }
    }
}