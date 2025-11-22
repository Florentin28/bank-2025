using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudkabimbingoy
{
    internal class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string msg) : base(msg) 
        { 
           //c'est la class parent qui se charge de l'affichage du message
        }
    }
}
