using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudkabimbingoy
{
    internal sealed class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }

        public SavingsAccount(string number, Person owner) : base(number, owner)
        {

        }
        public SavingsAccount(string number,double balance, Person owner) : base(number, balance, owner)
        {
            
        }
        protected override double CalculateInterest()
        {
            return 4.5 / 100;
        }
        public override void Deposit(double amount)
        {
            base.Deposit(amount);
        }
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
        }
    }
}

