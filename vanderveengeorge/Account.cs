abstract class Account(string number, double balance, Person owner)
{
    public string Number { get; set; } = number;
    public double Balance { get; private set; } = balance;
    public Person Owner { get; set; } = owner;
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