var person = new Person("Alice", "Dupont", new DateTime(1990,1,1));
var current = new CurrentAccount("CA123", person, 100);
var savings = new SavingsAccount("SA123", person);

var bank = new Bank("Ma Banque");

// --- Test 1 : Ajouter des comptes ---
bank.AddAccount(current);
bank.AddAccount(savings);

// Test 2 : Essayer d'ajouter un compte avec le même numéro
var anotherCurrent = new CurrentAccount("CA123", person, 200);
bank.AddAccount(anotherCurrent); // doit afficher "Ce compte existe déjà !"

// --- Test 3 : Dépôts ---
current.Deposit(10);
savings.Deposit(1000);



try
{
    current.Withdraw(15);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Erreur : {ex.Message}");
}
catch (InsufficientBalanceException ex)
{
    Console.WriteLine($"Erreur : {ex.Message}");
}