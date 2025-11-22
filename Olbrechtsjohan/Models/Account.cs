using System;
using Abstraction;

namespace Models
{
    public abstract class Account : IAccount
    {
        
        public event Action<Account> NegativeBalanceEvent;

        protected void RaiseNegativeBalanceEvent()
        {
            NegativeBalanceEvent?.Invoke(this);
        }

        public string Number { get; }
        public decimal Balance { get; protected set; }
        public Person Owner { get; }

        protected Account(string number, Person owner)
            : this(number, owner, 0)
        {
        }

        protected Account(string number, Person owner, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Account number cannot be empty.", nameof(number));
            }

            Number = number;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Balance = initialBalance;

            if (Balance < 0)
            {
                RaiseNegativeBalanceEvent();
            }
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du dépôt doit être positif.");
            }
            Balance += amount;
            Console.WriteLine($"Dépôt de ${amount} effectué. Nouveau solde : ${Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du retrait doit être positif.");
            }
            if (Balance < amount)
            {
                throw new InvalidOperationException("Solde insuffisant pour effectuer le retrait.");
            }
            
            decimal oldBalance = Balance;
            Balance -= amount;
            Console.WriteLine($"Retrait de ${amount} effectué. Nouveau solde : ${Balance}");

            if (oldBalance >= 0 && Balance < 0)
            {
                RaiseNegativeBalanceEvent();
            }
        }

        protected abstract decimal CalculateInterest();

        public void ApplyInterest()
        {
            decimal interest = CalculateInterest();
            Balance += interest;
            Console.WriteLine($"Intérêts de ${interest:F2} appliqués. Nouveau solde : ${Balance:F2}");
        }
    }
}
