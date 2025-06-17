using AutoMapper;
using Core.Application.Interfaces.Journal;
using Core.Domain.Entities.Journal;
using MediatR;
using Shared.DTOs.Account.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Commands.Journal
{
    public class CreateJournalEntryCommand : CreateJournalEntryDto, IRequest<bool>
    {
        public class Handler : IRequestHandler<CreateJournalEntryCommand, bool>
        {
            private readonly IJournalEntryRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IJournalEntryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateJournalEntryCommand request, CancellationToken cancellationToken)
            {
                var journalEntry = _mapper.Map<JournalEntry>(request);
                return await _repository.CreateJournalEntryAsync(journalEntry, request.Lines);
            }
        }
    }
}