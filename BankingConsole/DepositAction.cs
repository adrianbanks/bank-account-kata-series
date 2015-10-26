using System;
using BankingKata;

namespace BankingConsole
{
    public class DepositAction : IMenuAction
    {
        private UserAmountRequest menuAction;

        public DepositAction(UserAmountRequest menuAction)
        {
            this.menuAction = menuAction;
        }

        public void PerformAction(IAccount account)
        {
            menuAction.GetUserInput("Enter an amount to deposit in pounds:", money =>
            {
                account.Deposit(DateTime.Now, money);
            });
        }
    }
}