using System;
using System.Collections.Generic;

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
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public interface IAccount
{
    double Balance { get; }
    void Deposit(double amount);
    void Withdraw(double amount);
}

public interface IBankAccount : IAccount
{
    string Number { get; }
    Person Owner { get; }
    void ApplyInterest();
}

public abstract class Account : IBankAccount
{
    public string Number { get; private set; }            
    public double Balance { get; protected set; }      
    public Person Owner { get; private set; }             

    public Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
        Balance = 0;
    }

    public Account(string number, Person owner, double initialBalance)
    {
        Number = number;
        Owner = owner;
        Balance = initialBalance;
    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");
        Balance += amount;
    }

 
    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");
        if (Balance - amount < 0)
            throw new InsufficientBalanceException("Solde insuffisant pour ce retrait.");
        Balance -= amount;
    }

    public double GetBalance()
    {
        return Balance;
    }

    protected abstract double CalculInterets();

    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }

    public delegate void NegativeBalanceDelegate(Account account);

}

public class CurrentAccount : Account
{
    private double creditLine; 

    public double CreditLine
    {
        get { return creditLine; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit doit être >= 0.");
            creditLine = value;
        }
    }

    public CurrentAccount(string number, Person owner, double creditLine = 0)
        : base(number, owner)
    {
        CreditLine = creditLine;
    }

    public CurrentAccount(string number, Person owner, double initialBalance, double creditLine = 0)
        : base(number, owner, initialBalance)
    {
        CreditLine = creditLine;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");
        if (Balance - amount < -CreditLine)
            throw new InsufficientBalanceException("Solde insuffisant pour ce retrait (dépassement de la ligne de crédit).");
        Balance -= amount;
    }

    protected override double CalculInterets()
    {
        if (Balance >= 0)
            return Balance * 0.03;
        else
            return Balance * 0.0975;
    }
}

public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; private set; }

    public SavingsAccount(string number, Person owner)
        : base(number, owner)
    {
        DateLastWithdraw = DateTime.MinValue;
    }

    public SavingsAccount(string number, Person owner, double initialBalance)
        : base(number, owner, initialBalance)
    {
        DateLastWithdraw = DateTime.MinValue;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à zéro.");
        if (Balance - amount < 0)
            throw new InsufficientBalanceException("Solde insuffisant pour ce retrait.");
        Balance -= amount;
        DateLastWithdraw = DateTime.Now;
    }

    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}

public class Bank
{
    public Dictionary<string, Account> Accounts { get; } = new(); 
    public string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
    }

    public void AddAccount(Account account)
    {
        if (!Accounts.ContainsKey(account.Number))
        {
            Accounts.Add(account.Number, account);
        }
        else
        {
            Console.WriteLine("Ce compte existe déjà !");
        }
    }

    public void DeleteAccount(string number)
    {
        if (Accounts.ContainsKey(number))
        {
            Accounts.Remove(number);
        }
        else
        {
            Console.WriteLine("Aucun compte avec ce numéro trouvé.");
        }
    }

    public double GetTotalBalance(Person person)
    {
        double total = 0;
        foreach (var acc in Accounts.Values)
        {
            if (acc.Owner == person)
                total += acc.GetBalance();
        }
        return total;
    }
}

public class Program
{
    public static void Main()
    {
        var person = new Person("Alice", "Dupont", new DateTime(1990, 1, 1));

        // Création des comptes
        var current = new CurrentAccount("CA123", person, 100);
        var current2 = new CurrentAccount("CA124", person, 500, 200);
        var savings = new SavingsAccount("SA123", person, 1000);

        var bank = new Bank("Ma Banque");
        bank.AddAccount(current);
        bank.AddAccount(current2);
        bank.AddAccount(savings);

        try
        {
            current.Deposit(500);
            current2.Deposit(200);
            savings.Deposit(1000);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Erreur dépôt : " + ex.Message);
        }

        try
        {
            current.Withdraw(550);
            current2.Withdraw(800);
            savings.Withdraw(200);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Erreur montant : " + ex.Message);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Erreur solde : " + ex.Message);
        }

        Console.WriteLine("Épargne : " + savings.GetBalance());
        Console.WriteLine("Courant CA123 : " + current.GetBalance());
        Console.WriteLine("Courant CA124 : " + current2.GetBalance());
        Console.WriteLine("Total Alice : " + bank.GetTotalBalance(person));

        current.ApplyInterest();
        current2.ApplyInterest();
        savings.ApplyInterest();

        Console.WriteLine("Épargne après intérêts : " + savings.GetBalance());
        Console.WriteLine("Courant CA123 après intérêts : " + current.GetBalance());
        Console.WriteLine("Courant CA124 après intérêts : " + current2.GetBalance());
    }
    
}