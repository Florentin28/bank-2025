using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    public class Bank
    {
        public string Name { get; set; }
        public Dictionary<string, Account> Accounts { get; private set; }

        public Bank(string name)
        {
            Name = name;
            Accounts = new Dictionary<string, Account>();
        }

        public void AddAccount(Account account)
        {
            if (Accounts.ContainsKey(account.Number))
                throw new ArgumentException("Un compte avec ce numéro existe déjà.");
            Accounts.Add(account.Number, account);
        }

        public void DeleteAccount(string number)
        {
            if (!Accounts.ContainsKey(number))
                throw new KeyNotFoundException("Aucun compte trouvé avec ce numéro.");
            Accounts.Remove(number);
        }

        public double GetBalance(string number)
        {
            if (!Accounts.ContainsKey(number))
                throw new KeyNotFoundException("Aucun compte trouvé avec ce numéro.");
            return Accounts[number].Balance;
        }

        public double GetTotalBalanceByPerson(Person person)
        {
            return Accounts.Values
                .Where(a => a.Owner == person)
                .Sum(a => a.Balance);
        }
    }
}
