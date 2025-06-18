using AccountingLedgerSystem.API.Controllers.Common;
using Core.Application.Commands.Journal;
using Core.Application.Queries.Journal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerSystem.API.Controllers.Journal
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : BaseApiController
    {

        [HttpPost("save-journal-entry")]
        public async Task<IActionResult> SaveJournalEntry(CreateJournalEntryCommand command)
        {
            return Ok(await _mediatr.Send(command));
        }
        [HttpGet("get-all-journalentries")]
        public async Task<IActionResult> GetAllJournalEntries()
        {
            return Ok(await _mediatr.Send(new GetAllJournalEntriesQuery()));
        }


    }
}
