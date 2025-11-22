using arnaudkabimbingoy;
using System;
using System.Security.Principal;

internal class Program
{
    public static void Main()
    {
        Bank bank1 = new Bank("ING BELGIUM");
        Person person1 = new Person("Ester", "Exposito", new DateTime(2000, 01, 26));
        Person person2 = new Person("Marion", "Cotillard", new DateTime(1975, 09, 30));
        Person person3 = new Person("Georgina", "Rodriguez", new DateTime(1994, 01, 27));
        //Person person4 = new Person("Ester", "Exposito", new DateTime(2000, 01, 26));

        IBankAccount currentAccount1 = new CurrentAccount("BE" + new Random().NextInt64(99999999999999).ToString(), 500, 100, person1);
        IBankAccount currentAccount2 = new CurrentAccount("BE" + new Random().NextInt64(99999999999999).ToString(), 1000, 300, person2);
        Account currentAccount3 = new CurrentAccount("BE" + new Random().NextInt64(99999999999999).ToString(), 5000, 1200, person3);
        Account currentAccount4 = new CurrentAccount("BE" + new Random().NextInt64(99999999999999).ToString(), 31, 10, person1);
        Account savingAccount1 = new SavingsAccount("BE" + new Random().NextInt64(99999999999999).ToString(), 8000, person1);

        bank1.AddAccount(currentAccount1);
        bank1.AddAccount(currentAccount2);
        bank1.AddAccount(currentAccount3);
        bank1.AddAccount(currentAccount4);
        bank1.AddAccount(savingAccount1);

        Console.WriteLine($"(avant transfert vers le compte d'epargne)\nSolde du compte courant : {bank1.GetBalance(currentAccount1.Number)}");
        currentAccount1.Withdraw(100);
        Console.WriteLine($"(apres transfert vers le compte d'epargne)\nSolde du compte courant : {bank1.GetBalance(currentAccount1.Number)}");
        savingAccount1.Deposit(100);
        Console.WriteLine($"Voici le total de tous les comtpes associé à {person1.Firstname} {person1.Lastname} {bank1.GetBalanceAllAccount("Ester Exposito")}");

        try
        {
            currentAccount1.Withdraw(5000);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(currentAccount1.ApplyInterest());
        Console.WriteLine(savingAccount1.ApplyInterest());
    }
}