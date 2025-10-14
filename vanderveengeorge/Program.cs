
class Program
{
    static void Main(string[] args)
    {
        // Création d'une instance de la classe Person
        Person person1 = new Person("Alice", "Dupont", new DateTime(1990, 5, 21));
        CurrentAccount compte1 = new CurrentAccount("BE1234-4323-4323-3424", 4553, 423, person1);
        CurrentAccount compte2 = new CurrentAccount("BE1234-4323-4323-3425", 4553, 423, person1);
        Console.WriteLine(compte1.Balance);
        compte1.CreditLine -= 3;
        compte1.Withdraw(300000);
        Console.WriteLine(compte1.Balance);
        Bank bnp = new Bank(new Dictionary<string, CurrentAccount>(), "Ma Banque");
        bnp.AddAccount(compte1);
        bnp.AddAccount(compte2);
        bnp.DeleteAccount("BE1234-4323-4323-345");
        Console.WriteLine(bnp.Accounts.Count());
        bnp.GetAccountsInfos(person1);
    }
}