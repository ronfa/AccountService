using System.Threading.Tasks;
using AccountService.Extensions;
using Banking.Services.Interfaces;
using Banking.Services.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        /// <summary>
        /// Retrieve information about an account including transactions
        /// </summary>
        [HttpGet("{id}")]
        public async Task<AccountResource> GetAsync(int id)
        {
            return await _accountService.GetAsync(id);
        }

        /// <summary>
        /// Creates a new account for an existing customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddAccountResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _accountService.SaveAsync(resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Account);
        }

    }
}
