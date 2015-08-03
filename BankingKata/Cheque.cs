using System;

namespace BankingKata
{
    public class Cheque : Money
    {
        public Cheque(decimal amount) : base(amount)
        {
        }

        public override string Format(DateTime transactionDate)
        {
            return base.Format(transactionDate);
        }
    }
}
