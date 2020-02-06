using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.Business.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IList<Account> Accounts {get; set;}
        public double Balance { 
            get {
                return Accounts.Sum(a => a.Balance);
            } 
        }

    }
}
