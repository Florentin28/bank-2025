using System;

namespace BankApp
{
    public abstract class Account
    {
        public string Number { get; private set; }
        public Person Owner { get; private set; }
        public double Balance { get; protected set; }

        public Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0.0;
        }

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du dépôt doit être supérieur à zéro.");
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du retrait doit être supérieur à zéro.");
            if (Balance < amount)
                throw new InsufficientBalanceException("Solde insuffisant pour effectuer le retrait.");
            Balance -= amount;
        }

        protected abstract double CalculInterets();

        public void ApplyInterest()
        {
            Balance += CalculInterets();
        }
    }
}
