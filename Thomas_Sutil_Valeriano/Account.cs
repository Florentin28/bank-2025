public abstract class Account : IBankAccount
{
    public string Number { get; private set; }
    public double Balance { get; protected set; } // ReadOnly
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
    // Event
    public event Action<Account> BalanceNegativeEvent;
    // Method
    protected void NotifyNegativeBalance()
    {
        BalanceNegativeEvent?.Invoke(this);
    }
    public virtual void Withdraw(double amount) //This Method can be override with inheritance
    {
        double CurrentBalance = Balance;
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        }
        if (Balance - amount <= 0)
        {
            NotifyNegativeBalance();
            throw new InsufficientBalanceException("Insufficient balance for this withdrawal.");
        }
        Balance -= amount;
        Console.WriteLine($"Withdrawn: {amount}. Previous Balance: {CurrentBalance}, New Balance: {Balance}");
    }

    public virtual void Deposit(double amount) //This Method can be override with inheritance
    {
        double CurrentBalance = Balance;
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
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
