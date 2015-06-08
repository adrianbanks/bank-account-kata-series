﻿using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public sealed class EndToEndTests
    {
        [Test]
        public void NewAccountHasZeroBalance()
        {
            Account account = new Account(new Money(0m));

            Assert.That(account == new Money(0m), Is.True);
        }

        [Test]
        public void DepositingAddsToTheBalance()
        {
            Account account = new Account(new Money(0m));
            Money newBalance = account.Deposit(new Money(10m));

            Assert.That(newBalance == new Money(10m), Is.True);
        }

        [Test]
        public void WithdrawingRemovesFromAccount()
        {
            Account account = new Account(new Money(1000000m));
            Money newBalance = account.Withdraw(new Money(999999));

            Assert.That(newBalance == new Money(1), Is.True);
        }
    }
}
