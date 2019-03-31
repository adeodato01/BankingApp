using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankingAppMarch
{
    /// <summary>
    /// This is a Factory Class
    /// </summary>
    static class Bank
    {

        private static List<Account> accounts = new List<Account>();

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


            accounts.Add(a1);

            return a1;
        }

        public static IEnumerable<Account> GetAllAccountsForUser()
        {
            return accounts;
        }

        private static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber); //This is a LINQ query
            if (account == null)
            {
                //Throw exception
                return null;
            }
            return account;
        }


        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Deposit(amount);
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Withdraw(amount);
        }
    }
}
