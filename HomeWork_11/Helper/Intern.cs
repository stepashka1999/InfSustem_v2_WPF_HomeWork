using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    class Intern : Employee
    {
        public override string Position { get => "Intern"; }
        public override int Salary { get => 1000; }
        public Intern(string FirstName, string LastName, long Phone):base(FirstName, LastName, Phone)
        {

        }

        public override string ToString()
        {
            var pattern = $"Intern  {Salary}$\n{FirstName} {LastName}\n {Phone}";
            return pattern;
        }
    }
}
