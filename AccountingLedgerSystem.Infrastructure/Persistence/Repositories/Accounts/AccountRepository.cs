

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
            var newIdParam = new SqlParameter
            {
                ParameterName = "@NewId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
             "EXEC SP_CreateAccount @Name = {0}, @Type = {1}, @NewId = {2} OUTPUT",
             account.Name,
             account.Type,
             newIdParam
         );

            return (int)newIdParam.Value;
        }
    }
}