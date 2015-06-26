using System;

namespace BankingKata
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintBalance(Money balance)
        {
            Console.Write("Balance: £{0}", balance);
        }
    }
}