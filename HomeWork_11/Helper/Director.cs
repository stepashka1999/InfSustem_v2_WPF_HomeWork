using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    class Director:Employee
    {
        public override string Position { get => "Director"; }
        public override int Salary { get => 12000;}
        public MainDepartement Organization { get; private set; }
        public Director(string FirstName, string LastName, long Phone, MainDepartement organization):base(FirstName, LastName, Phone)
        {
            Organization = organization;
        }

        public override string ToString()
        {
            string pattern = $"{FirstName} {LastName}\n {Salary}$";
            return pattern;
        }
    }
}
