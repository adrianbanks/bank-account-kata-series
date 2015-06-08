using System.Collections;
using System.Collections.Generic;

namespace BankingKata
{
    public class Account : IEnumerable<Transaction>
    {
        private Money balance;
        private readonly Ledger ledger = new Ledger();

        public Account() : this(Money.Zero)
        {
        }

        public Account(Money openingBalance)
        {
            balance = openingBalance;
        }

        public Money Deposit(Money money)
        {
            ledger.Add(new Transaction(money));
            balance += money;
            return balance;
        }

        public Money Withdraw(Money money)
        {
            ledger.Add(new Transaction(-money));
            balance -= money;
            return balance;
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return ledger.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}