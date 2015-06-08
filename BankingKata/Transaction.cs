namespace BankingKata
{
    public class Transaction
    {
        private readonly Money money;

        public Transaction(Money money)
        {
            this.money = money;
        }

        public static Money operator +(Money lhs, Transaction rhs)
        {
            return lhs + rhs.money;
        }
    }
}