namespace BankApp
{
    public interface IAccount
    {
        double Balance { get; }   // Lecture seule
        void Deposit(double amount);
        void Withdraw(double amount);
    }
}
