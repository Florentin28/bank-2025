
using Models;

namespace Abstraction
{
    public interface IBankAccount:IAccount
    {
        decimal Balance { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void ApplyInterest();
        Person owner { get; }
        string Number { get; }
    }
}   
