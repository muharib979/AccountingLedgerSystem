using AccountingLedgerSystem.API.Controllers.Common;
using Core.Application.Commands.Accounts;
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
    }
}
