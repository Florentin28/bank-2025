using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudkabimbingoy
{
    internal interface IAccount
    {
        double Balance { get;}

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }
}
