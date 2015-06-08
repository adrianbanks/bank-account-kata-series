using System.Linq;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public sealed class EndToEndTests
    {
        [Test]
        public void NewAccountHasZeroBalance()
        {
            var account = new Account();
            var openingBalance = account.Deposit(Money.Zero);

            Assert.That(openingBalance == Money.Zero, Is.True);
        }

        [Test]
        public void DepositingAddsToTheBalance()
        {
            var account = new Account();
            var newBalance = account.Deposit(Money.ValueOf(10m));

            Assert.That(newBalance == Money.ValueOf(10m), Is.True);
        }

        [Test]
        public void WithdrawingRemovesFromAccount()
        {
            var account = new Account(Money.ValueOf(1000000m));
            var newBalance = account.Withdraw(Money.ValueOf(999999));

            Assert.That(newBalance == Money.ValueOf(1), Is.True);
        }

        [Test]
        public void NewAccountHasNoTransactions()
        {
            var account = new Account();
            Assert.That(account, Is.Empty);
        }

        [Test]
        public void DepositAddsATransaction()
        {
            var account = new Account();
            account.Deposit(Money.ValueOf(42m));

            Assert.DoesNotThrow(() => account.Single());
        }

        [Test]
        public void WithdrawAddsATransaction()
        {
            var account = new Account();
            account.Withdraw(Money.ValueOf(42m));

            Assert.DoesNotThrow(() => account.Single());
        }

        [Test]
        public void TransactionsCanBeReplayedToGetBalance()
        {
            var account = new Account();
            account.Deposit(Money.ValueOf(54m));
            account.Withdraw(Money.ValueOf(42m));

            var total = Money.Zero;

            foreach (var transaction in account)
            {
                total += transaction;
            }

            Assert.That(total, Is.EqualTo(Money.ValueOf(12m)));
        }
    }
}
