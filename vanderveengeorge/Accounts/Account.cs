abstract class Account : IBankAccount
{
    public string Number { get; private set; }
    public double Balance { get; private set; }
    public Person Owner { get; private set; }
    public Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
    }
    public Account(string number, double balance, Person owner) : this(number, owner)
    {
        Balance = balance;
    }

    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }
    public virtual void Withdraw(double amount)
    {
        Balance -= amount;
    }
    protected abstract double CalculateInterest();
    public virtual void ApplyInterest()
    {
        Balance += CalculateInterest();
    }
}