using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudkabimbingoy
{

    internal sealed class CurrentAccount : Account
    {
        public double CreditLine { 
            get;
            
            set
            {
                field = value;
                
                if (CreditLine <= 0)
                {
                    
                    throw new ArgumentOutOfRangeException("La creditline doit etre superieur à 0"); 
                }
            }
        }

        public CurrentAccount(string number, double creditLine,Person owner) : base(number, owner) { 
            CreditLine = creditLine;
        }
        public CurrentAccount(string number, double balance, double creditLine, Person owner) : base(number, balance, owner)
        {
            CreditLine = creditLine;
            //Console.WriteLine("Compte créé avec numéro : " + Number);
        }

        protected override double CalculateInterest()
        {
            if (base.Balance >= 0)
                return 3.0 / 100;
            return 9.75 / 100;
        }


        public override void Deposit(double amount)
        {
            base.Deposit(amount);
        }

        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
        }

        public override string ToString()
        {
            return $"{Number} / {Balance} / {CreditLine}";
        }
    }
}