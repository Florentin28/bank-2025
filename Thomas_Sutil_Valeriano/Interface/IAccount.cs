public interface IAccount
{
    double Balance { get; }
    void Withdraw(double amount);
    void Deposit(double amount);
}
