using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMarch
{
    enum TransactionType
    {
        Credit,
        Debit
    }

    class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType TransactionType { get; set; }
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
    }
}
