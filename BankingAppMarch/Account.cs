using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMarch
{
    
    enum AccountType
    {
        Checking=1,
        Savings,
        CD,
        Loan
    }
    
    /// <summary>
    /// Account that represents
    /// bank account where you can 
    /// withdraw or deposit money
    /// </summary>

    class Account
    {
        

        #region Properties
        /// <summary>
        /// Unique number for the account
        /// </summary>
        public int AccountNumber { get; private set; }
        /// <summary>
        /// email address of the account holder
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// the dollar amount of the account
        /// </summary>
        public decimal Balance { get; private set; }
        /// <summary>
        /// description of the type of account
        /// </summary>
        public AccountType AccountType { get; set; } //AccountType has been added
        /// <summary>
        /// date the account was created
        /// </summary>
        public DateTime CreatedDate { get; private set; }
        #endregion

        #region Constructor
        public Account()
        {
        
            CreatedDate = DateTime.Now;
        }
        #endregion


        #region Methods

        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Withdraw money from your account
        /// </summary>
        /// <param name="amount">Amount to be withdrawn</param>
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        #endregion
    }
}
