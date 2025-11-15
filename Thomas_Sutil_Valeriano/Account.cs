public abstract class Account
{
    public string Number { get; set; }
    public double Balance { get; private set; } // ReadOnly
    public Person Owner { get; set; }

    public Account(string number, double balance, Person owner)
    {
        Number = number;
        Balance = balance;
        Owner = owner;
    }
}
