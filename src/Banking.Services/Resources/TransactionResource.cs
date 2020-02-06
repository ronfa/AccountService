using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Services.Resources
{
    public class TransactionResource
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
    }
}
