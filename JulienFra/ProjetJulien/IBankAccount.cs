public interface IBankAccount : IAccount
{
    void ApplyInterest();
    Person Owner { get; }
    string Number { get; }
}

