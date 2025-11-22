using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudkabimbingoy
{
    internal class Person
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime BirthDate { get; private set; }

        public Person(string firstname, string lastname, DateTime bithDate)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.BirthDate = bithDate;
        }
    }
}
