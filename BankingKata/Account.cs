using System;

namespace BankingKata
{
    public class Account : IEquatable<Money>
    {
        private Money balance;

        public Account(Money openingBalance)
        {
            balance = openingBalance;
        }

        public bool Equals(Money other)
        {
            return balance == other;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public static bool operator ==(Account account, Money money)
        {
            return account.Equals(money);
        }

        public static bool operator !=(Account account, Money money)
        {
            return !(account == money);
        }

        public void Deposit(Money money)
        {
            balance += money;
        }

        public void Withdraw(Money money)
        {
            balance -= money;
        }
    }
}