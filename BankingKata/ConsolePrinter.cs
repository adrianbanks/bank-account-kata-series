using System;

namespace BankingKata
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintBalance(Money balance)
        {
            Console.Write("Balance: £{0}", balance);
        }

        public void PrintStatement(ILedger ledger)
        {
            var lastTransaction = ledger.Accept(new LastTransactionVisitor(), null);
            var lastTransactionAmount = lastTransaction.ApplyTo(new Money(0m));
            Console.Write("Last transaction: £{0}", lastTransactionAmount);
        }

        public ITransaction Visit(ITransaction currentTransaction, ITransaction argument)
        {
            return currentTransaction;
        }

        private class LastTransactionVisitor : ITransactionVisitor<ITransaction>
        {
            public ITransaction Visit(ITransaction currentTransaction, ITransaction argument)
            {
                return currentTransaction;
            }
        }
    }
}