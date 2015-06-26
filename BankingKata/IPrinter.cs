namespace BankingKata
{
    public interface IPrinter
    {
        void PrintBalance(Money balance);
        void PrintStatement(ILedger ledger);
    }
}