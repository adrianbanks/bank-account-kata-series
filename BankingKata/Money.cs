﻿using System;

namespace BankingKata
{
    public class Money : IEquatable<Money>
    {
        private readonly decimal amount;

        public Money(decimal amount)
        {
            this.amount = amount;
        }

        public bool Equals(Money other)
        {
            return amount == other.amount;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public static bool operator ==(Money x, Money y)
        {
            return x.amount == y.amount;
        }

        public static bool operator !=(Money x, Money y)
        {
            return !(x == y);
        }

        public static Money operator +(Money x, Money y)
        {
            return new Money(x.amount + y.amount);
        }

        public static Money operator -(Money x, Money y)
        {
            return new Money(x.amount - y.amount);
        }
    }
}
