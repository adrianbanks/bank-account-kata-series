using System;
using BankingKata;

namespace BankingConsole
{
    public class WithdrawAction : IMenuAction
    {
        private UserAmountRequest menuAction;

        public WithdrawAction(UserAmountRequest menuAction)
        {
            this.menuAction = menuAction;
        }

        public void PerformAction(IAccount account)
        {
            menuAction.GetUserInput("Enter an amount to withdraw in pounds:", money =>
            {
                account.Withdraw(new ATMDebitEntry(DateTime.Now, money));
            });
        }
    }
}