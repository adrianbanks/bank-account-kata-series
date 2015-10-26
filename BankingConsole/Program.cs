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
            return new AccountBuilder()
                .WithStartingBalance(new Money(1000))
                .WithOverdraftChargeOf(new Money(10))
                .WithArrangedOverdraftLimitOf(new Money(-1500))
                .WithUnarrangedOverdraftLimitOf(new Money(4000))
                .Build();
        }

        public class AccountBuilder
        {
            private Money startingBalance = new Money(0);
            private Money arrangedOverdraftLimit;
            private Money unarrangedOverdraftLimit;
            private Money overdraftCharge;

            public AccountBuilder WithStartingBalance(Money startingBalance)
            {
                this.startingBalance = startingBalance;
                return this;
            }

            public AccountBuilder WithOverdraftChargeOf(Money overdraftCharge)
            {
                this.overdraftCharge = overdraftCharge;
                return this;
            }

            public AccountBuilder WithArrangedOverdraftLimitOf(Money overdraftLimit)
            {
                arrangedOverdraftLimit = overdraftLimit;
                return this;
            }

            public AccountBuilder WithUnarrangedOverdraftLimitOf(Money overdraftLimit)
            {
                unarrangedOverdraftLimit = overdraftLimit;
                return this;
            }

            public IAccount Build()
            {
                var baseAccount = new Account();
                var arrangedOverdraft = new ArrangedOverdraft(arrangedOverdraftLimit, overdraftCharge);
                var accountWithArrangedOverdraft = new AccountWithOverdraft(baseAccount, arrangedOverdraft);
                var unarrangedOverdraft = new UnarrangedOverdraft(unarrangedOverdraftLimit);
                var accountWithUnarrangedOverdraft = new AccountWithOverdraft(accountWithArrangedOverdraft, unarrangedOverdraft);

                baseAccount.Deposit(DateTime.Now, startingBalance);
                return accountWithUnarrangedOverdraft;
            }
        }
    }
}
