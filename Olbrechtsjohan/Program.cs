using static System.Console;
using System;
using Models;

public class Program
{
    public static void Main()
    {
        Banque myBank = new Banque("First Bank");
        WriteLine($"Bienvenue à {myBank.Name} !");

        Client client1 = new Client("Maximus", "Durian", new DateTime(1985, 5, 10));
        Client client2 = new Client("Aliigna", "Herie", new DateTime(1992, 11, 20));

        CurrentAccount currentAcc1 = new CurrentAccount("BE001", client1);
//        SavingAccount savingAcc1 = new SavingAccount("BE002", client1);
        CurrentAccount currentAcc2 = new CurrentAccount("BE003", client2);
        currentAcc1.LineOfCredit = 500;

        myBank.AddAccount(currentAcc1);
//      myBank.AddAccount(savingAcc1);
        myBank.AddAccount(currentAcc2);

        currentAcc1.Deposit(250);
        currentAcc1.Withdraw(1500);

        WriteLine("\n--- Application des intérêts ---");
        currentAcc1.ApplyInterest();
//       savingAcc1.ApplyInterest();
        currentAcc2.ApplyInterest();

        myBank.DisplayAccountsList();
    }
public class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException(string message) : base(message)
            {
                Console.WriteLine("Le montant ne peut etre retiré");
            }
        }
}
