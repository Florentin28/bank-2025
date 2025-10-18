using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Akasha Bank");

            // Création de personnes
            Person john = new Person("John", "Pauwels", new DateTime(1998, 5, 14));
            Person alice = new Person("Alice", "Dupont", new DateTime(2001, 11, 2));

            // Création de comptes
            CurrentAccount acc1 = new CurrentAccount("ACC001", john, 500);
            CurrentAccount acc2 = new CurrentAccount("ACC002", alice, 300);
            CurrentAccount acc3 = new CurrentAccount("ACC003", john, 1000);

            // Ajout à la banque
            bank.AddAccount(acc1);
            bank.AddAccount(acc2);
            bank.AddAccount(acc3);

            // Opérations
            acc1.Deposit(200);
            acc1.Withdraw(50);
            acc3.Deposit(700);

            // Affichage
            Console.WriteLine(acc1);
            Console.WriteLine(acc3);

            Console.WriteLine($"\nSolde total de {john.FirstName} : {bank.GetTotalBalanceByPerson(john)} €");
        }
    }
}
