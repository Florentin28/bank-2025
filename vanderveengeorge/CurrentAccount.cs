class CurrentAccount(string number, double balance, double creditLine, Person owner)
{
    public string Number { get; set; } = number;
    public double Balance { get; } = balance;
    public double CreditLine { get; set; } = creditLine;
    public Person Owner { get; set; } = owner;

    void Withdraw(double amount)
    {

    }
    void Deposit(double amount)
    {

    }
}