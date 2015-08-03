using System;

namespace BankingKata
{
    public class ChequeDebitEntry : ITransaction
    {
        private readonly DateTime transactionDate;
        private readonly Cheque transactionAmount;

        public ChequeDebitEntry(DateTime transactionDate, Cheque transactionAmount)
        {
            this.transactionDate = transactionDate;
            this.transactionAmount = transactionAmount;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - transactionAmount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as ChequeDebitEntry);
            return transaction != null && transactionAmount.Equals(transaction.transactionAmount);
        }

        public override string ToString()
        {
            return transactionAmount.Format(transactionDate.ToString("dd MMM yyyy"));
        }
    }
}