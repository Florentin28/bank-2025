class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}

class CurrentAccount
{
    internal string Number { get; set; }
    public double Balance { get; private set; }
    private double CreditLine { get; set; }
    private Person Owner { get; set; }

    public CurrentAccount(string number,Person owner, double creditLine = 0 )
    {
        Number = number;
        Owner = owner;
        CreditLine = creditLine;
        Balance = 0;
    }

    public void WithDraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Erreur : Le montant doit être positif");
            return;
        }

        if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Erreur : Le solde est insuffisant");
            return;
        }
        
        Balance -= amount;
        Console.WriteLine($"Retrait de {amount} effectué avec succès.");
    }
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Erreur : le montant doit être positif");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Dépôt de {amount} effectué avec succès.");
    }
}

class Bank
{
    private Dictionary<string, CurrentAccount> _accounts = new Dictionary<string, CurrentAccount>();
    private string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
    }
    
    public void AddAccount(CurrentAccount account)
    {
        if (_accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("Erreur : Un compte avec ce numéro existe déjà.");
            return;
        }
        
        _accounts.Add(account.Number, account);
        Console.WriteLine($"Compte {account.Number} ajouté avec succès.");
    }

    public void DeleteAccount(string number)
    {
        if (!_accounts.ContainsKey(number))
        {
            Console.WriteLine("Erreur : Aucun compte trouvé avec ce numéro.");
            return;
        }
        _accounts.Remove(number);
        Console.WriteLine($"Compte {number} supprimé avec succès.");
    }

    public double ReturnSoldeCurrentAccount(string number)
    {
        if (!_accounts.TryGetValue(number, out var account))
        {
            Console.WriteLine("Erreur : Aucun compte trouvé avec ce numéro.");
            return 0;
        }

        return account.Balance;
    }
    
    public void ShowAllCurrentAccounts()
    {
        Console.WriteLine("Liste des comptes :");
        foreach (var account in _accounts.Values)
        {
            Console.WriteLine(
                $"N°: {account.Number}, " +
                $"Solde: {account.Balance}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Exemple d'utilisation
        var bank = new Bank("Ma Banque");
        var person = new Person("Adrien", "Mertens", new DateTime(2000, 10, 23));
        var account = new CurrentAccount("BE123456789", person, 1000);
        
        bank.AddAccount(account);
        account.Deposit(2000);
        account.WithDraw(100);
        Console.WriteLine($"le solde du compte {account.Number} est de {bank.ReturnSoldeCurrentAccount(account.Number)}");
        bank.ShowAllCurrentAccounts();
        
        bank.DeleteAccount(account.Number);
    }
    
}