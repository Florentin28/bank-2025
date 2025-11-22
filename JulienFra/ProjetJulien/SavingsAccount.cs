public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; private set; }

    public SavingsAccount(string number, Person owner)
        : base(number, owner)
    {
        DateLastWithdraw = DateTime.MinValue;
    }
    public SavingsAccount(string number, Person owner, double balance)
        : base(number, owner, balance)
    {
        DateLastWithdraw = DateTime.MinValue;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < 0)
        {
            throw new InsufficientBalanceException("Fond insuffisant");
        }
        base.Withdraw(amount);
        DateLastWithdraw = DateTime.Now;
    }

    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}

