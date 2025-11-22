using System;

namespace BankApp
{
    public class CurrentAccount : Account
    {
        private double creditLine;

        public double CreditLine
        {
            get => creditLine;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit doit être >= 0.");
                creditLine = value;
            }
        }

        public CurrentAccount(string number, Person owner, double creditLine)
            : base(number, owner)
        {
            CreditLine = creditLine;
        }

        public CurrentAccount(string number, Person owner, double creditLine, double initialBalance)
            : base(number, owner)
        {
            CreditLine = creditLine;
            Balance = initialBalance;
        }

        public override void Deposit(double amount) => base.Deposit(amount);

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du retrait doit être > 0.");
            if (Balance - amount < -CreditLine)
                throw new InsufficientBalanceException("Solde insuffisant ou dépassement de la ligne de crédit.");
            Balance -= amount;
        }

        protected override double CalculInterets()
        {
            return Balance > 0 ? Balance * 0.03 : Balance * 0.0975;
        }

        public override string ToString()
        {
            return $"Compte courant {Number} | Solde : {Balance:F2} € | Crédit autorisé : {CreditLine} € | Propriétaire : {Owner.FirstName} {Owner.LastName}";
        }
    }
}

