using System;

namespace BankApp
{
    public class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }

        // Constructeur standard
        public SavingsAccount(string number, Person owner) 
            : base(number, owner)
        {
            DateLastWithdraw = DateTime.MinValue;
        }

        // Constructeur avec solde initial
        public SavingsAccount(string number, Person owner, double initialBalance) 
            : base(number, owner, initialBalance)
        {
            DateLastWithdraw = DateTime.MinValue;
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

            if (Balance - amount < 0)
                throw new InvalidOperationException("Solde insuffisant pour un compte épargne.");

            Balance -= amount;
            DateLastWithdraw = DateTime.Now;
        }

        protected override double CalculInterets()
        {
            return Balance * 0.045; // 4,5%
        }

        public override string ToString()
        {
            return $"Compte épargne {Number} | Solde : {Balance:F2} € | Dernier retrait : {DateLastWithdraw} | Propriétaire : {Owner.FirstName} {Owner.LastName}";
        }
    }
}
