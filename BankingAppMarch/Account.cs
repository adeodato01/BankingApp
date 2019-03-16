using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMarch
{
    class Account
    {
        public int AccountNumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
