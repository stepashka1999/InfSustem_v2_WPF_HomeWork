using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork_11
{
    class SubDepartament:Departament
    {
        public Manager Manager { get; private set; }

        public SubDepartament(string Name, List<Employee> empl, Manager manager = null) : base(Name, empl) 
        {
            if (manager == null) Manager = CreateManager(this);
            else Manager = manager;
        }
        public SubDepartament(string Name, List<SubDepartament> subDeps, List<Employee> empl, Manager manager = null) : base(Name, subDeps, empl)
        {
            if (manager == null) Manager = CreateManager(this);
            else Manager = manager;
        }


        private Manager CreateManager(SubDepartament dep)
        {
            Random rnd = new Random();
            var endTemp = dep.Name.Skip("Departament".Length).ToArray();
            string end = new string(endTemp);


            string FName = "ManagerF"+ end;
            string LName = "ManagerL" + end;

            long Phone = long.Parse("89" + rnd.Next(100000000, 999999999));
            return new Manager(FName, LName, Phone, dep);

        }

        public override string ToString()
        {
            string pattern = $"{Name} \nManager: {Manager}";
            return pattern;
        }
    }
}
