public abstract class Account : IBankAccount
{
    public event Action<Account> NegativeBalanceEvent;
    
    protected void OnNegativeBalance()
    {
        NegativeBalanceEvent?.Invoke(this);
    }
    public string Number { get; private set; }
    public double Balance { get; set; }
    public Person Owner { get; private set; }

    public Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
    }

    public Account(string number, Person owner, double balance)
    {
        Number = number;
        Owner = owner;
        Balance = balance;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à 0.");
        }

        if (Balance - amount < 0)
        {
            throw new InsufficientBalanceException("Fond insuffisant");
        }

        Balance -= amount;
    }

    public virtual void Deposit(double amount)
    {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être supérieur à 0.");
            }

            Balance += amount;
    }

    public double GetBalance()
    {
        return Balance;
    }
    
    protected abstract double CalculInterets();
    
    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}

[Serializable]
internal class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException()
    {
        Console.WriteLine("Fond insuffisant");
    }

    public InsufficientBalanceException(string? message) : base(message)
    {
    }

    public InsufficientBalanceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}