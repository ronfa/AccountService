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
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        /// <summary>
        /// Returns information about a single transaction
        /// </summary>
        [HttpGet("{id}")]
        public async Task<TransactionResource> GetAsync(int id)
        {
            return await _transactionService.GetAsync(id);
        }

        /// <summary>
        /// Adds a new transaction for a given account
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TransactionResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _transactionService.SaveAsync(resource);

            if (!result.Success)
            {
                _logger.LogError($"Error occured while saving transaction for account {resource.AccountId}");
                return BadRequest(result.Message);
            }

            return Ok(result.Transaction);
        }
    }
}
