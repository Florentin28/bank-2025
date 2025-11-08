class Bank(Dictionary<string, IBankAccount> accounts, string name)
{
    public Dictionary<string, IBankAccount> Accounts { get; } = accounts;
    public string Name { get; private set; } = name;
    public void AddAccount(IBankAccount account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("Le compte existe déjà !");
        }
        else
        {
            Accounts.Add(account.Number, account);
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
            Console.WriteLine("Suppression impossible, le compte n'existe pas !");
        }
    }
    public void GetBalance(string number)
    {
        if (Accounts.ContainsKey(number))
        {
            Console.WriteLine($"Compte : {number} | Solde : {Accounts[number].Balance}€");
        }
        else
        {
            Console.WriteLine($"Le compte {number} n'existe pas !");
        }
    }
    public void GetAccountsInfos(Person user)
    {
        double totalBalance = 0;
        bool hasAccount = false;
        foreach (Account account in Accounts.Values)
        {
            if (user == account.Owner)
            {
                totalBalance += account.Balance;
                hasAccount = true;
                GetBalance(account.Number);
            }
        }
        if (hasAccount)
        {
            Console.WriteLine($"Solde total de {user.FirstName} {user.LastName} : {totalBalance}€");
        }
        else
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} n'a pas de comptes");
        }
    }
}