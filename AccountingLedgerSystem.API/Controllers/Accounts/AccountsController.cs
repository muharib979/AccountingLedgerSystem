using AccountingLedgerSystem.API.Controllers.Common;
using Core.Application.Commands.Accounts;
using Core.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerSystem.API.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseApiController
    {
        [HttpPost("save-account")]
        public async Task<IActionResult> SaveAccount(CreateAccountCommand command)
        {
            return Ok(await _mediatr.Send(command));
        }

        [HttpGet("get-all-accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            return Ok(await _mediatr.Send(new GetAllAccountsQuery()));
        }
    }
}
