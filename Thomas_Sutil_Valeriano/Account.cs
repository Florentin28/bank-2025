public abstract class Account : IBankAccount
{
    public string Number { get; private set; }
    public double Balance { get; private set; } // ReadOnly
    public Person Owner { get; private set; }
    
    // 2 Construct
    public Account(string number, double balance, Person owner) // UseFull for DB -> When we load all Data
    {
        Number = number;
        Balance = balance;
        Owner = owner;
    }
    public Account(string number, Person owner) : this(number, 0, owner) // UseFull for Create New Account
    {
        Number = number;
        Owner = owner;
    }

    // Method
    public virtual void Withdraw(double amount) //This Method can be override with inheritance
    {
        double CurrentBalance = Balance;
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
        Console.WriteLine($"Withdrawn: {amount}. Previous Balance: {CurrentBalance}, New Balance: {Balance}");
    }

    public virtual void Deposit(double amount) //This Method can be override with inheritance
    {
        double CurrentBalance = Balance;
        if (amount <= 0)
        {
            Console.WriteLine("You can't deposit this amount, less than 0");
            return;
        }
        Balance += amount;
        Console.WriteLine($"Deposited: {amount}. Previous Balance: {CurrentBalance}, New Balance: {Balance}");
    }

    protected abstract double CalculateInterest(); // Method abstract protected
    public void ApplyInterest()
    {
        double CurrentBalance = Balance;
        double interest = CalculateInterest();
        Balance += interest;
        Console.WriteLine($"Interest Applied: {interest}. Previous Balance: {CurrentBalance}, New Balance: {Balance}");
    }
    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine($"Account Number: {Number}, Balance: {Balance}, Owner: {Owner.FirstName} {Owner.LastName}");
    }
}
