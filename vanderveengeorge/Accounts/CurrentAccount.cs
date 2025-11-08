class CurrentAccount : Account
{
    public double CreditLine { get; private set; }
    public CurrentAccount(string number, Person owner) : base(number, owner) { }
    public CurrentAccount(string number, double balance, double creditLine, Person owner) : base(number, balance, owner)
    {
        CreditLine = creditLine;
    }
    public override void Withdraw(double amount)
    {
        if (amount > Balance + CreditLine)
        {
            Console.WriteLine("Solde insufisant");
        }
        else
        {
            base.Withdraw(amount);
        }
    }
    protected override double CalculateInterest()
    {
        return Balance * (Balance >= 0 ? 0.035 : 0.0975);
    }
}