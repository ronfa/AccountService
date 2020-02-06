using System.Collections.Generic;

namespace Banking.Services.Resources
{
    public class AccountResource
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public IList<TransactionResource> Transactions { get; set; }
        public double Balance { get; set; }
    }
}
