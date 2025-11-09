class SavingAccount: Account 
{
    DateTime DateLastWithdraw { get; set; }
    
    private double limitWithdraw { get;  set; }= 30;

    public SavingAccount(string number, Person owner) : base(number, owner)
    {
        this.Number = number;
        Owner = owner;
        Balance = base.Balance;
        DateLastWithdraw = DateTime.Now;

    }
    protected override double CalculInterets()
    {
        return this.Balance * 0.045;
        }
    public override void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        Balance += amount;
    }
    public override void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if ((DateTime.Now - DateLastWithdraw).TotalDays < limitWithdraw)
        {
            throw new InvalidOperationException($"Withdrawals can only be made once every {limitWithdraw} days.");
        }
        if (Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        Balance -= amount;
        DateLastWithdraw = DateTime.Now;
    }
}