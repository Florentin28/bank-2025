public interface IBankAccount : IAccount
{
    Person Owner { get; }
    string Number { get; }
    void ApplyInterest();

}
