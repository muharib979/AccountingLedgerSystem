using AccountingLedgerSystem.Infrastructure.Persistence.Context;
using Core.Application.Interfaces.TrailBalance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingLedgerSystem.Infrastructure.Persistence.Repositories.TrialBalance
{
    public class TrialBalanceRepository : ITrialBalanceRepository
    {
        private readonly ApplicationDbContext _context;

        public TrialBalanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Core.Domain.Entities.TrialBalance.TrialBalance>> GetTrialBalanceAsync()
        {
            return await _context.TrialBalances
            .FromSqlRaw("EXEC SP_GetTrialBalance")
            .ToListAsync();
        }
    }
}
