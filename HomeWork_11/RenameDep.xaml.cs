using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeWork_11
{
    /// <summary>
    /// Логика взаимодействия для RenameDep.xaml
    /// </summary>
    public partial class RenameDep : Window
    {
        MainWindow main;
        Departament Dep;
        Employee Empl = default(Employee);
        public RenameDep(MainWindow m, object dep)
        {
            main = m;
            if (dep is Departament) Dep = (Departament)dep;
            else if (dep is Employee) Empl = (Employee)dep;

            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (Empl == null) Dep.Rename(Name.Text);
            else
            {
                Empl.ChangeName(Name.Text);
            }
            main.RefreshView();
            this.Close();
        }
    }
}
