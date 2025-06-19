using AutoMapper;
using Core.Application.Interfaces.Journal;
using Core.Application.Interfaces.TrailBalance;
using MediatR;
using Shared.DTOs.TrailBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Queries.TrialBalance
{
    public class GetTrialBalanceQuery : IRequest<List<TrialBalanceDto>>
    {
        public class Handler : IRequestHandler<GetTrialBalanceQuery, List<TrialBalanceDto>>
        {
            private readonly ITrialBalanceRepository _repository;
            private readonly IMapper _mapper;

            public Handler(ITrialBalanceRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<TrialBalanceDto>> Handle(GetTrialBalanceQuery request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetTrialBalanceAsync();
                return _mapper.Map<List<TrialBalanceDto>>(result);
            }
        }
    }
}
