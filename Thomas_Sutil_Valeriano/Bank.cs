
public class Bank
{
    public Dictionary<string, CurrentAccount> Accounts { get; } = new Dictionary<string, CurrentAccount>();
    public required string Name { get; set; }

    // Method for Add New Account
    public void AddAccount(CurrentAccount account)
    {
        // Check if the number account is empy or null
        if (string.IsNullOrEmpty(account.Number))
        {
            Console.WriteLine("Number Account is empty");
        }
        // Check if Number Account EXIST
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("This number account already exist");
        }
        Accounts.Add(account.Number, account);
    }
    // Method for Delete Account
    public void DeleteAccount(string accountNumber)
    {
        if (string.IsNullOrEmpty(accountNumber))
        {
            Console.WriteLine("Number Account is empty");
        }
        if (Accounts.ContainsKey(accountNumber))
        {
            Console.WriteLine("This number account already exist");
        }
        Accounts.Remove(accountNumber);
    }
    // Method for return the Balance Account

    public double BalanceGet(CurrentAccount account)
    {
        return account.Balance;
    }

}