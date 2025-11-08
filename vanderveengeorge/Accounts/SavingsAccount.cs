class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; private set; }
    public SavingsAccount(string number, Person owner) : base(number, owner) { }
    public SavingsAccount(string number, double balance, DateTime dateLastWithdraw, Person owner) : base(number, balance, owner)
    {
        DateLastWithdraw = dateLastWithdraw;
    }

    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
        DateLastWithdraw = DateTime.Now;
    }
    protected override double CalculateInterest()
    {
        return Balance * 0.045;
    }
}