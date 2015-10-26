using System;
using System.Linq;
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
            var userInputMenuAction = new UserAmountRequest();

            var options = new[]
            {
                new MenuOption(ConsoleKey.NumPad1, "Cash deposit", new DepositAction(userInputMenuAction)),
                new MenuOption(ConsoleKey.NumPad2, "Cash withdrawal", new WithdrawAction(userInputMenuAction)),
                new MenuOption(ConsoleKey.NumPad3, "Print last transaction", new PrintLastTransactionAction())
            };

            Console.WriteLine();
            Console.WriteLine("Balance: " + account.CalculateBalance());
            Console.WriteLine();
            Console.WriteLine("Press a key to choose an option:");
            Console.WriteLine();

            foreach (var option in options)
            {
                option.Print();
            }

            Console.WriteLine();

            var key = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            var selectedMenuOption = options.SingleOrDefault(o => o.ActivatingKey == key.Key);

            selectedMenuOption?.Action.PerformAction(account);
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
