Person p = new("Thomas", "Sutil", new DateTime(2001,3,25));

//Testing CurrentAccount Method
CurrentAccount pA = new("BE3256", 1200, 0,p);
pA.Withdraw(200);
pA.Deposit(350);
Console.WriteLine(p.FirstName + " " + p.LastName);
Console.Write(pA.Number + " " + pA.Balance + " " + pA.CreditLine + " " + p.FirstName);
