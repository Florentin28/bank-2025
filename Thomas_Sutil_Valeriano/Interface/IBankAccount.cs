public interface IBankAccount : IAccount
{
    string Number { get; }
    Person Owner { get; }
    public void ApplyInterest();

}
