using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudkabimbingoy
{
    internal interface IBankAccount : IAccount
    {
        Person Owner { get; }
        string Number { get; }

        public abstract double ApplyInterest();
        
    }
}
