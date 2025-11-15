class CurrentAccount: Account
{   
    public double CreditLine { get; private set; }
    public CurrentAccount(string number, Person owner) : base(number, owner)
    {

        Owner = owner;
        try
        {

            if (this.CreditLine < 0)
            {
                throw new ArgumentException("Credit line must be non-negative.");
            }
        }

        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }   
        CreditLine = this.CreditLine;
        
        
    }
    public CurrentAccount(string number, Person owner, double creditLine = 0, double balance = 0) : this(number, owner)
    {
        
        Owner = owner;
        CreditLine = creditLine;
    }
    
    public override void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        base.Deposit(amount);
    }
    protected override double CalculInterets()
    {
           if (this.Balance < 0)
            {
                return this.Balance * 0.03;
            }
            else
            {
                return this.Balance * 0.0975;
            }
        }
       
    
    public override void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if (Balance + CreditLine < amount)
        {
            throw new InvalidOperationException("Insufficient funds including credit line.");
        }
        base.Withdraw(amount);
    }

   
}