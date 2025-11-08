using System;

namespace BankApp
{
    public class CurrentAccount : Account
    {
        public double CreditLine { get; private set; }

        // Constructeur standard : numéro + propriétaire + crédit
        public CurrentAccount(string number, Person owner, double creditLine) 
            : base(number, owner)
        {
            CreditLine = creditLine;
        }

        // Constructeur avec solde initial
        public CurrentAccount(string number, Person owner, double creditLine, double initialBalance) 
            : base(number, owner, initialBalance)
        {
            CreditLine = creditLine;
        }

        public override void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Le montant du dépôt doit être positif.");
            Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Le montant du retrait doit être positif.");

            if (Balance - amount < -CreditLine)
                throw new InvalidOperationException("Solde insuffisant ou dépassement de la ligne de crédit.");

            Balance -= amount;
        }

        protected override double CalculInterets()
        {
            if (Balance > 0)
                return Balance * 0.03;     // 3% si solde positif
            else
                return Balance * 0.0975;  // 9,75% si solde négatif
        }

        public override string ToString()
        {
            return $"Compte courant {Number} | Solde : {Balance:F2} € | Crédit autorisé : {CreditLine} € | Propriétaire : {Owner.FirstName} {Owner.LastName}";
        }
    }
}
