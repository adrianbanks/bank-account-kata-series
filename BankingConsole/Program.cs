using System;

using BankingKata;

namespace BankingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = CreateAccount();

            Console.WriteLine("Welcome to your account.");
        }

        private static IAccount CreateAccount()
        {
            var baseAccount = new Account();
            var accountWithArrangedOverdraft = new AccountWithOverdraft(baseAccount,
                new ArrangedOverdraft(new Money(-1500m), new Money(10m)));
            var accountWithUnarrangedOverdraft = new AccountWithOverdraft(accountWithArrangedOverdraft,
                new UnarrangedOverdraft(new Money(-4000m)));

            baseAccount.Deposit(DateTime.Now, new Money(1000m));
            return accountWithUnarrangedOverdraft;
        }
    }
}
