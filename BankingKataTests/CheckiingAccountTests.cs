using System;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class CheckiingAccountTests
    {
        [Test]
        public void WithdrawingAChequeUpdatesTheAccountBalance()
        {
            var account = new Account();

            account.Deposit(DateTime.Now, new Money(1000));
            account.Withdraw(DateTime.Now, new Cheque(500, ""));

            var balance = account.CalculateBalance();

            Assert.That(balance, Is.EqualTo(new Money(500)));
        }
    }
}
