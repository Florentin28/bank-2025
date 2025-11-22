using System;
class Program
{
    static void Main()
    {
        try
        {
            // Person Test
            Person p = new("Thomas", "Sutil", new DateTime(2001, 3, 25));
            p.DisplayInfoPerson();

            // CurrentAccount Test
            CurrentAccount ca = new("BE58912345678901", 1500.00, 500.00, p);
            CurrentAccount caN = new("", 1500.00, 500.00, p);
            ca.DisplayAccountInfo();
            ca.Withdraw(200.00);
            ca.Deposit(350.00);
            ca.ApplyInterest();

            // SavingsAccount Test
            SavingsAccount sa = new("BE58910987654321", 2500.00, p);
            sa.DisplayAccountInfo();
            sa.Withdraw(300.00);
            sa.Deposit(450.00);
            sa.ApplyInterest();

            // Bank Test
            Bank bank = new("Toto Bank");
            bank.AddAccount(ca);
            bank.AddAccount(ca);//Test duplicate account addition
            bank.AddAccount(caN);//Test invalid account addition
            bank.AddAccount(sa);
            bank.DeleteAccount(caN);//Test invalid account deletion
            bank.DeleteAccount(ca);
            bank.BalanceGet(ca);
            bank.GetTotalBalanceAll(p);
        }
        catch(InsufficientBalanceException ex)
        {
            Console.WriteLine($"Insufficient balance: {ex.Message}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }
    }
}

