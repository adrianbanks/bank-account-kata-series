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
            Account account = new Account(new Money(0m));

            Assert.That(account == new Money(0m), Is.True);
        }
    }
}
