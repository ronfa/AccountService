using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.Business.Model
{
    public class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IList<Transaction> Transactions {get; set;}
        public double Balance {
            get
            {
                return Transactions.Sum(t => t.Amount);
            }
        }
    }
}
