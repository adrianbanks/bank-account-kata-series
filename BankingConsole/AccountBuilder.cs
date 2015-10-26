using System;
using BankingKata;

namespace BankingConsole
{
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
