using System.Globalization;


abstract class Account
{
    private string _number;
    private double _balance { set; get; }
    private Person _owner;
    public string Number { get => _number; }
    public double Balance { get => _balance; }
    public Person Owner { get => _owner; set => _owner = value; }
    public Account(string number, Person owner)
    {
        this._number = number;
        this._owner = owner;
        this._balance = 0;
    }
    public Account(string number, Person owner, double initialBalance) : this(number, owner)
    {
        this._balance = initialBalance;
    }
    abstract protected double CalculInterets();



    public virtual void Deposit(double amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            _balance += amount;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public virtual void Withdraw(double amount)
    {
        try
        {
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Insufficient funds.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}