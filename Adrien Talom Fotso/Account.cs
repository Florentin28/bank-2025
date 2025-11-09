using System.Globalization;

abstract class Account
{
    public string Number { get; set; }
    public double Balance { get; protected set; }
    public Person Owner { get; set; }
    public Account(string number, Person owner)
    {
        this.Number = number;
        this.Owner = owner;
        this.Balance = 0;
    }
    abstract protected double CalculInterets();
    
        
    
    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        Balance += amount;
    }
    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
    }

   
}