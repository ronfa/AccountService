using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Services.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IList<AccountResource> Accounts { get; set; }
        public double Balance { get; set; }
    }
}
