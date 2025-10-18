class CurrentAccount(string number, double balance, double creditLine, Person owner) : Account(number, balance, owner)
{
    public double CreditLine { get; set; } = creditLine;
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
        return Balance * Balance >= 0 ? 0.035 : 0.0975;
    }
}