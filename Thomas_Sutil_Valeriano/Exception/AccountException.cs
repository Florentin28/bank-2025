public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException()
    {
    }
    public InsufficientBalanceException(string message)
        : base(message) // Call the base class constructor with the message
    {
    }
}
