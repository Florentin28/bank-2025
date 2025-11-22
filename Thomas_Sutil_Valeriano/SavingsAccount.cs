public class SavingsAccount : Account //Not work if we don't implement the abstract Method from Account CalculateInterest().
{
    public DateTime DateLastWithdraw { get;  private set; }

    // Construct
    public SavingsAccount(string number, double balance, Person owner) : base(number, balance, owner)
    {
    }
    public SavingsAccount(string number, Person owner) : base(number, owner)
    {
    }

    // Method

    public override void Withdraw(double amount) //Main Method from Account is override for this Class -> use for DateLastWithDraw
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
        DateLastWithdraw = DateTime.Now;
        Balance -= amount;
    }
    protected override double CalculateInterest() //Override the abstract Method from Account
    {
        double interestRate = 0.045; // 4.5% interest rate
        return Balance * interestRate;
    }
}
