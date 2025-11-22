public interface IAccount
{
    void Withdraw(double amount);
    void Deposit(double amount);
    double Balance { get; }
}

