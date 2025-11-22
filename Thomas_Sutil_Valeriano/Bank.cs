
public class Bank
{
    public Dictionary<string, Account> Accounts { get; } = new Dictionary<string, Account>();
    public string Name { get; set; }

    // Constructor
    public Bank (string name)
    {
        Name = name; 
    }

    // Method
    public void NegativeBalanceAction(Account account)
    {
        Console.WriteLine($"Alert: Account {account.Number} has a negative balance of {account.Balance}.");
    }
    public void AddAccount(Account account)
    {
        // Check if the number account is empy or null
        if (string.IsNullOrEmpty(account.Number))
        {
            Console.WriteLine("Number Account is empty");
            return;
        }
        // Check if Number Account EXIST
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("This number account already exist");
            return;
        }
        Accounts.Add(account.Number, account);
        account.OnNegativeBalance += NegativeBalanceAction;
        Console.WriteLine($"Account {account.Number} added successfully !");
    }
    public void DeleteAccount(Account account)
    {
        if (string.IsNullOrEmpty(account.Number))
        {
            Console.WriteLine("Number Account is empty");
        }
        if (!Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("This number account not exist");
        }
        Accounts.Remove(account.Number);
        Console.WriteLine($"Account {account.Number} deleted successfully !");
    }

    public double BalanceGet(Account account)
    {
        Console.WriteLine($"Total Balance for the {account.Number} : {account.Balance}");
        return account.Balance;
    }

    public double GetTotalBalanceAll(Person person)
    {
        if (person == null)
        {
            Console.WriteLine("I can't see ghosts !");
            return 0;
        }

        double totalBalance = 0;
        foreach (var account in Accounts.Values)
        {
            if (account.Owner == person)
            {
                totalBalance += account.Balance;
            }
        }
        Console.WriteLine($"Total Balance for {person.FirstName} {person.LastName} : {totalBalance}");
        return totalBalance;
    }
}