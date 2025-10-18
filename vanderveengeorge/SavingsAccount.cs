class SavingsAccount(string number, double balance, DateTime dateLastWithdraw, Person owner) : Account(number, balance, owner)
{
    public DateTime DateLastWithdraw { get; set; } = dateLastWithdraw;
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