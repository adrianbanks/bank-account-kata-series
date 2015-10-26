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

            if (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1)
            {
                DepositMenu(account);
            }
            else if (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2)
            {
                WithdrawalMenu(account);
            }
            else if (key.Key == ConsoleKey.NumPad3 || key.Key == ConsoleKey.D3)
            {
                var printer = new ConsolePrinter();
                account.PrintLastTransaction(printer);
            }
        }

        private static void DepositMenu(IAccount account)
        {
            PerformAction("Enter an amount to deposit in pounds:", money =>
            {
                account.Deposit(DateTime.Now, money);
            });
        }

        private static void WithdrawalMenu(IAccount account)
        {
            PerformAction("Enter an amount to withdraw in pounds:", money =>
            {
                account.Withdraw(new ATMDebitEntry(DateTime.Now, money));
            });
        }

        private static void PerformAction(string prompt, Action<Money> action)
        {
            Console.WriteLine(prompt);
            Console.WriteLine();
            var line = Console.ReadLine();

            decimal amount;
            if (decimal.TryParse(line, out amount))
            {
                action(new Money(amount));
            }
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
