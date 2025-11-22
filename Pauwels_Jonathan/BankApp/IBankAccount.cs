namespace BankApp
{
    public interface IBankAccount : IAccount
    {
        string Number { get; }   // Lecture seule
        Person Owner { get; }    // Lecture seule
        void ApplyInterest();    // Appliquer les intérêts
    }
}
