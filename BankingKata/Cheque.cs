namespace BankingKata
{
    public class Cheque : Money
    {
        private string m_ChequeNumber;

        public Cheque(decimal amount, string chequeNumber) : base(amount)
        {
            m_ChequeNumber = chequeNumber;
        }

        public string Format(string transactionDate)
        {
            return string.Format("CHQ {0} {1} ({2})", m_ChequeNumber, transactionDate, this);
        }
    }
}
