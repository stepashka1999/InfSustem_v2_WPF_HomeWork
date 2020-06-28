using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    public enum EmployeeSortParam
    {
        ByFirstName,
        ByLastName,
        ByPosition,
        BySalary,
        ByPhone
    }


    abstract class Employee
    {

        private static Dictionary<string, int> PositionLVL = new Dictionary<string, int>
        {
            ["Intern"] = 1,
            ["Worker"] = 2,
            ["Deputy"] = 3,
            ["Director"] = 4
        };


        public virtual string Position { get; private protected set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public long Phone { get; private set; }
        public virtual int Salary { get; private protected set; }

        private class SortByFirstName : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return String.Compare(x.FirstName, y.FirstName);
            }
        }

        private class SortByLastName : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return String.Compare(x.LastName, y.LastName);
            }
        }

        private class SortBySalary : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                if (x.Salary == y.Salary) return 0;
                else if (x.Salary > y.Salary) return 1;
                else return -1;
            }
        }

        private class SortByPhone : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                if (x.Phone > y.Phone) return 1;
                else if (x.Phone == y.Phone) return 0;
                else return -1;
            }
        }

        private class SortByPosition : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                int xPos = PositionLVL[x.Position];
                int yPos = PositionLVL[y.Position];

                if (xPos > yPos) return 1;
                else if (xPos == yPos) return 0;
                else return -1;
            }
        }

        public static IComparer<Employee> Sort(EmployeeSortParam param)
        {
            switch(param)
            {
                case EmployeeSortParam.ByFirstName:
                    return new SortByFirstName();
                case EmployeeSortParam.ByLastName:
                    return new SortByLastName();
                case EmployeeSortParam.BySalary:
                    return new SortBySalary();
                case EmployeeSortParam.ByPhone:
                    return new SortByPhone();
                case EmployeeSortParam.ByPosition:
                    return new SortByPosition();
                default:
                    return new SortByFirstName();
            }
        }

        public Employee(string FirstName, string LastName, long Phone)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
        }

        public void ChangeName(string Name)
        {
            var data = Name.Split(' ');
            if (data.Length > 1)
            {
                FirstName = data[0];
                LastName = data[1];
            }
            else FirstName = data[0];
        }
    }
}
