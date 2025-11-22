using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudkabimbingoy
{
    internal sealed class Bank
    {
        //Au besoin revenir au dernier commit
        public Dictionary<string, IBankAccount> Accounts { get; } = []; //mon implementation de base ne permet pas d'utiliser les interfaces sans poser probleme
        public string Name { get; set; }
        public Person Owner { get; }
        public string Number { get; }
        public double Balance {  get; set; }

        public Bank(string name)
        {
            Name = name;
        }


        public void AddAccount(IBankAccount account)
        {
            if (!Accounts.ContainsKey(account.Number))
                Accounts.Add(account.Number, account);
            else
                Console.WriteLine("Ce numero de compte existe deja...");
        }

        public void DeleteAccount(string number)
        {
            Accounts.Remove(number);
        }

        public double GetBalance(string number)
        {
            return Accounts[number].Balance;
        }

        public double GetBalanceAllAccount(string owner)
        {
            double somme = 0;
            foreach (var item in Accounts)
            {
                if (item.Value.Owner.Firstname + " " + item.Value.Owner.Lastname == owner)
                {
                    somme += item.Value.Balance;
                }
            }
            return somme;
        }


        public void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public double ApplyInterest()
        {
            throw new NotImplementedException();
        }
    }
}
