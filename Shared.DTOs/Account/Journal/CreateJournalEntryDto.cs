using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Account.Journal
{
    public class CreateJournalEntryDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<JournalEntryLineDto> Lines { get; set; }
    }
}
