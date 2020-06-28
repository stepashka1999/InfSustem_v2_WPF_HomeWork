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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork_11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainDepartement Organization;
        public MainWindow()
        {
            InitializeComponent();
            Organization = new MainDepartement("Pis' Pis' Group");
            Organization.FillTreeView(tv);
        }

        private void tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem tvItem;
            if (tv.SelectedItem != null)
            {
                tvItem = (TreeViewItem)(sender as TreeView).SelectedItem;
                if(tvItem!=null && (tvItem.DataContext is Departament)) employees_lv.ItemsSource = (tvItem.DataContext as Departament).Employees;
            }
        }

        private void RenameDep_Click(object sender, RoutedEventArgs e)
        {
            var dep = (tv.SelectedItem as TreeViewItem).DataContext;

            RenameDep renameDep = new RenameDep(this, dep);
            renameDep.Show();
        }


        private void DeleteDep_Click(object sender, RoutedEventArgs e)
        {
            var dep = (tv.SelectedItem as TreeViewItem).DataContext;
            if (dep.GetType() == typeof(MainDepartement)) MessageBox.Show("Нельзя удалить всю организацию.");
            else if(dep.GetType() == typeof(SubDepartament))
            {
                var res = MessageBox.Show("Переместить сотрудников в резерв?\nИначе они будут просто уволены","Удаление департамента", MessageBoxButton.YesNo);

                if(res == MessageBoxResult.Yes)
                {
                    Organization.RemoveToReserv((dep as SubDepartament).Employees);
                }
                Organization.DeleteDepartamnet((SubDepartament)dep);

                RefreshView();
            }
        }

        public void RefreshView()
        {
            tv.Items.Clear();
            Organization.FillTreeView(tv);
            employees_lv.Items.Refresh();
        }

        private void RenameEmpl(object sender, RoutedEventArgs e)
        {
            //var dep = (Departament)employees_lv.DataContext;
            //var dep = (tv.SelectedItem as TreeViewItem).DataContext;

            var empl = employees_lv.SelectedItem;

            RenameDep renameDep = new RenameDep(this, empl);
            renameDep.Show();

        }

        private void DeleteEmpl_Click(object sender, RoutedEventArgs e)
        {
            var dep = (Departament)(tv.SelectedItem as TreeViewItem).DataContext;
            var empl = (Employee)employees_lv.SelectedItem;

            dep.DeleteEmployee(empl);
            RefreshView();
        }

        private void SortByPos(object sender, RoutedEventArgs e)
        {
            var dep = (Departament)(tv.SelectedItem as TreeViewItem).DataContext;
            dep.Sort(EmployeeSortParam.ByPosition);
            employees_lv.Items.Refresh();
        }

        private void SortByFirstName(object sender, RoutedEventArgs e)
        {
            var dep = (Departament)(tv.SelectedItem as TreeViewItem).DataContext;
            dep.Sort(EmployeeSortParam.ByFirstName);
            employees_lv.Items.Refresh();
        }

        private void SortByLastName(object sender, RoutedEventArgs e)
        {
            var dep = (Departament)(tv.SelectedItem as TreeViewItem).DataContext;
            dep.Sort(EmployeeSortParam.ByLastName);
            employees_lv.Items.Refresh();
        }

        private void SortBySalary(object sender, RoutedEventArgs e)
        {
            var dep = (Departament)(tv.SelectedItem as TreeViewItem).DataContext;
            dep.Sort(EmployeeSortParam.BySalary);
            employees_lv.Items.Refresh();
        }

        private void SortByPhone(object sender, RoutedEventArgs e)
        {
            var dep = (Departament)(tv.SelectedItem as TreeViewItem).DataContext;
            dep.Sort(EmployeeSortParam.ByPhone);
            employees_lv.Items.Refresh();
        }

    }
}
