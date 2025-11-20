public class CurrentAccount : Account //Not work if we don't implement the abstract Method from Account CalculateInterest().
{
    public double creditLine;
    public double CreditLine
    {
        get { return creditLine; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Credit line must be non-negative.");
            }
            creditLine = value;
        }
    }

    // Constructor
    public CurrentAccount(string number, double balance, double creditLine, Person owner) : base(number, balance, owner)
    {
        CreditLine = creditLine;
    }
    public CurrentAccount(string number, double creditLine, Person owner) : base(number, owner)
    {
        CreditLine = creditLine;
    }
    // Method
    public override void Withdraw(double amount) //Override the Method from Account
    {
        double CurrentBalance = Balance;
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        }
        if (Balance - amount < -CreditLine) // Allow overdraft up to credit line
        {
            NotifyNegativeBalance();
            throw new InsufficientBalanceException("Insufficient balance and credit line for this withdrawal.");
        }
        Balance -= amount;
        Console.WriteLine($"Withdrawn: {amount}. Previous Balance: {CurrentBalance}, New Balance: {Balance}");
    }
    protected override double CalculateInterest() //Override the abstract Method from Account
    {
        if (Balance < 0)
        {
            double interestRate = 0.0975; // 9.75% interest rate for negative balance
            return Balance * interestRate;
        }
        else
        {
            double interestRate = 0.03; // 3% interest rate for positive balance
            return Balance * interestRate;
        }
    }
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo(); //Call the base method to display common account info
        Console.WriteLine($"Credit Line: {CreditLine}");
    }

}