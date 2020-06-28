using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    class Manager : Employee
    {
        public override string Position { get => "Manager"; }
        const int MinSalary = 1300;
        public Departament Departament { get; private set; }
        public override int Salary 
        { 
            get => Salary = SalaryCalculate() < MinSalary ? MinSalary : SalaryCalculate();
        }
        private int SalaryCalculate()
        {
            var employeeSalary = Departament.AvgSalary;
            var salary = employeeSalary * 0.15;

            if(Departament.SubDepartaments!=null)
            {
                
            }

            return (int)salary;
        }

        public Manager(string FirstName, string LastName, long Phone, Departament departament): base(FirstName, LastName, Phone)
        {
            Departament = departament;
        }

        public override string ToString()
        {
            string pattern = $"{FirstName} {LastName}\n\t {Salary}$";
            return pattern;
        }
    }
}
