public class CurrentAccount : Account //Not work if we don't implement the abstract Method from Account CalculateInterest().
{
    public double CreditLine { get; set; }

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