using System;
using System.Security.Cryptography;
using BankingKata;

namespace BankingConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var account = CreateAccount();

            WelcomeMessage(account);

            while (true)
            {
                MainMenu(account);
            }
        }

        private static void WelcomeMessage(IAccount account)
        {
            Console.WriteLine("Welcome to your account.");
        }

        private static void MainMenu(IAccount account)
        {
            Console.WriteLine();
            Console.WriteLine("Balance: " + account.CalculateBalance());
            Console.WriteLine();
            Console.WriteLine("Press a key to choose an option:");
            Console.WriteLine();
            Console.WriteLine("  1. Cash deposit");
            Console.WriteLine("  2. Cash withdrawal");
            Console.WriteLine("  3. Print last transaction");
            Console.WriteLine();

            var key = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            var userInputMenuAction = new UserAmountRequest();

            var options = new IMenuAction[]
            {
                new DepositAction(userInputMenuAction),
                new WithdrawAction(userInputMenuAction),
                new PrintLastTransactionAction()
            };

            options[0].PerformAction(account);
        }

        private static IAccount CreateAccount()
        {
            return new AccountBuilder()
                .WithStartingBalance(new Money(1000))
                .WithOverdraftChargeOf(new Money(10))
                .WithArrangedOverdraftLimitOf(new Money(1500))
                .WithUnarrangedOverdraftLimitOf(new Money(4000))
                .Build();
        }
    }
}
