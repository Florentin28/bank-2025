using System;

namespace BankApp
{
    public class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }

        public SavingsAccount(string number, Person owner)
            : base(number, owner)
        {
            DateLastWithdraw = DateTime.MinValue;
        }

        public override void Deposit(double amount) => base.Deposit(amount);

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du retrait doit être supérieur à zéro.");
            if (Balance - amount < 0)
                throw new InsufficientBalanceException("Solde insuffisant pour un compte épargne.");
            
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
