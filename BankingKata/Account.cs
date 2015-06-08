namespace BankingKata
{
    public class Account
    {
        private Money balance;

        public Account(Money openingBalance)
        {
            balance = openingBalance;
        }

        public Money Deposit(Money money)
        {
            balance += money;
            return balance;
        }

        public Money Withdraw(Money money)
        {
            balance -= money;
            return balance;
        }
    }
}