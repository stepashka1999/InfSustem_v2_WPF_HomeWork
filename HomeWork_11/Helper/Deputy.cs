using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    class Deputy:Employee
    {
        public override string Position { get => "Deputy"; }
        public override int Salary { get => 2000; }

        public Deputy(string FirstName, string LastName, long Phone) : base(FirstName, LastName, Phone)
        {

        }

        public override string ToString()
        {
            string pattern = $"{FirstName} {LastName}\n {Salary}$";
            return pattern;
        }
    }
}
