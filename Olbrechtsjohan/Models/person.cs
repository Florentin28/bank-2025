using System;
using System.Collections.Generic;
namespace Models
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public int CalculateAge()
        {
            int age = DateTime.Today.Year - BirthDate.Year;
            if (BirthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Prénom: {FirstName}, Nom: {LastName}, Âge: {CalculateAge()}");
        }
    }

    public class Client : Person
    {
        public Client(string firstName, string lastName, DateTime birthDate)
            : base(firstName, lastName, birthDate)
        {
        }
    }

    public class Banque
    {
        public string Name { get; set; }
        public List<CurrentAccount> Accounts { get; private set; }

        public Banque(string name)
        {
            Name = name;
            Accounts = new List<CurrentAccount>();
        }

        public void AddAccount(CurrentAccount newAccount)
        {
            if (newAccount != null)
            {
                Accounts.Add(newAccount);
                newAccount.NegativeBalanceEvent += NegativeBalanceAction;
                Console.WriteLine($"Le compte {newAccount.Number} pour {newAccount.Owner.FirstName} {newAccount.Owner.LastName} a été ajouté.");
            }
        }
        public void NegativeBalanceAction(Account account)
        {
            Console.WriteLine($"Le numéro de compte {account.Number} vient de passer en négatif");
        }

        public void DisplayAccountsList()
        {
            Console.WriteLine($"\n--- Comptes de la banque {Name} ---");
            foreach (var account in Accounts)
            {
                Console.WriteLine($"Compte : {account.Number}, Propriétaire : {account.Owner.FirstName} {account.Owner.LastName}, Solde : ${account.Balance}");
            }
        }
    }
}