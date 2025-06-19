using AccountingLedgerSystem.API.Controllers.Common;
using Core.Application.Queries.TrialBalance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrialBalanceController : BaseApiController
    {
        [HttpGet("get-trial-balance")]
        public async Task<IActionResult> GetTrialBalance()
        {
            var result = await _mediatr.Send(new GetTrialBalanceQuery());
            return Ok(result);
        }

    }
}
