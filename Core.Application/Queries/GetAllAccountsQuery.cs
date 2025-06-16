using AutoMapper;
using Core.Application.Interfaces.Accounts;
using MediatR;
using Shared.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Queries
{
    public class GetAllAccountsQuery : IRequest<List<AccountDto>>
    {
        public class Handler : IRequestHandler<GetAllAccountsQuery, List<AccountDto>>
        {
            private readonly IAccountRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IAccountRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
            {
                var accounts = await _repository.GetAllAccounts();
                return _mapper.Map<List<AccountDto>>(accounts);
            }
        }
    }
}
