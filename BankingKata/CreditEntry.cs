using System;

namespace BankingKata
{
    public class CreditEntry : ITransaction
    {
        private readonly DateTime transactionDate;
        private readonly Money transactionAmount;

        public CreditEntry(DateTime transactionDate, Money transactionAmount)
        {
            this.transactionDate = transactionDate;
            this.transactionAmount = transactionAmount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as CreditEntry);
            return transaction != null && transactionAmount.Equals(transaction.transactionAmount);
        }

        public Money ApplyTo(Money balance)
        {
            return balance + transactionAmount;
        }

        public override string ToString()
        {
            return transactionAmount.Format(transactionDate);
        }
    }
}