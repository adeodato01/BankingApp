using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMarch
{
    /// <summary>
    /// This is a Factory Class
    /// </summary>
    static class Bank
    {
        public static Account CreateAccount(string emailAddress, AccountType accountType, decimal initialDeposit)
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
