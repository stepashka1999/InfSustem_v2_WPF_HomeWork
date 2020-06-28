using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HomeWork_11
{
    class MainDepartement : Departament
    {
        public Director Director { get; private set; }
        public Deputy Deputy { get; private set; }

        public List<Employee> Reserv { get; private set; }

        public MainDepartement(string Name, Director director, Deputy deputy, List<Employee> empl, List<SubDepartament> subDeps): base(Name, subDeps, empl)
        {
            Director = director;
            Deputy = deputy;
            Employees.AddRange(new List<Employee> { Director, Deputy });
        }

        public MainDepartement(string name) : base(name)
        {
            Director = CreateDirector();
            Deputy = CreateDeputy();
            var list = new List<Employee> { Director, Deputy };
            Employees = list;
            SubDepartaments = CreateDepartaments(10, true);
            Reserv = new List<Employee>();
        }


        private Director CreateDirector()
        {
            Random rnd = new Random();
            string FName = "DirectorF";
            string LName = "DirectorL";

            long Phone = long.Parse("89"+ rnd.Next(100000000,999999999));
            return new Director(FName, LName, Phone, this);
        }
        private Deputy CreateDeputy()
        {
            Random rnd = new Random();
            string FName = "DeputyF";
            string LName = "DeputyL";

            long Phone = long.Parse("89" + rnd.Next(100000000, 999999999));
            return new Deputy(FName, LName, Phone);
        }
        private List<Employee> CreateWorkers(int count)
        {
            Random rnd = new Random();
            List<Employee> list = new List<Employee>();
            
            for(int i = 0; i < count; i++)
            {
                string FName = "WorkerF_"+i;
                string LName = "WorkerL"+i;

                long Phone = long.Parse("89" + rnd.Next(100000000, 999999999));
                list.Add(new Worker(FName, LName, Phone));
            }
            return list;
        }
        private List<Employee> CreateInterns(int count)
        {
            Random rnd = new Random();
            List<Employee> list = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                string FName = "InternF_" + i;
                string LName = "InternL" + i;

                long Phone = long.Parse("89" + rnd.Next(100000000, 999999999));
                list.Add(new Intern(FName, LName, Phone));
            }
            return list;
        }

        
        private List<SubDepartament> CreateDepartaments(int count, bool secondLvl)
        {
            List<SubDepartament> listDeps = new List<SubDepartament>();
            List<Employee> listEmpl = new List<Employee>();


            for (int i = 0; i < count; i++)
            {
                string Name = "Departament_" + i;
                listEmpl.AddRange( CreateWorkers(10) );
                listEmpl.AddRange(CreateInterns(2));

                if (secondLvl)
                {
                    var listDeps2 = CreateDepartaments(2, false);
                    listDeps.Add(new SubDepartament(Name, listDeps2, listEmpl));
                }
                else listDeps.Add(new SubDepartament(Name, listEmpl));
            }
            return listDeps;
        }
        public void FillTreeView(TreeView tv)
        {
            var tvItem = new TreeViewItem();
            tvItem.Header = this;
            tvItem.DataContext = this;
            FillTreeViewItem(tvItem);
            tv.Items.Add(tvItem);

            var reserv = new TreeViewItem();
            reserv.Header = $"Резерв: {Reserv.Count} человек";
            reserv.DataContext = Reserv;
            tv.Items.Add(reserv);
        }

        public void RemoveToReserv(Employee empl)
        {
            Reserv.Add(empl);
        }

        public void RemoveToReserv(List<Employee> list)
        {
            Reserv.AddRange(list);
        }

        public override string ToString()
        {
            string pattern = $"{Name} \nД.:{Director} \nЗам.:{Deputy}";
            return pattern;
        }
    }
}
