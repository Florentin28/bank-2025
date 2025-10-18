using System;

namespace BankApp
{
    public abstract class Account
    {
        public string Number { get; set; }
        public Person Owner { get; set; }
        public double Balance { get; protected set; } // lecture seule externe, modifiable seulement à l'intérieur

        public Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0.0;
        }

        // Méthodes abstraites à redéfinir dans les classes filles
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }
}
