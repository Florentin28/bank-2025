class Bank(Dictionary<string, CurrentAccount> accounts, string name)
{
    public Dictionary<string, CurrentAccount> Accounts { get; private set; } = accounts;
    public string Name { get; set; } = name;
    public void AddAccount(CurrentAccount account)
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
            Console.WriteLine("Le compte n'existe pas !");
        }
    }

}