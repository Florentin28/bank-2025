using System;

namespace Models
{
    public class SavingAccount : Account
    {
        public DateTime? DateLastWithdraw { get; private set; }

        public SavingAccount(string number, Person owner)
            : base(number, owner)
        {
        }

        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount); 

            if (amount > Balance)
            {
                Console.WriteLine("Solde insuffisant.");
                return;
            }

            Balance -= amount;
            DateLastWithdraw = DateTime.Now;
            Console.WriteLine($"Retrait de ${amount} effectué. Nouveau solde : ${Balance}");
        }

        protected override decimal CalculateInterest()
        {
            return Balance * 0.045m;
        }
    }
}
