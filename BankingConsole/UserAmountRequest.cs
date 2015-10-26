using System;
using BankingKata;

namespace BankingConsole
{
    public class UserAmountRequest
    {
        public void GetUserInput(string prompt, Action<Money> action)
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
    }
}