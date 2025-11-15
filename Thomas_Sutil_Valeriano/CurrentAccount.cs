public class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; } // ReadOnly
    public double CreditLine { get; set; }
    public Person Owner { get; set; }

    // Constructor
    public CurrentAccount (string number, double balance, double creditLine, Person owner)
    {
        Number = number;
        Balance = balance;
        CreditLine = creditLine;
        Owner = owner;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("This amount is less or equal than 0");
            return;
        }
        if (Balance - amount <= 0)
        {
            Console.WriteLine("Insufficient funds");
            return;
        }
        Balance -= amount;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("You can't deposit this amount, less than 0");
            return;
        }
        Balance += amount;
    }
}