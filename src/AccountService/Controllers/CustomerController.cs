using System.Threading.Tasks;
using Banking.Services.Interfaces;
using Banking.Services.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        /// <summary>
        /// Returns information about an customer, including accounts and transactions
        /// </summary>
        [HttpGet("{id}")]
        public async Task<CustomerResource> GetAsync(int id)
        {
            return await _customerService.GetAsync(id);

        }
    }
}
