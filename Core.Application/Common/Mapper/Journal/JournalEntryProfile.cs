using AutoMapper;
using Core.Application.Commands.Journal;
using Core.Domain.Entities.Journal;
using Shared.DTOs.Journal;
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
            //CreateMap<JournalEntry, CreateJournalEntryDto>();
            //CreateMap<JournalEntryLine, JournalEntryLineDto>();

            //CreateMap<CreateJournalEntryDto, JournalEntry>();
            //CreateMap<JournalEntryLineDto, JournalEntryLine>();

            CreateMap<JournalEntry, CreateJournalEntryDto>().ReverseMap();
            CreateMap<JournalEntryLine, JournalEntryLineDto>().ReverseMap();
        }
    }
}