using AutoMapper;
using Core.Application.Commands.Journal;
using Core.Domain.Entities.Journal;
using Shared.DTOs.Account.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.Mapper.Accounts.Journal
{
    public class JournalEntryProfile : Profile
    {
        public JournalEntryProfile()
        {
            CreateMap<CreateJournalEntryCommand, JournalEntry>();
            CreateMap<JournalEntryLineDto, JournalEntryLine>();
        }
    }
}