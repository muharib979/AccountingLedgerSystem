using AutoMapper;
using Core.Application.Interfaces.Accounts;
using Core.Domain.Entities.Account;
using MediatR;
using Shared.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Commands.Accounts
{
    public class CreateAccountCommand : AccountDto, IRequest<int>
    {
        public class Handler : IRequestHandler<CreateAccountCommand, int>
        {
            private readonly IAccountRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IAccountRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
            {
                var account = _mapper.Map<Account>(request);
                return await _repository.CreateAccount(account); 
            }
        }
    }
}
