using BankingKata;

namespace BankingConsole
{
    public class PrintLastTransactionAction : IMenuAction
    {
        public void PerformAction(IAccount account)
        {
            var printer = new ConsolePrinter();
            account.PrintLastTransaction(printer);
        }
    }
}