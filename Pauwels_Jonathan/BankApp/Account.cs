using System;

namespace BankApp
{
    public abstract class Account : IBankAccount
    {
        public string Number { get; private set; }
        public Person Owner { get; private set; }
        public double Balance { get; protected set; }

        // Constructeur numéro + propriétaire
        public Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0.0;
        }

        // Constructeur numéro + propriétaire + solde initial
        public Account(string number, Person owner, double balance)
        {
            Number = number;
            Owner = owner;
            Balance = balance;
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);

        protected abstract double CalculInterets();

        public void ApplyInterest()
        {
            Balance += CalculInterets();
        }
    }
}
