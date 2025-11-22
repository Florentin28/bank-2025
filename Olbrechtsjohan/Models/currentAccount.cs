using System;
using Models;
using Abstraction;

namespace Models
{
   public class CurrentAccount : Account
{
    private decimal _lineOfCredit;
    
    public decimal LineOfCredit 
    { 
        get => _lineOfCredit;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(LineOfCredit), 
                    "La ligne de crédit doit être supérieure ou égale à 0.");
            }
            _lineOfCredit = value;
        }
    }
        public CurrentAccount(string number, Person owner) 
        : base(number, owner)
    {
        LineOfCredit = 0;
    }

    


        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du retrait doit être positif.");
            }

            if (Balance - amount < -LineOfCredit)
            {
                throw new InvalidOperationException("Le montant du retrait dépasse le solde et la ligne de crédit autorisée.");
            }
            
            decimal oldBalance = Balance;
            Balance -= amount;
            Console.WriteLine($"Retrait de ${amount} effectué. Nouveau solde : ${Balance}");

            if (oldBalance >= 0 && Balance < 0)
            {
                RaiseNegativeBalanceEvent();
            }
        }

        protected override decimal CalculateInterest()
        {
            if (Balance >= 0)
            {
                return Balance * 0.03m;
            }
            return Balance * 0.0975m;
        }
    }
}