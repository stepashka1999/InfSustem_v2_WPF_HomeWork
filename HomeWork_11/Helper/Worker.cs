using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    class Worker:Employee
    {
        public override string Position { get => "Worker"; }
        public override int Salary { get => 3000;}

        public Worker(string FirstName, string LastName, long Phone) : base(FirstName, LastName, Phone) { }

        public override string ToString()
        {
            var pattern = $"Worker  {Salary}$\n{FirstName} {LastName}\n {Phone}";
            return pattern;
        }
    }
}
