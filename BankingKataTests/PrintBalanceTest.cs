using System;
using System.IO;
using BankingKata;
using NSubstitute;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public sealed class PrintBalanceTest
    {
        [Test]
        public void BalanceOfZeroIsPassedToThePrinter_ForANewAccount()
        {
            var account = new Account();

            IPrinter printer = Substitute.For<IPrinter>();
            account.OutputBalance(printer);

            printer.Received().PrintBalance(new Money(0m));
        }

        [Test]
        public void BalanceOfZeroIsPrinted_ForANewAccount()
        {
            var account = new Account();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.OutputBalance(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Balance: £0.00";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void BalanceInThousandsIsPrinted()
        {
            var account = new Account();
            account.Deposit(new Money(1234.56m));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.OutputBalance(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Balance: £1,234.56";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void LastTransactionIsPrinted()
        {
            var account = new Account();
            account.Deposit(new Money(123m));
            account.Deposit(new Money(456m));
            account.Deposit(new Money(789m));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            IPrinter printer = new ConsolePrinter();
            account.PrintStatement(printer);

            var output = stringWriter.GetStringBuilder();
            var expected = "Last transaction: £789.00";
            Assert.That(output.ToString(), Is.EqualTo(expected));
        }
    }
}
