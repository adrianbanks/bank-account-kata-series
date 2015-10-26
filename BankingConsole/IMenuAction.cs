using BankingKata;

namespace BankingConsole
{
    internal interface IMenuAction
    {
        void PerformAction(IAccount account);
    }
}