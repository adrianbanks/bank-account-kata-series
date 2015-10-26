using System;
using BankingKata;

namespace BankingConsole
{
    public class AccountBuilder
    {
        private Money _startingBalance = new Money(0);
        private Money _arrangedOverdraftLimit;
        private Money _unarrangedOverdraftLimit;
        private Money _overdraftCharge;

        public AccountBuilder WithStartingBalance(Money startingBalance)
        {
            _startingBalance = startingBalance;
            return this;
        }

        public AccountBuilder WithOverdraftChargeOf(Money overdraftCharge)
        {
            _overdraftCharge = overdraftCharge;
            return this;
        }

        public AccountBuilder WithArrangedOverdraftLimitOf(Money overdraftLimit)
        {
            _arrangedOverdraftLimit = new Money(0) - overdraftLimit;
            return this;
        }

        public AccountBuilder WithUnarrangedOverdraftLimitOf(Money overdraftLimit)
        {
            _unarrangedOverdraftLimit = new Money(0) - overdraftLimit;
            return this;
        }

        public IAccount Build()
        {
            var baseAccount = new Account();
            var arrangedOverdraft = new ArrangedOverdraft(_arrangedOverdraftLimit, _overdraftCharge);
            var accountWithArrangedOverdraft = new AccountWithOverdraft(baseAccount, arrangedOverdraft);
            var unarrangedOverdraft = new UnarrangedOverdraft(_unarrangedOverdraftLimit);
            var accountWithUnarrangedOverdraft = new AccountWithOverdraft(accountWithArrangedOverdraft, unarrangedOverdraft);

            baseAccount.Deposit(DateTime.Now, _startingBalance);
            return accountWithUnarrangedOverdraft;
        }
    }
}
