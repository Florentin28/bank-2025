class CurrentAccount : Account
{
    private double _creditLine;
    public double CreditLine
    {
        get => _creditLine;
        private set
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, 0);
            _creditLine = value;
        }
    }
    public CurrentAccount(string number, Person owner) : base(number, owner) { }
    public CurrentAccount(string number, double balance, double creditLine, Person owner) : base(number, balance, owner)
    {
        CreditLine = creditLine;
    }
    public override void Withdraw(double amount)
    {
        if (amount > (Balance + CreditLine))
        {
            Console.WriteLine("Solde insufisante");
        }
        else
        {
            base.Withdraw(amount);
            if (Balance < 0)
            {
                OnNegativeBalance();
            }

        }
    }
    protected override double CalculateInterest()
    {
        return Balance * (Balance >= 0 ? 0.03 : 0.0975);
    }
}