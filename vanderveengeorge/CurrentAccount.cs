class CurrentAccount(string number, double balance, double creditLine, Person owner)
{
    public string Number { get; set; } = number;
    public double Balance { get; private set; } = balance;
    public double CreditLine { get; set; } = creditLine;
    public Person Owner { get; set; } = owner;

    public void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Solde insufisant");
        }
        else
        {
            Balance -= amount;
        }
    }
    public void Deposit(double amount)
    {
        Balance += amount;
    }
    public void GetBalance()
    {
        Console.WriteLine($"Compte : {Number} | Solde : {Balance}€");
    }
}