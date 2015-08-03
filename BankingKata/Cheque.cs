namespace BankingKata
{
    public class Cheque : Money
    {
        public string ChequeNumber { get; private set; }

        public Cheque(decimal amount, string chequeNumber) : base(amount)
        {
            ChequeNumber = chequeNumber;
        }
    }
}
