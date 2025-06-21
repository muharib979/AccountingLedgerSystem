using AutoMapper;
using Core.Application.Interfaces.Journal;
using MediatR;
using Shared.DTOs.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Queries.Journal
{
    public class GetAllJournalEntriesQuery : IRequest<List<JournalEntryDto>>
    {
        public class Handler : IRequestHandler<GetAllJournalEntriesQuery, List<JournalEntryDto>>
        {
            private readonly IJournalEntryRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IJournalEntryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<JournalEntryDto>> Handle(GetAllJournalEntriesQuery request, CancellationToken cancellationToken)
            {
                var entries = await _repository.GetAllJournalEntriesAsync();
                return _mapper.Map<List<JournalEntryDto>>(entries);
            }
        }
    }
}
