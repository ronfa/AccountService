using AutoMapper;
using Banking.Business.Model;
using Banking.Services.Resources;

namespace AccountService.Mapping
{
    public class ModelToResourceMapper : Profile
    {
        public ModelToResourceMapper()
        {
            CreateMap<Customer, CustomerResource>();
            CreateMap<Account, AccountResource>();
            CreateMap<AddAccountResource, Account>();
            CreateMap<Transaction, TransactionResource>();
            CreateMap<TransactionResource, Transaction>();

        }
    }
}
