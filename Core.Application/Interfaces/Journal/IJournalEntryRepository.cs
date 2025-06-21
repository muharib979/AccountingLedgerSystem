using Core.Application.Commands.Journal;
using Core.Domain.Entities.Journal;
using Shared.DTOs.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Journal
{
    public interface IJournalEntryRepository
    {
        Task<bool> CreateJournalEntryAsync(JournalEntry journalEntry, List<CreateJournalEntryLineDto> lines);
        Task<List<JournalEntry>> GetAllJournalEntriesAsync();
    }
}
