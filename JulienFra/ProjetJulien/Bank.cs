public class Bank
{
    public Dictionary<string, Account> Accounts { get; } = new();
    public string Name { get; set; }
    public void NegativeBalanceAction(Account account)
    {
        Console.WriteLine($"Le numéro de compte {account.Number} vient de passer en négatif");
    }
    public Bank(string name)
    {
        Name = name;
    }
    
    public void AddAccount(Account account)
    {
        if (!Accounts.ContainsKey(account.Number))
        {
            Accounts.Add(account.Number, account);
            account.NegativeBalanceEvent += NegativeBalanceAction;

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
            {
                total += acc.GetBalance();
            }
        }

        return total;
    }
}

