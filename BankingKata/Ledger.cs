using System.Collections;
using System.Collections.Generic;

namespace BankingKata
{
    public class Ledger : IEnumerable<Transaction>
    {
        private readonly List<Transaction> transactions = new List<Transaction>();

        public void Add(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return transactions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}