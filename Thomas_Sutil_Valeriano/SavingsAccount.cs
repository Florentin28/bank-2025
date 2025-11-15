public class SavingsAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; } //Read Only
    public DateTime DateLastWithdraw { get; set; }
    public Person Owner { get; set; }
}
