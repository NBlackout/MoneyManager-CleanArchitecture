using System;

namespace MoneyManager.Domain
{
    public class Account
    {
        public string Label { get; }
        public decimal Balance { get; }

        public Account(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentException("Account label should not be empty");

            Label = label;
        }
    }
}
