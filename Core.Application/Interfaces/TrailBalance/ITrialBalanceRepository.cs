using Core.Domain.Entities.TrialBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.TrailBalance
{
    public interface ITrialBalanceRepository
    {
        Task<List<TrialBalance>> GetTrialBalanceAsync();
    }
}
