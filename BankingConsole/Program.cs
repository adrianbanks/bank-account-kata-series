using System;
using System.Security.Cryptography;
using BankingKata;

namespace BankingConsole
{
    class Program
    {
        static void Main(string[] args)
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
                // deposit
                Console.WriteLine("deposit");
            }
            else if (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2)
            {
                // withdraw
                Console.WriteLine("withdraw");
            }
            else if (key.Key == ConsoleKey.NumPad3 || key.Key == ConsoleKey.D3)
            {
                var printer = new ConsolePrinter();
                account.PrintLastTransaction(printer);
            }
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
