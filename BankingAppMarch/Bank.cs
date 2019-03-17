using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMarch
{
    static class Bank
    {
        public static Account CreateAccount(string emailAddress, string accountType, decimal initialDeposit)
        {
            var a1 = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if (initialDeposit > 0)
            {
                a1.Deposit(initialDeposit);
            }

            return a1;
        }
    }
}
