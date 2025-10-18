using System;

namespace BankApp
{
    public class CurrentAccount
    {
        public string Number { get; set; }
        public double CreditLine { get; set; }
        public Person Owner { get; set; }
        public double Balance { get; private set; }  // lecture seule à l'extérieur

        public CurrentAccount(string number, Person owner, double creditLine)
        {
            Number = number;
            Owner = owner;
            CreditLine = creditLine;
            Balance = 0.0;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Le montant du dépôt doit être positif.");
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Le montant du retrait doit être positif.");

            if (Balance - amount < -CreditLine)
                throw new InvalidOperationException("Solde insuffisant ou dépassement de la ligne de crédit.");

            Balance -= amount;
        }

        public override string ToString()
        {
            return $"Compte {Number} | Solde : {Balance} € | Crédit autorisé : {CreditLine} € | Propriétaire : {Owner.FirstName} {Owner.LastName}";
        }
    }
}
