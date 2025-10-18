using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Akasha Bank");

            Console.WriteLine("Bienvenue dans la banque Akasha !");
            
            while (true)
            {
                Console.WriteLine("\nMenu :");
                Console.WriteLine("1 - Créer un compte courant");
                Console.WriteLine("2 - Créer un compte épargne");
                Console.WriteLine("3 - Déposer de l'argent");
                Console.WriteLine("4 - Retirer de l'argent");
                Console.WriteLine("5 - Afficher solde d'un compte");
                Console.WriteLine("6 - Afficher solde total d'une personne");
                Console.WriteLine("7 - Quitter");

                Console.Write("Choix : ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            CreateCurrentAccount(bank);
                            break;

                        case "2":
                            CreateSavingsAccount(bank);
                            break;

                        case "3":
                            Deposit(bank);
                            break;

                        case "4":
                            Withdraw(bank);
                            break;

                        case "5":
                            ShowAccountBalance(bank);
                            break;

                        case "6":
                            ShowTotalBalance(bank);
                            break;

                        case "7":
                            Console.WriteLine("Au revoir !");
                            return;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
            }
        }

        // ===== Fonctions auxiliaires =====

        static void CreateCurrentAccount(Bank bank)
        {
            Console.Write("Prénom : ");
            string firstName = Console.ReadLine();
            Console.Write("Nom : ");
            string lastName = Console.ReadLine();
            Console.Write("Date de naissance (yyyy-mm-dd) : ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Person owner = new Person(firstName, lastName, birthDate);

            Console.Write("Numéro de compte : ");
            string number = Console.ReadLine();
            Console.Write("Ligne de crédit : ");
            double credit = double.Parse(Console.ReadLine());

            CurrentAccount account = new CurrentAccount(number, owner, credit);
            bank.AddAccount(account);
            Console.WriteLine("Compte courant créé avec succès !");
        }

        static void CreateSavingsAccount(Bank bank)
        {
            Console.Write("Prénom : ");
            string firstName = Console.ReadLine();
            Console.Write("Nom : ");
            string lastName = Console.ReadLine();
            Console.Write("Date de naissance (yyyy-mm-dd) : ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Person owner = new Person(firstName, lastName, birthDate);

            Console.Write("Numéro de compte : ");
            string number = Console.ReadLine();

            SavingsAccount account = new SavingsAccount(number, owner);
            bank.AddAccount(account);
            Console.WriteLine("Compte épargne créé avec succès !");
        }

        static void Deposit(Bank bank)
        {
            Console.Write("Numéro de compte : ");
            string num = Console.ReadLine();
            Console.Write("Montant à déposer : ");
            double amount = double.Parse(Console.ReadLine());
            bank.Accounts[num].Deposit(amount);
            Console.WriteLine("Dépôt effectué !");
        }

        static void Withdraw(Bank bank)
        {
            Console.Write("Numéro de compte : ");
            string num = Console.ReadLine();
            Console.Write("Montant à retirer : ");
            double amount = double.Parse(Console.ReadLine());
            bank.Accounts[num].Withdraw(amount);
            Console.WriteLine("Retrait effectué !");
        }

        static void ShowAccountBalance(Bank bank)
        {
            Console.Write("Numéro de compte : ");
            string num = Console.ReadLine();
            Console.WriteLine($"Solde du compte {num} : {bank.GetBalance(num)} €");
        }

        static void ShowTotalBalance(Bank bank)
        {
            Console.Write("Prénom : ");
            string firstName = Console.ReadLine();
            Console.Write("Nom : ");
            string lastName = Console.ReadLine();
            Person person = null;

            foreach (var acc in bank.Accounts.Values)
                if (acc.Owner.FirstName == firstName && acc.Owner.LastName == lastName)
                    person = acc.Owner;

            if (person == null)
            {
                Console.WriteLine("Aucune personne trouvée !");
                return;
            }

            double total = bank.GetTotalBalanceByPerson(person);
            Console.WriteLine($"Solde total de {firstName} {lastName} : {total} €");
        }
    }
}

