public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
        Console.WriteLine(message);
    }
}