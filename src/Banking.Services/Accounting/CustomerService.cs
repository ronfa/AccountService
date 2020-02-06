using AutoMapper;
using Banking.Business.Model;
using Banking.Persistence.Repositories.Interfaces;
using Banking.Services.Interfaces;
using Banking.Services.Resources;
using System.Threading.Tasks;

namespace Banking.Services.Accounting
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRespository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ICustomerRespository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResource> GetAsync(int customerId)
        {
            var customer = await _customerRepository.GetAsync(customerId);

            return _mapper.Map<Customer, CustomerResource>(customer);
        }
    }
}
