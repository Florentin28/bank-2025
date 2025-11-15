using Adrien_mertens;

/// <summary>
/// Point d'entrée de l'application de démonstration bancaire.
/// </summary>
 class Program
{
    /// <summary>
    /// Méthode principale qui illustre :
    /// - la création de personnes,
    /// - la création de comptes courants et d'épargne,
    /// - l'utilisation des interfaces IAccount / IBankAccount,
    /// - l'ajout des comptes dans la banque,
    /// - les dépôts, retraits et l'application des intérêts,
    /// - l'affichage des soldes des comptes.
    /// </summary>
    static void Main()
    {
        try
        {
        // Création d'une banque.
        var bank = new Bank();

        // Création de deux personnes.
        var adrien = new Person("Adrien", "Mertens", new DateTime(2000, 10, 23));
        var julie = new Person("Julie", "Durand", new DateTime(1998, 5, 12));

        // Création d'un compte courant pour Adrien.
        IBankAccount currentAccountAdrien = new CurrentAccount("BE123456789", adrien, creditLine: 1000);

        // Création d'un compte d'épargne pour Julie.
        IBankAccount savingAccountJulie = new SavingAccount("BE987654321", julie, DateTime.Now);

        // Ajout des comptes à la banque.
        bank.AddAccount(currentAccountAdrien);
        bank.AddAccount(savingAccountJulie);

        // Quelques opérations sur le compte courant d'Adrien.
        currentAccountAdrien.Deposit(2000);   // dépôt de 2000
        currentAccountAdrien.WithDraw(150);   // retrait de 150

        // Quelques opérations sur le compte d'épargne de Julie.
        savingAccountJulie.Deposit(5000);     // dépôt de 5000
        savingAccountJulie.WithDraw(500);     // retrait de 500

        // Affichage des soldes avant intérêts.
        Console.WriteLine("=== Soldes avant application des intérêts ===");
        bank.ShowAllCurrentAccounts();

        // Application des intérêts sur tous les comptes de la banque.
        Console.WriteLine();
        Console.WriteLine("Application des intérêts sur tous les comptes...");
        currentAccountAdrien.ApplyInterest();
        savingAccountJulie.ApplyInterest();

        // Affichage des soldes après intérêts.
        Console.WriteLine();
        Console.WriteLine("=== Soldes après application des intérêts ===");
        bank.ShowAllCurrentAccounts();

        // Exemple de consultation d'un solde via la banque.
        Console.WriteLine();
        Console.WriteLine(
            $"Solde du compte courant d'Adrien ({currentAccountAdrien.Number}) : " +
            $"{bank.ReturnSoldeCurrentAccount(currentAccountAdrien.Number)}");

        // Suppression d'un compte pour illustrer DeleteAccount.
        Console.WriteLine();
        Console.WriteLine("Suppression du compte d'épargne de Julie...");
        bank.DeleteAccount(savingAccountJulie.Number);

        Console.WriteLine();
        Console.WriteLine("=== Comptes restants dans la banque ===");
        bank.ShowAllCurrentAccounts();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}