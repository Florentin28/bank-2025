
class Program
{
    static void Main(string[] args)
    {
        // TESTS
        Person person1 = new Person("Alice", "Dupont", new DateTime(1990, 5, 21));
        Person person2 = new Person("Pierre", "Tique", new DateTime(1990, 5, 21));
        Account compte1 = new CurrentAccount("BE1234-4323-4323-3424", 4553, 423, person1);
        Account compte2 = new CurrentAccount("BE1234-4323-4323-3425", 4553, 423, person1);
        Account compte3 = new CurrentAccount("BE1234-4323-4323-3425", person1);
        Console.WriteLine(compte1.Balance);
        compte1.Withdraw(300000);
        Console.WriteLine(compte1.Balance);
        Bank bnp = new Bank(new Dictionary<string, IBankAccount>(), "Ma Banque");
        bnp.AddAccount(compte1);
        bnp.AddAccount(compte2);
        bnp.DeleteAccount("BE1234-4323-4323-345");
        Console.WriteLine(bnp.Accounts.Count());
        bnp.GetAccountsInfos(person1);
        bnp.GetAccountsInfos(person2);
        Console.WriteLine(compte1.Balance);
        compte1.ApplyInterest();
        Console.WriteLine(compte1.Balance);
    }
}