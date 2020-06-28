using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HomeWork_11
{
    abstract class Departament
    {
        public List<SubDepartament> SubDepartaments { get; private protected set; }
        public List<Employee> Employees { get; private protected set; }
        public string Name { get; private set; } 
        public int AvgSalary { get
            {
                var avg = Employees.Sum(x => x.Salary) / Employees.Count;
                if (SubDepartaments != null)
                {
                    foreach (var dep in SubDepartaments)
                    {
                        avg += dep.AvgSalary;
                    }
                }

                return avg;
            }
        }

        public Departament() { }
        public Departament(string Name) { this.Name = Name; }
        public Departament(string Name, List<Employee> empl) : this(Name)
        {
            Employees = empl;
        }
        public void FillTreeViewItem(TreeViewItem item)
        {
            for(int i=0; i < SubDepartaments.Count; i++)
            {
                var tvItem = new TreeViewItem();
                tvItem.Header = SubDepartaments[i];
                tvItem.DataContext = SubDepartaments[i];
                if (SubDepartaments[i].SubDepartaments != null) SubDepartaments[i].FillTreeViewItem(tvItem);

                item.Items.Add(tvItem);
            }
        }
        public Departament(string Name, List<SubDepartament> subDeps, List<Employee> empl):this(Name)
        {
            SubDepartaments = subDeps;
            Employees = empl;
        }

        public void Rename(string name)
        {
            Name = name;
        }
        public void AddEmployee(Employee empl)
        {
            Employees.Add(empl);
        }

        public void DeleteEmployee(Employee empl)
        {
            if(Employees.Contains(empl)) Employees.Remove(empl);
        }

        public void DeleteEmployee(int index)
        {
            if (index < Employees.Count)
            {
                var empl = Employees[index];
                DeleteEmployee(empl);
            }
        }

        public void AddSubDepartament(SubDepartament dep)
        {
            SubDepartaments.Add(dep);
        }

        public void DeleteDepartamnet(SubDepartament dep)
        {
            if (SubDepartaments.Contains(dep)) SubDepartaments.Remove(dep);
        }

        public void DeleteDepartamnet(int index)
        {
            if(index < SubDepartaments.Count)
            {
                var dep = SubDepartaments[index];
                DeleteDepartamnet(dep);
            }
        }

        public void Sort(EmployeeSortParam param)
        {
            Employees.Sort(Employee.Sort(param));
        }

        public Employee this[Employee empl]
        {
            get
            {
                var index = Employees.IndexOf(empl);
                return Employees[index];
            }
        }
    }
}
