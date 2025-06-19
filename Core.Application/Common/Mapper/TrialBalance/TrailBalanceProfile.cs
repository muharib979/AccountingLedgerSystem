using AutoMapper;
using Core.Domain.Entities.TrialBalance;
using Shared.DTOs.TrailBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.Mapper.TrialBalances
{
    public class TrailBalanceProfile : Profile
    {
        public TrailBalanceProfile() {

            CreateMap<TrialBalance, TrialBalanceDto>();
        }
    }
}
