using System;
using Abstraction;

namespace Models
{
    public abstract class Account: IAccount
    {
        public string Number { get; }
        public decimal Balance { get; protected set; }
        public Person Owner { get; }


        protected Account(string number, Person owner) 
            :this(number, owner, 0)
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
        }
        

        public virtual void Deposit(decimal amount)
        {
            try
            {
                 if (amount <= 0)
                {
                throw new ArgumentOutOfRangeException("Le montant du dépôt doit être positif.");
                
                }
                
            }
            catch (System.ArgumentOutOfRangeException)
            {
                
                throw;
            }
           
            Balance += amount;
            Console.WriteLine($"Dépôt de ${amount} effectué. Nouveau solde : ${Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            try 
            {
                 if (amount <= 0)
                {
                    throw new  InsufficientBalanceException("Le montant du retrait doit être positif.");
                }
            }
            catch (InsufficientBalanceException)
            {
                throw;
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