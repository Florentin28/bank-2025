public class CurrentAccount : Account
{
    public double CreditLine { get; set; }

    public CurrentAccount(string number, Person owner, double creditLine = 0)
        : base(number, owner)
    {
        CreditLine = creditLine;
    }
    public CurrentAccount(string number, Person owner, double balance, double creditLine = 0)
        : base(number, owner, balance)
    {
        CreditLine = creditLine;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < -CreditLine)
        {
            throw new InsufficientBalanceException("Fond insuffisant");
        }

        Balance -= amount;
        if (Balance < 0)
        {
            OnNegativeBalance();
        }
    }

    protected override double CalculInterets()
    {
        if (Balance >= 0)
            return Balance * 0.03;     
        else
            return Balance * 0.0975;
    }

    
}

