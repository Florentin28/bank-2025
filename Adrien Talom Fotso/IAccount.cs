using System.Globalization;

interface IAccount
{
    string Number { get; set; }
    double Balance { get; protected set; }
    Person Owner { get; set; }
    protected double CalculInterets();
    void Deposit();
    void Withdraw();
   
}